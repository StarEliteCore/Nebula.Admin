using Destiny.Core.Flow.Events;
using System;

namespace Destiny.Core.Flow.Services.Users.Events
{
    public class UserRoleCacheDeleteEvent : CacheEventDataBase
    {
        public Guid UserId { get; set; }
    }
}