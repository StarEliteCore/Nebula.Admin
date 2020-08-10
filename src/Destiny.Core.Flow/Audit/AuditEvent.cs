using Destiny.Core.Flow.Events;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Audit
{
    /// <summary>
    /// 日志审计事件定义
    /// </summary>
    public class AuditEvent: EventBase
    {
        public IEnumerable<EntityEntry> Entries { get; set; }
    }
}
