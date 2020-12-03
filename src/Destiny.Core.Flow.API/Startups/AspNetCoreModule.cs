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

        protected virtual AppOptionSettings Configure(ConfigureServicesContext context)
        {
            var configuration = context.GetConfiguration();
            context.Services.Configure<AppOptionSettings>(configuration.GetSection("Destiny"));

            var settings = context.GetConfiguration<AppOptionSettings>("Destiny");
            context.Services.AddObjectAccessor<AppOptionSettings>(settings);
            return settings;

        }
        public override void ConfigureServices(ConfigureServicesContext context)
        {
            var settings = Configure(context);
            context.Services.AddFileProvider();
            context.Services.AddTransient(typeof(Lazy<>), typeof(LazyFactory<>));

            this.AddCors(context,settings);
            context.Services.AddHttpContextAccessor();
            this.AddControllers(context);

            context.Services.AddTransient<IPrincipal>(provider =>
            {
                IHttpContextAccessor accessor = provider.GetService<IHttpContextAccessor>();
                return accessor?.HttpContext?.User;
            });

        }

        protected virtual void AddCors(ConfigureServicesContext context, AppOptionSettings settings)
        {

            if (!settings.Cors.PolicyName.IsNullOrEmpty() && !settings.Cors.Url.IsNullOrEmpty()) //添加跨域
            {

                context.Services.AddCors(c =>
                {
                    c.AddPolicy(settings.Cors.PolicyName, policy =>
                    {
                        policy.WithOrigins(settings.Cors.Url
                          .Split(",", StringSplitOptions.RemoveEmptyEntries).ToArray())
                        //policy.WithOrigins("http://localhost:5001")//支持多个域名端口，注意端口号后不要带/斜杆：比如localhost:8000/，是错的
                        .AllowAnyHeader().AllowAnyMethod().AllowCredentials();//允许cookie;
                    });
                });
            }

        }

        protected virtual void AddControllers(ConfigureServicesContext context)
        {

            context.Services.AddControllers(o=>this.AddMvcOptions(o)).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();

                options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
            });
        }

        protected virtual void AddMvcOptions(MvcOptions options)
        {

        }

        public override void ApplicationInitialization(ApplicationContext context)
        {
            var app = context.GetApplicationBuilder();
            app.UseRouting();
            UseCors(context,app);
            this.ApplicationInitializationMiddle(context,app);
            UseEndpoints(app);
        }

        protected virtual void ApplicationInitializationMiddle(ApplicationContext context,IApplicationBuilder app)
        {
            app.UseAuthentication(); //认证
            app.UseAuthorization();//授权

        }

        protected virtual void UseCors(ApplicationContext context,IApplicationBuilder app)
        {
          
            var  settings=    context.ServiceProvider.GetRequiredService<IObjectAccessor<AppOptionSettings>>()?.Value;
            if (settings?.Cors != null)
            {
                string corePolicyName = settings.Cors.PolicyName;
                if (!corePolicyName.IsNullOrEmpty())
                {
                    app.UseCors(corePolicyName); //添加跨域中间件
                }
            }
  
        }

        protected virtual void UseEndpoints(IApplicationBuilder app)
        {

            app.UseEndpoints(endpoints => EndpointRouteBuilder(endpoints));
        }

        protected virtual void EndpointRouteBuilder(IEndpointRouteBuilder endpoints)
        {

            endpoints.MapControllers();
        }


        protected void AddMvc(IServiceCollection services) {

            services.AddMvc();
        }
    }
}
