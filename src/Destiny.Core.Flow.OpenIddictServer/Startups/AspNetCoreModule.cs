using DestinyCore.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace Destiny.Core.Flow.OpenIddictServer.Startups
{
    public class AspNetCoreModule:AspNetCoreModuleBase
    {

       

        protected override IEndpointRouteBuilder Endpoints(IEndpointRouteBuilder endpoint)
        {
            endpoint.MapControllerRoute(name: "default", pattern: "{controller=Account}/{action=Login}/{id?}");
            return endpoint;
        }
    }
}
