using Destiny.Core.Flow.Events.Abstractions;
using System.Threading;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Events
{
    public abstract class EventHandlerBase<TEvent> : IEventHandlerBase<TEvent> where TEvent : class, IEventBase
    {
        public abstract Task Handle(TEvent eventData, CancellationToken cancellationToken);
    }
}
