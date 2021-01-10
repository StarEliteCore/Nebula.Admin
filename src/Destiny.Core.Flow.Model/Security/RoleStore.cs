using Destiny.Core.Flow.Identity;
using Destiny.Core.Flow.Model.Entities.Identity;
using System;

namespace Destiny.Core.Flow.Model.Security
{
    public class RoleStore : RoleStoreBase<Role, Guid, RoleClaim>
    {
        public RoleStore(IRepository<Role, Guid> roleRepository, IRepository<RoleClaim, Guid> roleClaimRepository)
            : base(roleRepository, roleClaimRepository)
        { }
    }
}