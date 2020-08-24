using Destiny.Core.Flow.Caching;
using Destiny.Core.Flow.Events;
using Destiny.Core.Flow.Model.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Services.Users.Events
{

   public class UserRoleCacheAddOrUpdateEvent : CacheEventDataBase
    {
        //应该用DTO
        public User User { get; set; }
        public IEnumerable<Role> Roles { get; set; }

    
    }
}
