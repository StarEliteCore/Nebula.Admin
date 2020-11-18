using Destiny.Core.Flow.AspNetCore.Ui;
using Destiny.Core.Flow.Permission;
using Destiny.Core.Flow.Ui;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.AspNetCore.Mvc.Filters
{
    /// <summary>
    ///
    /// </summary>
    public class PermissionAuthorizationFilter : IAsyncAuthorizationFilter
    {
        private readonly IAuthorityVerification _authority;
        private readonly IPrincipal _principal;
        private readonly ILogger<PermissionAuthorizationFilter> _logger = null;

        public PermissionAuthorizationFilter(IAuthorityVerification authority, IPrincipal principal, ILogger<PermissionAuthorizationFilter> logger)
        {
            _authority = authority;
            _principal = principal;
            _logger = logger;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var action = context.ActionDescriptor as ControllerActionDescriptor;
            var isAllowAnonymous = action.ControllerTypeInfo.GetCustomAttribute<AllowAnonymousAttribute>();//获取Action中的特性
            var linkurl = context.HttpContext.Request.Path.Value.Replace("/api/", "");
            var result = new AjaxResult(MessageDefinitionType.Unauthorized, Enums.AjaxResultType.Unauthorized);
            if (!action.EndpointMetadata.Any(x => x is AllowAnonymousAttribute))
            {
                if (!_principal.Identity.IsAuthenticated)
                {
                    context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    context.Result = new JsonResult(result);
                    return;
                }
                else
                {
                    if (!action.EndpointMetadata.Any(x => x is NoAuthorityVerificationAttribute))
                    {
                        if (!await _authority.IsPermission(linkurl.ToLower()))
                        {
                            ////????不包含的时候怎么返回出去？这个请求终止掉
                            ///
                            _logger.LogError($"此{linkurl}地址没有权限");
                            result.Message = MessageDefinitionType.Uncertified;
                            result.Type = Enums.AjaxResultType.Uncertified;
                            context.HttpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
                            context.Result = new JsonResult(result);
                            return;
                        }
                    }
                }
            }
        }
    }
}
