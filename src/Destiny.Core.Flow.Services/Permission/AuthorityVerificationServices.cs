using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Model.Entities.Function;
using Destiny.Core.Flow.Model.Entities.Identity;
using Destiny.Core.Flow.Model.Entities.Menu;
using Destiny.Core.Flow.Model.Entities.Rolemenu;
using Destiny.Core.Flow.Permission;
using Destiny.Core.Flow.Security.Identity;
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
            var isAdmin = _principal?.Identity.FindFirst<int>(DestinyCoreFlowClaimTypes.IsAdmin);

            if (isAdmin == 1)
            {
                return true;
            }

         
            if (isAdmin != 1)
            {
                var userRoles = _repositoryUserRole.Entities.Where(o => o.UserId == userId.Value);
                var roleMenus = _roleMenuRepository.Entities.Select(o => new { o.RoleId, o.MenuId });
                var menuIds1 = _menuFuncRepository.Entities.Select(o => new { o.MenuId, o.FunctionId });

                var funcIds = _funcRepository.Entities.Select(o => new { o.Id, o.LinkUrl });

                //是否存在
                var isExistUrl = 
                    await userRoles.
                    Join(roleMenus, ur => ur.RoleId,rm => rm.RoleId, (ur, rm) => new { rm.MenuId }).
                    Join(menuIds1, m => m.MenuId, mf => mf.MenuId, (m, mf) => mf.FunctionId).
                    Join(funcIds, fid => fid, f => f.Id, (fid, f) => f.LinkUrl).AnyAsync(o => o == url); //待优化
                if (!isExistUrl)
                {
                    return false;
                }
                //var roleIds = _repositoryUserRole.Entities.Where(x => x.UserId == userId.Value).Select(x => x.RoleId); //得到用户角色
                //var menuIds = _roleMenuRepository.Entities.Where(rm => roleIds.Contains(rm.RoleId)).Select(o => o.MenuId); //获取MenuId集合;
                //var funcIds = _menuFuncRepository.Entities.Where(mf => menuIds.Contains(mf.MenuId)).Select(o => o.FunctionId); //得到功能Id集合
                //var isExistUrl = await _funcRepository.Entities.AnyAsync(f => funcIds.Contains(f.Id) && f.LinkUrl == url);
                //if (!isExistUrl)
                //{
                //    return false;
                //}

            }
            return true;
        }
    }
}
