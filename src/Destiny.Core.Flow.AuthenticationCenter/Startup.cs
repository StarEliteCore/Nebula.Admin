using Destiny.Core.Flow.AuthenticationCenter.Startups;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Modules;
using IdentityServer4.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Destiny.Core.Flow.AuthenticationCenter
{
    public class Startup
    {

        private string _uris = "https://auth.destinycore.club";
        private bool _isonline = false;
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            _uris = services.GetConfiguration()["Destiny:IsOnlineurl"];
            _isonline = Convert.ToBoolean(services.GetConfiguration()["Destiny:IsOnline"]);
            services.AddApplication<AppWebModule>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (_isonline)
            {
                app.Use(async (ctx, next) =>
                {
                    ctx.SetIdentityServerOrigin(_uris);
                    ctx.SetIdentityServerBasePath(ctx.Request.PathBase.Value.TrimEnd('/'));
                    await next();
                });
            }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.InitializeApplication();

        }
    }
}
