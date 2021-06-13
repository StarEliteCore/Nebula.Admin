using DestinyCore.AspNetCore.Api;

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




namespace Destiny.Core.AspNetMvc.Test.Startups
{

    [DependsOn(typeof(DependencyAppModule_Tests))]
    public class DestinyCoreConfigModule_Tests : AppModule
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
                string key = "Destiny_Tests";

                configuration.Bind(key, option);
               
                context.Services.AddObjectAccessor(option);
                context.Services.Configure<AppOptionSettings>(o=>{
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
            //AppOptionSettings configuration2 = context.GetConfiguration<AppOptionSettings>("Destiny");
            //context.Services.AddObjectAccessor(configuration2);
        }
    }


    //public class MyConfigureOptions : IConfigureOptions<AppOptionSettings>
    //{

    //    private readonly IConfiguration _configuration = null;
    //    private readonly IServiceCollection _serviceDescriptors = null;

    //    public MyConfigureOptions(IConfiguration configuration, IServiceCollection serviceDescriptors)
    //    {
    //        this._configuration = configuration;
    //        this._serviceDescriptors = serviceDescriptors;
    //    }

    //    public void Configure(AppOptionSettings options)
    //    {


    //    }
    //}
}
