using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DestinyCore.Modules;
using DestinyCore.AspNetCore;
using DestinyCore.AutoMapper;
using Destiny.Core.Flow.IdentityServer;

namespace Destiny.Core.Flow.AuthenticationCenter.Startups
{
    [DependsOn(
    typeof(DestinyCoreConfigModule),
    typeof(MvcModule),
    typeof(IdentityModule),
    typeof(AuthenticationCenterEntityFrameworkCoreModule),
    typeof(AutoMapperModule),
    typeof(IdentityServer4Module)
   )]
    public class AppWebModule : AppModule
    {

        public override void ConfigureServices(ConfigureServicesContext context)
        {
           var service = context.Services;
#if DEBUG
            service.AddRazorPages().AddRazorRuntimeCompilation();

#else
            service.AddMvc();
#endif
        }
        public override void ApplicationInitialization(ApplicationContext context)
        {
        
        }
    }
}
