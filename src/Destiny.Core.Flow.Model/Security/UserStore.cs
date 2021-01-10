using Destiny.Core.Flow.Identity;
using Destiny.Core.Flow.Model.Entities.Identity;
using System;

namespace Destiny.Core.Flow.Model.Security
{
    public class UserStore : UserStoreBase<User, Guid, UserClaim, UserLogin, UserToken, Role, Guid, UserRole>
    {
        public UserStore(

            IRepository<User, Guid> userRepository,
            IRepository<UserLogin, Guid> userLoginRepository,
            IRepository<UserClaim, Guid> userClaimRepository,
            IRepository<UserToken, Guid> userTokenRepository,
            IRepository<Role, Guid> roleRepository,
            IRepository<UserRole, Guid> userRoleRepository)
            : base(userRepository, userLoginRepository, userClaimRepository, userTokenRepository, roleRepository, userRoleRepository)
        {
        }
    }
}