using Destiny.Core.Flow.IServices.Permission;
using DestinyCore.AspNetCore;
using DestinyCore.Enums;
using DestinyCore.Extensions;
using DestinyCore.Permission;
using DestinyCore.Ui;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.API.Filters
{

    /// <summary>
    /// 待重写大黄瓜
    /// </summary>
    public class PermissionAuthorizationFilter: IAsyncAuthorizationFilter
    {
        private readonly IAuthorityService _authority = null;
        private readonly IPrincipal _principal;
        private readonly ILogger<PermissionAuthorizationFilter> _logger = null;
        private readonly IServiceProvider _serviceProvider = null;

        public PermissionAuthorizationFilter(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _principal = serviceProvider.GetService<IPrincipal>();
            _logger = serviceProvider.GetService<ILoggerFactory>()?.CreateLogger<PermissionAuthorizationFilter>();
            _authority = serviceProvider.GetService<IAuthorityService>();
            _authority.NotNull(nameof(_authority));

        }


        protected async Task OnCheckAuthorzieAsync(AuthorizationFilterContext context)
        {

            if (!context.HttpContext.User.Identity.IsAuthenticated) //没有通过登录
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Result = new JsonResult(new AjaxResult(MessageDefinitionType.Unauthorized, AjaxResultType.Unauthorized));
                return;

            }
            else {
                var httpContext=  context.HttpContext;
                if (!await this.CheckHandlerAsync(context, httpContext))
                {
                    context.HttpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
                    context.Result = new JsonResult(new AjaxResult(MessageDefinitionType.Uncertified, AjaxResultType.Uncertified));
                    return;

                }
                
            }
        }

        /// <summary>
        /// 验证处理
        /// </summary>
        /// <param name="context"></param>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        protected async Task<bool> CheckHandlerAsync(AuthorizationFilterContext context, HttpContext httpContext)
        {

            var authority=  this._serviceProvider.GetService<IAuthorityService>();
            var action = context.ActionDescriptor as ControllerActionDescriptor;
            var linkurl = context.HttpContext.Request.Path.Value.Replace("/api/", "");
            var result = new AjaxResult(MessageDefinitionType.Unauthorized, AjaxResultType.Unauthorized);
            if (!action.EndpointMetadata.Any(x => x is AllowAnonymousAttribute))
            {
                if (!_principal.Identity.IsAuthenticated)
                {
                    context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    context.Result = new JsonResult(result);
                    return false;
                }
                else
                {
                    if (!action.EndpointMetadata.Any(x => x is NoAuthorityVerificationAttribute))
                    {
                        _logger.LogError($"此{linkurl}地址没有权限");
                        var result1 = (await authority.IsPermission(linkurl.ToLower()));
                        if (result1.Type != AuthResultType.Success)
                        {

                            return false;
                        }
                        else {

                            context.HttpContext.Response.StatusCode = StatusCodes.Status200OK;
                            context.Result = new JsonResult(new AjaxResult("登录成功", AjaxResultType.Success));
                            return true;
                        }
                      
                    }
                }
            }
            return false;
        }



        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            _logger.LogInformation($"进入权限判断");

            var action = context.ActionDescriptor as ControllerActionDescriptor;
            var linkurl = context.HttpContext.Request.Path.Value.Replace("/api/", "");
            var result = new AjaxResult(MessageDefinitionType.Unauthorized, AjaxResultType.Unauthorized);
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
                        var result1 = (await _authority.IsPermission(linkurl.ToLower()));
                        if (!result1.Success)
                        {
                            //????不包含的时候怎么返回出去？这个请求终止掉
                            //
                            _logger.LogError($"此{linkurl}地址没有权限");
 
                            result.Message = MessageDefinitionType.Uncertified;
                            result.Type = AjaxResultType.Uncertified;
                            context.HttpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
                            context.Result = new JsonResult(result);
                            return;
                        }
                    }
                }
            }
            _logger.LogInformation($"权限判断结束");
        }
    }
}
