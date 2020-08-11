using Destiny.Core.Flow.Events;
using Destiny.Core.Flow.Model.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Services.Users.Events
{
   public class UserRoleCacheAddOrUpdateEvent : Notification
    {
        //应该用DTO
        public User User { get; set; }
        public bool IsAdd { get; set; } = true;
        public IEnumerable<Role> Roles { get; set; }

        public override string GetCacheKey()
        {

            return $"{UserCacheKeys.userRoleKeyPrefix}{User.Id}";
        }
    }
}
