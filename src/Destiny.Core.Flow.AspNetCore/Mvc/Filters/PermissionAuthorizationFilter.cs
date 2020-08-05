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
using Destiny.Core.Flow.Caching;

namespace Destiny.Core.Flow.AspNetCore.Mvc.Filters
{
    /// <summary>
    /// 好像3.1不能这样用了，是用策略
    /// </summary>
    public class PermissionAuthorizationFilter : IAsyncAuthorizationFilter
    {
        private readonly IPrincipal _principal;
        private readonly IEFCoreRepository<UserRole, Guid> _repositoryUserRole = null;
        private readonly IEFCoreRepository<RoleMenuEntity,Guid> _roleMenuRepository=null;
        private readonly IEFCoreRepository<MenuFunction, Guid> _menuFuncRepository = null;
        private readonly IEFCoreRepository<Function, Guid> _funcRepository = null;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private ICache _cache1 = null;
        public PermissionAuthorizationFilter(IPrincipal principal, IEFCoreRepository<UserRole, Guid> repositoryUserRole, IEFCoreRepository<RoleMenuEntity, Guid> roleMenuRepository
            , IEFCoreRepository<MenuFunction, Guid> menuFuncRepository, IEFCoreRepository<Function, Guid> funcRepository, UserManager<User> userManager, RoleManager<Role> roleManager, ICache cache1

            )
        {
            _principal = principal;
            _repositoryUserRole = repositoryUserRole;
            _roleMenuRepository = roleMenuRepository;
            _menuFuncRepository = menuFuncRepository;
            _funcRepository = funcRepository;
            _userManager = userManager;
            _roleManager = roleManager;
            _cache1 = cache1;
        }

        public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
        {
            var action= context.ActionDescriptor as ControllerActionDescriptor;
            var isAllowAnonymous = action.ControllerTypeInfo.GetCustomAttribute<AllowAnonymousAttribute>();//获取Action中的特性
            var linkurl= context.HttpContext.Request.Path.Value.Replace("/api/", "");
            var result = new AjaxResult(MessageDefinitionType.Unauthorized, Enums.AjaxResultType.Unauthorized);
            //_cache1.Get <>
            if (!action .EndpointMetadata.Any(x=>x is AllowAnonymousAttribute))
            {
                if (!_principal.Identity.IsAuthenticated)
                {
                    context.HttpContext.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    context.Result = new JsonResult(result);
                    return;
                }
                var Id = _principal?.Identity.GetUesrId<Guid>();//获取登录用户Id 
                var role = await _repositoryUserRole.Entities.Where(x => x.UserId == Id.Value).Select(x => x.RoleId).ToListAsync();//获取用户角色
                var menu=await _roleMenuRepository.Entities.Where(x => role.Contains(x.RoleId)).Select(x => x.MenuId).ToListAsync();//获取MenuId
                var funcId= await _menuFuncRepository.Entities.Where(x => menu.Contains(x.MenuId)).Select(x => x.FunctionId).ToListAsync();//获取functionId
                var funclist = await _funcRepository.Entities.Where(x => funcId.Contains(x.Id)).Select(x => x.LinkUrl).ToListAsync();//获取Function列表
                var user = await _userManager.FindByIdAsync(Id.ToString());//获取用户
                var IsadminRole=await  _roleManager.Roles.Where(x => x.IsAdmin == true && role.Contains(x.Id)).ToListAsync();//获取带有管理员权限的角色 
                if (!user.IsSystem && !IsadminRole.Any())
                {
                    if (!funclist.Contains(linkurl))
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


    //public class AA : IActionFilter
    //{
    //    public void OnActionExecuted(ActionExecutedContext context)
    //    {
           
    //    }

    //    public void OnActionExecuting(ActionExecutingContext context)
    //    {
            
    //    }
    //}
}
