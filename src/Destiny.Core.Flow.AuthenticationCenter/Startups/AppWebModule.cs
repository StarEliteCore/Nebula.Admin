using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.IdentityServer;
using Destiny.Core.Flow.Modules;
using Destiny.Core.Flow.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.AuthenticationCenter.Startups
{
    [DependsOn(
    typeof(IdentityModule),
    //typeof(DependencyAppModule),
    typeof(EntityFrameworkCoreMySqlModule),
        typeof(IdentityServer4Module)
    )]
    public class AppWebModule : AppModule
    {
        public override void ApplicationInitialization(ApplicationContext context)
        {
            var app = context.GetApplicationBuilder();
            app.UseStaticFiles();
        }

        public override void ConfigureServices(ConfigureServicesContext context)
        {
            var service = context.Services;
            service.AddMvc();
            var configuration = service.GetConfiguration();
            service.Configure<AppOptionSettings>(configuration.GetSection("Destiny"));
            var settings = service.GetAppSettings();
        }
    }
}
