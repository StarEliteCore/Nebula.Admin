using System.Threading;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Events.Abstractions
{
    public interface IEventHandlerBase<in TEvent> where TEvent : class, IEventBase
    {

        Task Handle(TEvent notification, CancellationToken cancellationToken);

    }
}
