using Destiny.Core.Flow.Identity;
using Destiny.Core.Flow.Model.Entities.Identity;
using System;

namespace Destiny.Core.Flow.Model.Security
{
    public class UserStore : UserStoreBase<User, Guid, UserClaim, UserLogin, UserToken, Role, Guid, UserRole>
    {
        public UserStore(

            IEFCoreRepository<User, Guid> userRepository,
            IEFCoreRepository<UserLogin, Guid> userLoginRepository,
            IEFCoreRepository<UserClaim, Guid> userClaimRepository,
            IEFCoreRepository<UserToken, Guid> userTokenRepository,
            IEFCoreRepository<Role, Guid> roleRepository,
            IEFCoreRepository<UserRole, Guid> userRoleRepository)
            : base(userRepository, userLoginRepository, userClaimRepository, userTokenRepository, roleRepository, userRoleRepository)
        {
        }
    }
}