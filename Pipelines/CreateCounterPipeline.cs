﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateCounterPipeline.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2017
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sitecore.Commerce.Plugin.Ordernumber.Pipelines
{
    using Microsoft.Extensions.Logging;
    using Sitecore.Commerce.Core;
    using Sitecore.Framework.Pipelines;
    using Sitecore.Commerce.Plugin.Ordernumber.Entities;
    using Sitecore.Commerce.Plugin.Ordernumber.Pipelines.Arguments;

    /// <inheritdoc />
    /// <summary>
    ///  Defines the CreateCounterPipeline pipeline.
    /// </summary>
    /// <seealso>
    ///     <cref>
    ///         Sitecore.Commerce.Core.CommercePipeline{Namespace.PipelineArgumentOrEntity,
    ///         Namespace.PipelineArgumentOrEntity}
    ///     </cref>
    /// </seealso>
    /// <seealso cref="T:Sitecore.Commerce.Plugin.Ordernumber.Pipelines.safeitemrootname" />
    public class CreateCounterPipeline : CommercePipeline<CreateCounterArgument, Counter>, ICreateCounterPipeline
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Sitecore.Commerce.Plugin.Ordernumber.Pipelines.CreateCounterPipeline" /> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        /// <param name="loggerFactory">The logger factory.</param>
        public CreateCounterPipeline(IPipelineConfiguration<ICreateCounterPipeline> configuration, ILoggerFactory loggerFactory)
            : base(configuration, loggerFactory)
        {
        }
    }
}

