using Destiny.Core.Flow.EventBus.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.EventBus
{
    public abstract class EventDataBase : IEventData
    {

        protected EventDataBase()
        {
            CreationDate = DateTime.Now;
            EventId =Guid.NewGuid();
        }
        public DateTime CreationDate { get; set; }

        public Guid EventId { get; set; }

        public object EventSource { get; set; }
    }
}
