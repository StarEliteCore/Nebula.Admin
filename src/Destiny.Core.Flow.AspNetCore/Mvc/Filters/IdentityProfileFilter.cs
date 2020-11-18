using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.AspNetCore.Mvc.Filters
{
    public class IdentityProfileFilter : IAsyncAuthorizationFilter
    {
        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            ClaimsPrincipal principal = context.HttpContext.User;
            ClaimsIdentity identity = principal.Identity as ClaimsIdentity;
            IServiceProvider provider = context.HttpContext.RequestServices;
       


            if (identity != null && identity.IsAuthenticated)
            {
              


            }
            await Task.CompletedTask;
        }
    }
}
