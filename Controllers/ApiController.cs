// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ApiController.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2019
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sitecore.Commerce.Plugin.Ordernumber.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Sitecore.Commerce.Core;
    using Sitecore.Commerce.Plugin.Ordernumber.Commands;
    using System;
    using System.Threading.Tasks;
    using System.Web.Http.OData;

    /// <inheritdoc />
    /// <summary>
    /// Defines an api controller
    /// </summary>
    /// <seealso cref="T:Sitecore.Commerce.Core.CommerceController" />
    [Route("api")]
    public class ApiController : CommerceController
    {
        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:Sitecore.Commerce.Plugin.Ordernumber.Controllers.ApiController" /> class.
        /// </summary>
        /// <param name="serviceProvider">The service provider.</param>
        /// <param name="globalEnvironment">The global environment.</param>
        public ApiController(IServiceProvider serviceProvider, CommerceEnvironment globalEnvironment)
            : base(serviceProvider, globalEnvironment)
        {
        }

        /// <summary>
        /// Gets the bulk prices.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>A list of <see cref="SellableItem"/></returns>
        [HttpPost]
        [Route("GetNextCounterValue")]
        public async Task<IActionResult> GetNextCounterValue([FromBody] ODataActionParameters value)
        {
            if (!this.ModelState.IsValid)
            {
                return new BadRequestObjectResult(this.ModelState);
            }

            if (!value.ContainsKey("counterName"))
            {
                return new BadRequestObjectResult(value);
            }

            var counterName = (string)value["counterName"];
            var result = await Command<GetNextValueCommand>().Process(CurrentContext, counterName).ConfigureAwait(false);

            return new ObjectResult(result);
        }
    }
}