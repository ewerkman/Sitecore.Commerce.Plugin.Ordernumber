// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GetNextCounterValueArgument.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2019
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sitecore.Commerce.Plugin.Ordernumber.Pipelines.Arguments
{
    using Sitecore.Commerce.Core;

    /// <inheritdoc />
    /// <summary>
    /// The GetNextCounterValueArgument.
    /// </summary>
    public class GetNextCounterValueArgument : PipelineArgument
    {
        public GetNextCounterValueArgument(string counterName)
        {
            CounterName = counterName;
        }

        public string CounterName { get; }
    }
}