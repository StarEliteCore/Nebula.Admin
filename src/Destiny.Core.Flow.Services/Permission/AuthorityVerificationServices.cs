using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Model.Entities.Function;
using Destiny.Core.Flow.Model.Entities.Identity;
using Destiny.Core.Flow.Model.Entities.Menu;
using Destiny.Core.Flow.Model.Entities.Rolemenu;
using Destiny.Core.Flow.Permission;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Services.Permission
{
    /// <summary>
    /// 登录账号访问接口权限验证
    /// </summary>
    public class AuthorityVerificationServices : IAuthorityVerification
    {
        private readonly IPrincipal _principal;
        private readonly IEFCoreRepository<UserRole, Guid> _repositoryUserRole = null;
        private readonly IEFCoreRepository<RoleMenuEntity, Guid> _roleMenuRepository = null;
        private readonly IEFCoreRepository<MenuFunction, Guid> _menuFuncRepository = null;
        private readonly IEFCoreRepository<Function, Guid> _funcRepository = null;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public AuthorityVerificationServices(IPrincipal principal, IEFCoreRepository<UserRole, Guid> repositoryUserRole, IEFCoreRepository<RoleMenuEntity, Guid> roleMenuRepository, IEFCoreRepository<MenuFunction, Guid> menuFuncRepository, IEFCoreRepository<Function, Guid> funcRepository, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _principal = principal;
            _repositoryUserRole = repositoryUserRole;
            _roleMenuRepository = roleMenuRepository;
            _menuFuncRepository = menuFuncRepository;
            _funcRepository = funcRepository;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        /// <summary>
        /// 判断用户是否有访问接口的权限
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<bool> IsPermission(string url)
        {
            var userId = _principal?.Identity.GetUesrId<Guid>();//获取登录用户Id
            var roleIds = _repositoryUserRole.Entities.Where(x => x.UserId == userId.Value).Select(x => x.RoleId); //得到用户角色
            var menuIds = _roleMenuRepository.Entities.Where(rm => roleIds.Contains(rm.RoleId)).Select(o => o.MenuId); //获取MenuId集合;
            var funcIds = _menuFuncRepository.Entities.Where(mf => menuIds.Contains(mf.MenuId)).Select(o => o.FunctionId); //得到功能Id集合
       
            var user = await _userManager.FindByIdAsync(userId.ToString());//获取用户
            var isAdminRole = await _roleManager.Roles.Where(x => x.IsAdmin == true && roleIds.Contains(x.Id)).ToListAsync();//获取带有管理员权限的角色
            if (!user.IsSystem || !isAdminRole.Any())
            {
                var isExistUrl =await _funcRepository.Entities.Where(f => funcIds.Contains(f.Id) && f.LinkUrl == url).AnyAsync();
                if (!isExistUrl)
                {
                    return false;
                }
  
            }
            return true;
            //var role = await _repositoryUserRole.Entities.Where(x => x.UserId == userId.Value).Select(x => x.RoleId).ToListAsync();//获取用户角色
            //var menu = await _roleMenuRepository.Entities.Where(x => role.Contains(x.RoleId)).Select(x => x.MenuId).ToListAsync();//获取MenuId
            //var funcId = await _menuFuncRepository.Entities.Where(x => menu.Contains(x.MenuId)).Select(x => x.FunctionId).ToListAsync();//获取functionId
            //var funclist = await _funcRepository.Entities.Where(x => funcId.Contains(x.Id)).Select(x => x.LinkUrl).ToListAsync();//获取Function列表
            //var user = await _userManager.FindByIdAsync(userId.ToString());//获取用户
            //var IsadminRole = await _roleManager.Roles.Where(x => x.IsAdmin == true && role.Contains(x.Id)).ToListAsync();//获取带有管理员权限的角色
            //if (!user.IsSystem && !IsadminRole.Any())
            //{
            //    if (!funclist.Contains(url))
            //    {
            //        return false;
            //    }
            //}
            //return true;
        }
    }
}
