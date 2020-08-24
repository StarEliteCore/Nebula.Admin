using Destiny.Core.Flow.Caching;
using Destiny.Core.Flow.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Services.Users.Events
{

    public class UserRoleCacheDeleteEvent : CacheEventDataBase
    {
 
        public Guid UserId { get; set; }
    }
}
