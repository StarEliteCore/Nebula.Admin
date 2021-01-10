using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.IServices.UserRoles;
using Destiny.Core.Flow.Model.Entities.Identity;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Services.UserRoles
{
    /// <summary>
    /// 用户角色
    /// </summary>
    public class UserRoleService : IUserRoleService
    {
        private readonly IRepository<UserRole, Guid> _repositoryUserRole = null;

        private readonly RoleManager<Role> _roleManager = null;

        public UserRoleService(IRepository<UserRole, Guid> repositoryUserRole, RoleManager<Role> roleManager)
        {
            _repositoryUserRole = repositoryUserRole;
            _roleManager = roleManager;
        }

        public IQueryable<UserRole> UserRoles => _repositoryUserRole.Entities;

        public IQueryable<UserRole> TrackUserRoles => _repositoryUserRole.TrackEntities;

        private IQueryable<Role> GetRoleJoinUserRoleByUserId(Guid userId)
        {
            var userRoles = this.UserRoles.Where(ur => ur.UserId == userId);
            var roles = _roleManager.Roles;
            return roles.Join(userRoles, r => r.Id, ur => ur.RoleId, (r, ur) => r);
        }

        /// <summary>
        /// 异步根据用户ID得到角色Id
        /// </summary>
        /// <param name="userId">用户ID</param>
        /// <returns>返回角色Id集合</returns>
        public async Task<Guid[]> GetRoleIdsByUserIdAsync(Guid userId)
        {
            userId.NotEmpty(nameof(userId));
            var roleIds = await this.GetRoleJoinUserRoleByUserId(userId).Select(r => r.Id).ToArrayAsync();
            return roleIds;
        }
    }
}