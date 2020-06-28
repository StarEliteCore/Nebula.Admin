using Destiny.Core.Flow.Dependency;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Permission
{
    [Dependency(ServiceLifetime.Scoped)]
    public class PermissionHandler : AuthorizationHandler<PermissionDto>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionDto requirement)
        {
            throw new NotImplementedException();
        }
    }
}
