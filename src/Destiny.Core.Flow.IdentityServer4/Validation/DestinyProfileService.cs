using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Model.Entities.Identity;
using Destiny.Core.Flow.Security.Identity;
using IdentityServer4.Extensions;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.IdentityServer.Validation
{
    public class DestinyProfileService : IProfileService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
        private readonly IEFCoreRepository<UserRole, Guid> _userRoleRepository;

        public DestinyProfileService(UserManager<User> userManager, RoleManager<Role> roleManager, IEFCoreRepository<UserRole, Guid> userRoleRepository)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _userRoleRepository = userRoleRepository;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            var userId = context.Subject.Identity.GetSubjectId();  //为什么请求第二次为空？
            if (!userId.IsNullOrEmpty())
            {
                var user = await _userManager.FindByIdAsync(userId);
                var roles = await _userManager.GetRolesAsync(user);
                var isAdmin = await _roleManager.Roles.Where(o => roles.Contains(o.Name) && o.IsAdmin == true).AnyAsync();
                Claim[] claims =
                {
                new Claim(DestinyCoreFlowClaimTypes.UserName, user.UserName),
                new Claim(DestinyCoreFlowClaimTypes.NickName, user.NickName),
                new Claim(DestinyCoreFlowClaimTypes.IsAdmin,(user.IsSystem&&isAdmin?"1":"0")),
                new Claim(DestinyCoreFlowClaimTypes.RoleId,string.Join(",", (await _userRoleRepository.Entities.Where(x => x.UserId == user.Id).Select(x => x.RoleId).ToListAsync())))
                };
                context.IssuedClaims.AddRange(claims);
            }
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            context.IsActive = true;
            await Task.CompletedTask;
        }
    }
}
