using Destiny.Core.Flow.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Services.Users.Events
{
    [CacheKey(UserCacheKeys.userRoleKeyPrefix)]
    public class UserRoleCacheDeleteEvent : CacheEventDataBase
    {
 

    }
}
