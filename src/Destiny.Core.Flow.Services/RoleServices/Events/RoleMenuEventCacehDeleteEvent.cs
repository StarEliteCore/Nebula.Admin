using Destiny.Core.Flow.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Services.RoleServices.Events
{
    public class RoleMenuEventCacehDeleteEvent : Notification
    {
        public Guid RoleId { get; set; }

        public override string GetCacheKey()
        {

            return $"{CacheKeys.roleMenuKeyPrefix}{RoleId}";
        }
    }
}
