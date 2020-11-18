using Destiny.Core.Flow.Audit.Dto;
using Destiny.Core.Flow.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Audit.Events
{
    public class AuditEntityEventData : EventBase
    {

        public List<AuditEntryDto> AuditEntitys { get; set; }
    }
}
