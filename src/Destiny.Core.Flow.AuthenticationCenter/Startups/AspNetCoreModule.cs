using Destiny.Core.Flow.AspNetCore.Module;
using Destiny.Core.Flow.Modules;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.AuthenticationCenter.Startups
{
    public class AspNetCoreModule:AspNetCoreModuleBase
    {

       

        protected override IEndpointRouteBuilder Endpoints(IEndpointRouteBuilder endpoint)
        {
            endpoint.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");
            return endpoint;
        }
    }
}
