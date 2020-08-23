using Destiny.Core.Flow.Caching;
using Destiny.Core.Flow.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Services.RoleServices.Events
{

    public   class RoleMenuCacheAddOrUpdateEvent : CacheEventDataBase
    {

        public Guid RoleId { get; set; }


        
        public IEnumerable<Guid> MenuIds { get; set; }

     
    }
}
