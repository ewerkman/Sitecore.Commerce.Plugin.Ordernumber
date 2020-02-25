// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ConfigureSitecore.cs" company="Sitecore Corporation">
//   Copyright (c) Sitecore Corporation 1999-2017
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Sitecore.Commerce.Plugin.Ordernumber
{
    using System.Reflection;
    using Microsoft.Extensions.DependencyInjection;
    using Sitecore.Commerce.Core;
    using Sitecore.Framework.Configuration;
    using Sitecore.Framework.Pipelines.Definitions.Extensions;
    using Sitecore.Commerce.Plugin.Ordernumber.Pipelines;
    using Sitecore.Commerce.Plugin.Ordernumber.Pipelines.Blocks;

    /// <summary>
    /// The configure sitecore class.
    /// </summary>
    public class ConfigureSitecore : IConfigureSitecore
    {
        /// <summary>
        /// The configure services.
        /// </summary>
        /// <param name="services">
        /// The services.
        /// </param>
        public void ConfigureServices(IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();
            services.RegisterAllPipelineBlocks(assembly);

            // Configure pipelines
            services.Sitecore().Pipelines(config =>
                config.AddPipeline<ICreateCounterPipeline, CreateCounterPipeline>(pipeline =>
                        pipeline.Add<CreateCounterBlock>()
                                .Add<PersistCounterBlock>())
                .AddPipeline<IGetNextCounterValuePipeline, GetNextCounterValuePipeline>(pipeline => pipeline.Add<GetNextCounterValueBlock>())
                .ConfigurePipeline<IConfigureServiceApiPipeline>(configure => configure.Add<ConfigureServiceApiBlock>())
                );

            // services.Sitecore().Pipelines(config => config

            //  .AddPipeline<ISamplePipeline, SamplePipeline>(
            //         configure =>
            //             {
            //                 configure.Add<SampleBlock>();
            //             })

            //    .ConfigurePipeline<IConfigureServiceApiPipeline>(configure => configure.Add<ConfigureServiceApiBlock>()));

            services.RegisterAllCommands(assembly);
        }
    }
}