using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Permission
{
    [Dependency(ServiceLifetime.Scoped)]
    public class PermissionHandler : AuthorizationHandler<PermissionDto>
    {

        /// <summary>
        /// 验证方案提供对象
        /// </summary>
        public IAuthenticationSchemeProvider _Schemes { get; set; }
        private readonly IPrincipal _principal;

        public PermissionHandler(IAuthenticationSchemeProvider schemes, IPrincipal principal)
        {

            _Schemes = schemes;
            _principal = principal;
        }

        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionDto requirement)
        {
            //var filterContext = (context.Resource as Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext);
            var defaultAuthenticate = await _Schemes.GetDefaultAuthenticateSchemeAsync();

            if(defaultAuthenticate!=null)
            {
                var ss = _principal?.Identity.GetUesrId<Guid>();
            }
            //var httpContext = (context.Resource as Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext)?.HttpContext;
            //if(httpContext!=null)
            //{

            //}

            


            await Task.CompletedTask;

            context.Succeed(requirement);
        }
    }
}
