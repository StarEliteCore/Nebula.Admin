using Destiny.Core.Flow.Model.Entities.Identity;
using IdentityServer4.Models;
using IdentityServer4.Services;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Security.Identity;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Destiny.Core.Flow.IdentityServer.Validation
{
    public class DestinyProfileService : IProfileService
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;
 

        public DestinyProfileService(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            
            var userId = context.Subject.Identity.GetIdentityServer4SubjectId();  //为什么请求第二次为空？
            if (!userId.IsNullOrEmpty())
            {
                var user = await _userManager.FindByIdAsync(userId);
                var roles = await _userManager.GetRolesAsync(user);
                var isAdmin = await _roleManager.Roles.Where(o => roles.Contains(o.Name) && o.IsAdmin == true).AnyAsync();
                Claim[] claims =
                {
                new Claim("name", user.UserName),
                new Claim(ClaimTypes.GivenName, user.NickName),
                new Claim(DestinyCoreFlowClaimTypes.IsAdmin,(user.IsSystem&&isAdmin?"1":"0")),
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
