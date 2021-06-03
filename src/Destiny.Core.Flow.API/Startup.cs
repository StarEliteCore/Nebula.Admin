
using Destiny.Core.Flow.API.Startups;
using DestinyCore.AspNetCore;
using DestinyCore.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

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
            //string[] filters =
            //{
            //    "mscorlib",
            //    "netstandard",
            //    "dotnet",
            //    "api-ms-win-core",
            //    "runtime.",
            //    "System",
            //    "Microsoft",
            //    "Window",
            //};
            //IEnumerable<Assembly> allAssemblies = Assembly.GetEntryAssembly().GetReferencedAssemblies().Where(x => !filters.Any(x.Name.StartsWith)).Select(Assembly.Load).ToArray();
            services.AddApplication<AppWebModule>();
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
            app.InitializeApplication();

        }
    }
}
