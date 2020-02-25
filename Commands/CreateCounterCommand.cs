// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateCounterCommand.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2019
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sitecore.Commerce.Plugin.Ordernumber.Commands
{
    using Sitecore.Commerce.Core;
    using Sitecore.Commerce.Core.Commands;
    using Sitecore.Commerce.Plugin.Ordernumber.Entities;
    using Sitecore.Commerce.Plugin.Ordernumber.Pipelines;
    using Sitecore.Commerce.Plugin.Ordernumber.Pipelines.Arguments;
    using System;
    using System.Threading.Tasks;

    /// <inheritdoc />
    /// <summary>
    /// Defines the CreateCounterCommand command.
    /// </summary>
    public class CreateCounterCommand : CommerceCommand
    {
        /// <summary>
        /// Gets or sets the commander.
        /// </summary>
        /// <value>
        /// The commander.
        /// </value>
        protected CommerceCommander Commander { get; set; }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Sitecore.Commerce.Plugin.Ordernumber.Commands.CreateCounterCommand" /> class.
        /// </summary>
        /// <param name="pipeline">
        /// The pipeline.
        /// </param>
        /// <param name="serviceProvider">The service provider</param>
        public CreateCounterCommand(CommerceCommander commander, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            this.Commander = commander;
        }

        /// <summary>
        /// The process of the command
        /// </summary>
        /// <param name="commerceContext">
        /// The commerce context
        /// </param>
        /// <param name="parameter">
        /// The parameter for the command
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<Counter> Process(CommerceContext commerceContext, string counterName, long startValue = 0, long increment = 1)
        {
            Counter result = null;
            using (CommandActivity.Start(commerceContext, this))
            {
                await PerformTransaction(
                    commerceContext,
                    async () =>
                    {
                        var contextOptions = commerceContext.PipelineContextOptions;

                        var argument = new CreateCounterArgument(counterName, startValue, increment);

                        var counter = await Commander.Pipeline<ICreateCounterPipeline>().Run(argument, contextOptions).ConfigureAwait(false);
                        result = counter;

                    }).ConfigureAwait(false);

                return result;
            }
        }
    }
}