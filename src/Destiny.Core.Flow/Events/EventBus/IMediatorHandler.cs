using System.Threading;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Events.EventBus
{
    /// <summary>
    /// 中介者处理器
    /// </summary>
    public interface IMediatorHandler
    {
        /// <summary>
        ///  发布事件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="event"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task PublishAsync<T>(T @event, CancellationToken cancellationToken = default) where T : EventBase;
    }
}
