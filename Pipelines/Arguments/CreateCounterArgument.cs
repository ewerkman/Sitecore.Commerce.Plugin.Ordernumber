// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CreateCounterArgument.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2019
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sitecore.Commerce.Plugin.Ordernumber.Pipelines.Arguments
{
    using Sitecore.Commerce.Core;

    /// <inheritdoc />
    /// <summary>
    /// The CreateCounterArgument.
    /// </summary>
    public class CreateCounterArgument : PipelineArgument
    {
        public CreateCounterArgument(string counterName, long startValue = 0, long increment = 1)
        {
            CounterName = counterName;
            StartValue = startValue;
            Increment = increment;
        }

        public string CounterName { get; }
        public long StartValue { get; }
        public long Increment { get; }
    }
}