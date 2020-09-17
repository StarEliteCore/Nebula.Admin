using Destiny.Core.Flow.Events;
using System.Collections.Generic;

namespace Destiny.Core.Flow.Audit
{
    /// <summary>
    /// 日志审计事件定义
    /// </summary>
    public class AuditEvent : EventBase
    {
        public List<AuditEntryInputDto> AuditEntries { get; set; }
    }
}