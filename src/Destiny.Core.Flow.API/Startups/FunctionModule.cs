using DestinyCore.AspNetCore.Api;
using Destiny.Core.Flow.Model.Security;
using DestinyCore.Modules;
using DestinyCore.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DestinyCore.Options;

namespace Destiny.Core.Flow.API.Startups
{
    public class FunctionModule : FunctionModuleBase <ApiControllerBase>
    {

    }
    public class DestinyCoreConfigModule : AppModule
    {
        public override void ConfigureServices(ConfigureServicesContext context)
        {
            context.Services.AddFileProvider();
            IConfiguration configuration = context.GetConfiguration();
            context.Services.Configure<AppOptionSettings>(configuration.GetSection("Destiny"));
            AppOptionSettings configuration2 = context.GetConfiguration<AppOptionSettings>("Destiny");
            context.Services.AddObjectAccessor(configuration2);
        }
    }
}
