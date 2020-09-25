using IdentityServer4.Models;
using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.IdentityServer.Validation
{
    public class DestinyProfileService : IProfileService
    {
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            await Task.CompletedTask;
            var claims = new List<Claim>();
            claims.Add(new Claim("Isadmin", "1245"));
            context.IssuedClaims.AddRange(claims);
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            await Task.CompletedTask;
            context.IsActive = true;
        }
    }
}
