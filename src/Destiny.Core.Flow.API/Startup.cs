using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspectCore.Configuration;
using AspectCore.Extensions.DependencyInjection;
using Destiny.Core.Aop.Aop;
using Destiny.Core.Flow.AspNetCore;
using Destiny.Core.Flow.IServices;
using Destiny.Core.Flow.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Destiny.Core.Flow.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddAppModuleManager<AspNetCoreAppModuleManager>();
            //services.AddScoped<ITest1, Test1>();
            //services.ConfigureDynamicProxy(
            //   config =>
            //   {
            //       List<Type> types = new List<Type>();
            //       //types.Add(typeof(GlobalAopTran));
            //       types.Add(typeof(AopTran));
            //       //config.NonAspectPredicates.AddService("IUnitofWork");//需要过滤掉不需要代理的服务层
            //       ///不建议做全局AOP  因为毕竟AOP用的比较少  做全局的话坑太大
            //       foreach (var item in types)
            //       {
            //           config.Interceptors.AddTyped(item, Predicates.ForNameSpace("Destiny.Core.Flow.Services"),Predicates.ForNameSpace("Destiny.Core.Flow.IServices"));
            //           //一下是配置需要代理的层或者不需要代理的层（二者选其一就好）
            //           //config.Interceptors.AddTyped(item, Predicates.ForNameSpace("TestServices"),Predicates.ForNameSpace(""));//这种是配置只需要代理的层
            //           //config.NonAspectPredicates.AddService("IUnitofWork");//需要过滤掉不需要代理的服务层  
            //           //config.Interceptors.AddTyped(item);
            //       }
            //   });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseErrorHandling();
            //app.UseRouting();

            //app.UseAuthorization();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //});
            app.UseAppModule<AspNetCoreAppModuleManager>();

        }
    }
}
