using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Authorization;
using System.Reflection;
using System.Linq;
using Destiny.Core.Flow.Extensions;
using Microsoft.AspNetCore.Identity;
using Destiny.Core.Flow.Model.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Destiny.Core.Flow.Model.Entities.Rolemenu;
using Destiny.Core.Flow.Model.Entities.Menu;
using Destiny.Core.Flow.Model.Entities.Function;
using Destiny.Core.Flow.AspNetCore.Ui;
using Destiny.Core.Flow.Ui;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Destiny.Core.Flow.Permission;

namespace Destiny.Core.Flow.AspNetCore.Mvc.Filters
{
    /// <summary>
    /// 好像3.1不能这样用了，是用策略
    /// </summary>
    public class PermissionAuthorizationFilter : IAsyncAuthorizationFilter
    {
        private readonly IAuthorityVerification _authority;
        private readonly IPrincipal _principal;
        public PermissionAuthorizationFilter(IAuthorityVerification authority, IPrincipal principal)
        {
            _authority = authority;
            _principal = principal;
            
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var action = context.ActionDescriptor as ControllerActionDescriptor;
            var isAllowAnonymous = action.ControllerTypeInfo.GetCustomAttribute<AllowAnonymousAttribute>();//获取Action中的特性
            var linkurl = context.HttpContext.Request.Path.Value.Replace("/api/", "");
            var result = new AjaxResult(MessageDefinitionType.Unauthorized, Enums.AjaxResultType.Unauthorized);
            if (!action.EndpointMetadata.Any(x => x is AllowAnonymousAttribute || x is NoAuthorityVerificationAttribute))
            {
                if (!_principal.Identity.IsAuthenticated)
                {
                    context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    context.Result = new JsonResult(result);
                    return;
                }
                if (!await _authority.IsPermission(linkurl.ToLower()))
                {
                    ////????不包含的时候怎么返回出去？这个请求终止掉
                    ///
                    result.Message = MessageDefinitionType.Uncertified;
                    context.HttpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
                    context.Result = new JsonResult(result);
                    return;
                }
            }
        }
    }
}
