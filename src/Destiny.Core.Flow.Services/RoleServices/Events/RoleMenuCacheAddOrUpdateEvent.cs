using Destiny.Core.Flow.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Services.RoleServices.Events
{
    public   class RoleMenuCacheAddOrUpdateEvent : Notification
    {

        public Guid RoleId { get; set; }


        
        public IEnumerable<Guid> MenuIds { get; set; }

        public bool IsAdd { get; set; } = true;


        public override string GetCacheKey() {

            return $"{CacheKeys.roleMenuKeyPrefix}{RoleId}";
        }
    }
}
