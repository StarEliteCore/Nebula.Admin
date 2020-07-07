using Destiny.Core.Flow.Events.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Destiny.Core.Flow.Events
{
    public abstract class EventBase : IEventBase, INotification
    {

        protected EventBase()
        {
            EventAt = DateTimeOffset.UtcNow;
            EventId = Guid.NewGuid().ToString();
        }

        protected EventBase(string eventId)
        {
            EventId = eventId;
            EventAt = DateTimeOffset.UtcNow;
        }


        public EventBase(string eventId, DateTimeOffset eventAt)
        {
            EventId = eventId;
            EventAt = eventAt;
        }
        public DateTimeOffset EventAt { get; private set; }

        public string EventId { get; private set; }
    }
}
