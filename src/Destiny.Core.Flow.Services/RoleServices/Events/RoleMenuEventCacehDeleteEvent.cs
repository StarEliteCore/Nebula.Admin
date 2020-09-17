using Destiny.Core.Flow.Events;
using System;

namespace Destiny.Core.Flow.Services.RoleServices.Events
{
    public class RoleMenuEventCacehDeleteEvent : CacheEventDataBase
    {
        public Guid RoleId { get; set; }
    }
}