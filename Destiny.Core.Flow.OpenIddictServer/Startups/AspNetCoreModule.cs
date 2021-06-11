using DestinyCore.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
