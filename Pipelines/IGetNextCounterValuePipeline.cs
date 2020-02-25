// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IGetNextCounterValuePipeline.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2017
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sitecore.Commerce.Plugin.Ordernumber.Pipelines
{
    using Sitecore.Commerce.Core;
    using Sitecore.Framework.Pipelines;
    using Sitecore.Commerce.Plugin.Ordernumber.Pipelines.Arguments;

    /// <summary>
    /// Defines the IGetNextCounterValuePipeline interface
    /// </summary>
    /// <seealso>
    ///     <cref>
    ///         Sitecore.Framework.Pipelines.IPipeline{PipelineArgumentOrEntity,
    ///         PipelineArgumentOrEntity, Sitecore.Commerce.Core.CommercePipelineExecutionContext}
    ///     </cref>
    /// </seealso>
    [PipelineDisplayName("[Insert Project Name].Pipeline.IGetNextCounterValuePipeline")]
    public interface IGetNextCounterValuePipeline : IPipeline<GetNextCounterValueArgument, long, CommercePipelineExecutionContext>
    {
    }
}
