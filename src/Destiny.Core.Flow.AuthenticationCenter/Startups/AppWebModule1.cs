using Destiny.Core.Flow.AspNetCore.Module;
using Destiny.Core.Flow.AutoMapper;
using Destiny.Core.Flow.IdentityServer;
using Destiny.Core.Flow.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.AuthenticationCenter.Startups
{
    [DependsOn(
    typeof(DestinyCoreModule),
    typeof(MvcModule),
    typeof(IdentityModule),
    typeof(AuthenticationCenterEntityFrameworkCoreModule),
    typeof(AutoMapperModule),
    typeof(IdentityServer4Module)



   )]
    public class AppWebModule1 : AppModule
    {

        public override void ConfigureServices(ConfigureServicesContext context)
        {
           var service = context.Services;
           service.AddMvc();
        }
        public override void ApplicationInitialization(ApplicationContext context)
        {
        
        }
    }
}
