using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.EventBus.Abstractions
{
    /// <summary>
    /// 事件数据
    /// </summary>
    public interface IEventData
    {
        /// <summary>
        /// 事件发布时间
        /// </summary>
        DateTime CreationDate { get; }

        /// <summary>
        /// 事件ID
        /// </summary>
        Guid EventId { get;  }

        /// <summary>
        /// 触发事件的对象
        /// </summary>
        object EventSource { get; set; }
    }
}
