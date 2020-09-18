using Destiny.Core.Flow.Events.Abstractions;
using MediatR;
using Newtonsoft.Json;
using System;

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


        [JsonIgnore]
        public virtual DateTimeOffset EventAt { get; private set; }

        [JsonIgnore]
        public virtual string EventId { get; private set; }
    }
}
