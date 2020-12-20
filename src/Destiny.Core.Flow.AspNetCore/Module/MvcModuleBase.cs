using Destiny.Core.Flow.AspNetCore.Mvc.Filters;
using Destiny.Core.Flow.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.AspNetCore.Module
{

    public abstract class MvcModuleBase : AppModule
    {

        public override void ConfigureServices(ConfigureServicesContext context)
        {
            AddCors(context);
            context.Services.AddControllers(o => this.AddMvcOptions(o)).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();

                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            });
            context.Services.AddScoped<AuditLogFilterAttribute>();
            context.Services.AddScoped<UnitOfWorkAtrrribute>();
        }



        protected virtual void AddMvcOptions(MvcOptions options)
        {

        }
        public override void ApplicationInitialization(ApplicationContext context)
        {
            var app= context.GetApplicationBuilder();
            app.UseRouting();
            UseCors(context);

            app.UseAuthentication(); //认证
            app.UseAuthorization();//授权
        }

        protected virtual void AddCors(ConfigureServicesContext context)
        {


        }


        protected virtual void UseCors(ApplicationContext context)
        {



        }
    }
}
