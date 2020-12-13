using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Events;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Modules;
using Destiny.Core.Flow.Options;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Destiny.Core.Flow.AspNetCore.Module
{
    [DependsOn(

        typeof(DependencyAppModule),
        typeof(MediatorAppModule)
    )]
    public class DestinyCoreModule : AppModule
    {
        public override void ConfigureServices(ConfigureServicesContext context)
        {
            context.Services.AddFileProvider();
            var configuration = context.GetConfiguration();
            context.Services.Configure<AppOptionSettings>(configuration.GetSection("Destiny"));

            var settings = context.GetConfiguration<AppOptionSettings>("Destiny");
            context.Services.AddObjectAccessor<AppOptionSettings>(settings);
        }






    }
}
