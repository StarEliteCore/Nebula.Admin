using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.EventBus.Abstractions
{
    /// <summary>
    /// 事件总线，用来管理发布/订阅/取消订阅事件，将事件的某个IEventHandler保存到EventStore 
    /// </summary>
    public interface IEventBus
    {


        /// <summary>
        /// 订阅事件
        /// </summary>
        /// <typeparam name="TEvent">事件数据</typeparam>
        /// <typeparam name="TEventHandler">事件处理</typeparam>
        void Subscribe<TEvent, TEventHandler>()
            where TEvent : IEventData
            where TEventHandler : IEventHandler<TEvent>, new();

        /// <summary>
        /// 取消订阅事件
        /// </summary>
        /// <typeparam name="TEvent"></typeparam>
        /// <typeparam name="TEventHandler"></typeparam>
        void UnSubscribe<TEvent, TEventHandler>()
            where TEvent : IEventData
            where TEventHandler : IEventHandler<TEvent>, new();

        /// <summary>
        /// 异步发布
        /// </summary>
        /// <typeparam name="TEvent"></typeparam>
        /// <param name="event"></param>
        /// <returns></returns>
        Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEventData;


 
    }
}
