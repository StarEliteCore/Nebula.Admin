using DestinyCore.AspNetCore.Api;
using Destiny.Core.Flow.Model.Security;
using DestinyCore.Modules;
using DestinyCore.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DestinyCore.Options;
using DestinyCore.AspNetCore;
using DestinyCore.Dependency;
using DestinyCore.Events;
using System.IO;
using Microsoft.Extensions.Options;
using System;

namespace Destiny.Core.Flow.API.Startups
{
    public class FunctionModule : FunctionModuleBase<ApiControllerBase>
    {

    }

    [DependsOn(typeof(DependencyAppModule), typeof(MediatorAppModule))]
    public class DestinyCoreConfigModule : AppModule
    {
        public override void ConfigureServices(ConfigureServicesContext context)
        {
            context.Services.AddFileProvider();
            var configuration = context.Services.GetConfiguration();


            if (configuration == null)
            {
                IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true);
                configuration = configurationBuilder.Build();
                context.Services.AddSingleton<IConfiguration>(configuration);
            }

            AppOptionSettings option = new AppOptionSettings();

            if (configuration != null)
            {

                configuration.Bind("Destiny", option);
                context.Services.AddObjectAccessor(option);
                context.Services.Configure<AppOptionSettings>(o => o = option);
            }

            //context.Services.AddFileProvider();
            //IConfiguration configuration = context.GetConfiguration();
            //context.Services.Configure<AppOptionSettings>(configuration.GetSection("Destiny"));
            //AppOptionSettings configuration2 = context.GetConfiguration<AppOptionSettings>("Destiny");
            //context.Services.AddObjectAccessor(configuration2);
        }
    }
}
