using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Destiny.Core.Flow.AuthenticationCenter.Startups;
using Destiny.Core.Flow.Modules;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Destiny.Core.Flow.AuthenticationCenter
{
    public class Startup
    {

        private string _uris= "https://auth.destinycore.club";
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddApplication<AppWebModule>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.InitializeApplication();
            //app.Use(async (ctx, next) =>
            //{
            //    ctx.SetIdentityServerOrigin(_uris);
            //    System.Console.WriteLine(ctx.Request.PathBase.Value.TrimEnd('/'));
            //    ctx.SetIdentityServerBasePath(ctx.Request.PathBase.Value.TrimEnd('/'));
            //    await next();
            //});
        }
    }
}
