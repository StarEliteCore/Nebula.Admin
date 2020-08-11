using Destiny.Core.Flow.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Services.Users.Events
{
    public class UserRoleCacheDeleteEvent : Notification
    {
        public Guid UserId { get; set; }
    

        public override string GetCacheKey()
        {

            return $"{UserCacheKeys.userRoleKeyPrefix}{UserId}";
        }
    }
}
