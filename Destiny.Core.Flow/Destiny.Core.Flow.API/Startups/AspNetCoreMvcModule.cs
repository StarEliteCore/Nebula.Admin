using Destiny.Core.Flow.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.API.Startups
{
    public class AspNetCoreMvcModule: AppModuleBase
    {

        public override IServiceCollection ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            return services;
        }

        public override void Configure(IApplicationBuilder app)
        {
       

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
