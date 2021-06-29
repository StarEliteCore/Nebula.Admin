using Microsoft.Extensions.DependencyInjection;
using DestinyCore.Modules;
using DestinyCore.AutoMapper;
using Destiny.Core.Flow.EntityFrameworkCore;
using Destiny.Core.Flow.AuthenticationCenter.Startups;
using Destiny.Core.Flow.OpenIddict;
using Destiny.Core.Flow.OpenIddict.EntityFrameworkCore;

namespace Destiny.Core.Flow.OpenIddictServer.Startups
{
    [DependsOn(
    typeof(DestinyCoreConfigModule),
    typeof(MvcModule),
    typeof(IdentityModule),
    typeof(OpenIddictModule),
    typeof(OpenIddictEntityFrameworkCoreModule),
    typeof(MigrationModule),
    typeof(AutoMapperModule)
   )]
    public class AppWebModule : AppModule
    {

        public override void ConfigureServices(ConfigureServicesContext context)
        {
           var service = context.Services;
           service.AddMvc();
        }
    }
}
