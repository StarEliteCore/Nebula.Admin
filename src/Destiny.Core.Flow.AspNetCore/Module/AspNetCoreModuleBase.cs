using Destiny.Core.Flow.AspNetCore.Mvc.Filters;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Modules;
using Destiny.Core.Flow.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace Destiny.Core.Flow.AspNetCore.Module
{
    public abstract class AspNetCoreModuleBase : AppModule
    {


        public override void ConfigureServices(ConfigureServicesContext context)
        {
            var settings = context.Services.GetObject<AppOptionSettings>();
            context.Services.AddFileProvider();

            context.Services.AddHttpContextAccessor();
    
            context.Services.AddTransient<IPrincipal>(provider =>
            {
                IHttpContextAccessor accessor = provider.GetService<IHttpContextAccessor>();
                return accessor?.HttpContext?.User;
            });

        }





        public override void ApplicationInitialization(ApplicationContext context)
        {
            var app = context.GetApplicationBuilder();
        
            app.UseEndpoints(endpoints => {
                endpoints = this.Endpoints(endpoints);

            });

        }


        protected virtual IEndpointRouteBuilder Endpoints(IEndpointRouteBuilder endpoint)
        {
            endpoint.MapControllers();
            return endpoint;


        }


    }
}
