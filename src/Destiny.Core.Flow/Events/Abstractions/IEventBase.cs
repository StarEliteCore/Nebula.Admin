using System;

namespace Destiny.Core.Flow.Events.Abstractions
{
    /// <summary>
    /// 事件基类
    /// </summary>
    public interface IEventBase
    {   /// <summary>
        /// 事件发布时间
        /// </summary>
        DateTimeOffset EventAt { get; }

        /// <summary>
        /// 事件ID
        /// </summary>
        string EventId { get; }


    }
}
