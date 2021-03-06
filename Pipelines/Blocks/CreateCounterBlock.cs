﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateCounterBlock.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2019
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sitecore.Commerce.Plugin.Ordernumber.Pipelines.Blocks
{
    using Sitecore.Commerce.Core;
    using Sitecore.Framework.Conditions;
    using Sitecore.Framework.Pipelines;
    using Sitecore.Commerce.Plugin.Ordernumber.Entities;
    using Sitecore.Commerce.Plugin.Ordernumber.Pipelines.Arguments;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines a pipeline block
    /// </summary>
    /// <seealso>
    ///     <cref>
    ///         Sitecore.Framework.Pipelines.PipelineBlock{Sitecore.Commerce.Core.PipelineArgument,
    ///         Sitecore.Commerce.Core.PipelineArgument, Sitecore.Commerce.Core.CommercePipelineExecutionContext}
    ///     </cref>
    /// </seealso>
    [PipelineDisplayName("Change to <Project>Constants.Pipelines.Blocks.<Block Name>")]
    public class CreateCounterBlock : PipelineBlock<CreateCounterArgument, Counter, CommercePipelineExecutionContext>
    {
        /// <summary>
        /// Gets or sets the commander.
        /// </summary>
        /// <value>
        /// The commander.
        /// </value>
        protected CommerceCommander Commander { get; set; }

        /// <inheritdoc />
        /// <summary>Initializes a new instance of the <see cref="T:Sitecore.Framework.Pipelines.PipelineBlock" /> class.</summary>
        /// <param name="commander">The commerce commander.</param>
        public CreateCounterBlock(CommerceCommander commander)
            : base(null)
        {

            this.Commander = commander;

        }

        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="arg">
        /// The pipeline argument.
        /// </param>
        /// <param name="context">
        /// The context.
        /// </param>
        /// <returns>
        /// The <see cref="PipelineArgument"/>.
        /// </returns>
        public override async Task<Counter> Run(CreateCounterArgument arg, CommercePipelineExecutionContext context)
        {
            Condition.Requires(arg).IsNotNull($"{this.Name}: The argument can not be null");
            Condition.Requires(arg.CounterName).IsNotEmpty($"The CounterName can not be empty");

            var entityId = $"{CommerceEntity.IdPrefix<Counter>()}{arg.CounterName}";

            var counterExists = await Commander.Pipeline<IDoesEntityExistPipeline>().Run(new FindEntityArgument(typeof(Counter),  entityId), context);

            if (counterExists)
            {
                context.Abort(
                    await context.CommerceContext.AddMessage(
                        context.GetPolicy<KnownResultCodes>().ValidationError,
                        "CounterNameAlreadyInUse",
                        new object[] { arg.CounterName },
                        $"Counter name {arg.CounterName} is already in use.").ConfigureAwait(false),
                    context);

                return null;
            }

            var counter = new Counter(entityId, arg.StartValue, arg.Increment);

            counter.Name = arg.CounterName;
            counter.DisplayName = arg.CounterName;

            return counter;
        }
    }
}