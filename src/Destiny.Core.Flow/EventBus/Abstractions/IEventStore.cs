using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.EventBus.Abstractions
{
    /// <summary>
    /// 所有事件存储，保存事件的IEventHandler
    /// </summary>
    public interface  IEventStore
    {

        /// <summary>
        /// 添加订阅
        /// </summary>
        /// <typeparam name="TEvent">事件数据类型</typeparam>
        /// <typeparam name="TEventHandler">事件处理类型</typeparam>
        void AddSubscribe<TEvent, TEventHandler>()
            where TEvent : IEventData
            where TEventHandler : IEventHandler<TEvent>, new();

        /// <summary>
        /// 删除订阅
        /// </summary>
        /// <typeparam name="TEvent">事件数据类型</typeparam>
        /// <typeparam name="TEventHandler">事件处理类型</typeparam>
        void RemoveSubscribe<TEvent, TEventHandler>()
            where TEvent : IEventData
            where TEventHandler : IEventHandler<TEvent>, new();


        /// <summary>
        /// 得到事件键
        /// </summary>
        /// <typeparam name="TEvent"></typeparam>
        /// <returns></returns>
        Type GetEventType<TEvent>();

        /// <summary>
        /// 已订阅事件
        /// </summary>
        /// <param name="eventData">事件数据类型</param>
        /// <returns></returns>

        bool HasSubscribeForEvent(Type eventData);

        List<Type> GetEventHandlerTtyps<TEventData>() where TEventData : IEventData;

    }
}
