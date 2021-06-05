using DestinyCore.Dependency;
using DestinyCore.Events;
using DestinyCore.Extensions;
using DestinyCore.Modules;
using DestinyCore.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.AuthenticationCenter.Startups
{
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
                context.Services.Configure<AppOptionSettings>(o => {
                    o.AuditEnabled = option.AuditEnabled;
                    o.Auth = option.Auth;
                    o.Cors = option.Cors;
                    o.DbContexts = option.DbContexts;
                    o.IsAutoAddFunction = option.IsAutoAddFunction;
                    o.Jwt = option.Jwt;

                });
            }

            //context.Services.AddFileProvider();
            //IConfiguration configuration = context.GetConfiguration();
            //context.Services.Configure<AppOptionSettings>(configuration.GetSection("Destiny"));
            //AppOptionSettings configuration2 = context.GetConfiguration<AppOptionSettings>("Destiny");
            //context.Services.AddObjectAccessor(configuration2);
        }
    }
}
