using Destiny.Core.Flow.AspNetCore.Mvc.Filters;
using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Modules;
using Destiny.Core.Flow.Options;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.API.Startups
{
    public class AspNetCoreModule : AppModule
    {


        public override void ConfigureServices(ConfigureServicesContext context)
        {
            var settings = context.Services.GetObject<AppOptionSettings>();
            context.Services.AddFileProvider();
   

            this.AddCors(context);
            context.Services.AddHttpContextAccessor();
            context.Services.AddControllers(o => this.AddMvcOptions(o)).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();

                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            });

            context.Services.AddTransient<IPrincipal>(provider =>
            {
                IHttpContextAccessor accessor = provider.GetService<IHttpContextAccessor>();
                return accessor?.HttpContext?.User;
            });

        }

        protected virtual void AddCors(ConfigureServicesContext context)
        {


        }

      

        protected virtual void AddMvcOptions(MvcOptions options)
        {

        }

        public override void ApplicationInitialization(ApplicationContext context)
        {
            var app = context.GetApplicationBuilder();
            app.UseRouting();
            UseCors(context);
            
        }

        protected virtual void UseCors(ApplicationContext context)
        {
          
          
  
        }

    }
}
