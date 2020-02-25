// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Counter.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2018
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sitecore.Commerce.Plugin.Ordernumber.Entities
{
    using System;
    using System.Collections.Generic;
    using Sitecore.Commerce.Core;

    /// <inheritdoc />
    /// <summary>
    /// Counter model.
    /// </summary>
    public class Counter : CommerceEntity
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Sitecore.Commerce.Plugin.Ordernumber.Entities.Counter" /> class.
        /// </summary>
        public Counter()
        {
            this.DateCreated = DateTime.UtcNow;
            this.DateUpdated = this.DateCreated;
        }

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Sitecore.Commerce.Plugin.Ordernumber.Entities.Counter" /> class. 
        /// Public Constructor
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        public Counter(string id, long startValue = 0, long increment = 1) : this()
        {
            this.Id = id;

            this.StartValue = startValue;
            this.CurrentValue = StartValue;
            this.Increment = increment;
        }

        public long StartValue { get; set; } = 0;
        public long CurrentValue { get; set; } = 0;
        public long Increment { get; set; } = 1; 

        public long GetNextValue()
        {
            var currentValue = CurrentValue;
            CurrentValue += Increment;
            return currentValue;
        }
    }
}