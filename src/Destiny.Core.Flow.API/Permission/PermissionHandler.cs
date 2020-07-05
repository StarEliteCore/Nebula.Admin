using Destiny.Core.Flow.AspNetCore.Ui;
using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Ui;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
//using Destiny.Core.Flow.AspNetCore.Ui;

namespace Destiny.Core.Flow.API.Permission
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
            //var defaultAuthenticate = await _Schemes.GetDefaultAuthenticateSchemeAsync();
            //var httpContext = (context.Resource as Microsoft.AspNetCore.Mvc.Filters.AuthorizationFilterContext)?.HttpContext;
            //var quesrUrl = context.Resource;
            //var result = new AjaxResult(MessageDefinitionType.Unauthorized,Enums.AjaxResultType.Unauthorized);
            ////判断请求是否停止
            ////var handlers = httpContext.RequestServices.GetRequiredService<IAuthenticationHandlerProvider>();
            ////foreach (var scheme in await this._Schemes.GetRequestHandlerSchemesAsync())
            ////{
            ////    if (await handlers.GetHandlerAsync(httpContext, scheme.Name) is IAuthenticationRequestHandler handler && await handler.HandleRequestAsync())
            ////    {
            ////        //自定义异常返回数据
            ////        httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            ////        filterContext.Result = new JsonResult(result);
            ////        context.Succeed(requirement);
            ////        return;
            ////    }
            ////}
            //if (defaultAuthenticate!=null)
            //{
            //    var Roles = _principal?.Identity.GetRoles<Guid>();
            //    var Authresult = await httpContext.AuthenticateAsync(defaultAuthenticate.Name);
            //    if (Authresult?.Principal != null)
            //    {
            //        httpContext.User = Authresult.Principal;
            //        if (true)
            //        {
                        
            //                var isMatchRole = false;
            //                //var permisssionRoles = requirement.Permissions.Where(x => currentRoles.Contains(x.Role.ToString())).ToList();//根据当前用户角色获取所有的角色信息
            //                requirement.PermissionsUrl.ForEach(x =>
            //                {
            //                    try
            //                    {
            //                        if (Regex.Match("", x.ToLower()).Value == quesrUrl)
            //                        {
            //                            isMatchRole = true;//如果等于true 证明有权限
            //                        }
            //                    }
            //                    catch (Exception)
            //                    {

            //                        throw;
            //                    }
            //                });
            //                if (Roles.Length <= 0 || !isMatchRole)
            //                {
            //                result.Message = MessageDefinitionType.Uncertified;
            //                    httpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
            //                    filterContext.Result = new JsonResult(result);
            //                    context.Succeed(requirement);
            //                    return;
            //                }
            //        }
            //        //判断过期时间（这里仅仅是最坏验证原则，你可以不要这个if else的判断，因为我们使用的官方验证，Token过期后上边的result?.Principal 就为 null 了，进不到这里了，因此这里其实可以不用验证过期时间，只是做最后严谨判断）
            //        if ((httpContext.User.Claims.SingleOrDefault(s => s.Type == ClaimTypes.Expiration)?.Value) != null &&
            //            DateTime.Parse(httpContext.User.Claims.SingleOrDefault(s => s.Type == ClaimTypes.Expiration)?.Value) >= DateTime.Now)
            //        {
            //            context.Succeed(requirement);
            //        }
            //        else
            //        {
            //            httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            //            filterContext.Result = new JsonResult(result);
            //            context.Succeed(requirement);
            //            return;
            //        }
            //        return;
            //    }
            //}
            //if ("".Equals(requirement.LoginPath.ToLower(), StringComparison.Ordinal) && (!httpContext.Request.Method.Equals("POST") || !httpContext.Request.HasFormContentType))
            //{
            //    httpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
            //    filterContext.Result = new JsonResult(result);
            //}
            context.Succeed(requirement);
        }
    }
}
