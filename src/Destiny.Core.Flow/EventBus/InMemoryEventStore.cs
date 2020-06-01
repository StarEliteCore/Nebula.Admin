using Destiny.Core.Flow.EventBus.Abstractions;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.EventBus
{
    public class InMemoryEventStore : IEventStore
    {

        private readonly ConcurrentDictionary<Type, List<Type>> _handlerList;

        public InMemoryEventStore()
        {
            _handlerList = new ConcurrentDictionary<Type, List<Type>>();
        }
        public void AddSubscribe<TEvent, TEventHandler>()
            where TEvent : IEventData
            where TEventHandler : IEventHandler<TEvent>, new()
        {
            var type = GetEventType<TEvent>();

            _handlerList.GetOrAdd(type, new List<Type> { typeof(TEventHandler) });
    
        }

 
  

        public Type GetEventType<TEvent>()
        {

            return typeof(TEvent);
        }

        public void RemoveSubscribe<TEvent, TEventHandler>()
            where TEvent : IEventData
            where TEventHandler : IEventHandler<TEvent>, new()
        {
            var type = GetEventType<TEvent>();
            if (HasSubscribeForEvent(type))
            {
                _handlerList[type].RemoveAll(o=>o==typeof(TEventHandler));
            }
        }

        /// <summary>
        /// 已订阅事件
        /// </summary>
        /// <param name="eventData">事件数据类型</param>
        /// <returns></returns>

        public bool HasSubscribeForEvent(Type eventData)
        {
            return _handlerList.ContainsKey(eventData);
        }

        public List<Type> GetEventHandlerTtyps<TEventData>() where TEventData : IEventData
        {
            if (!_handlerList.Any())
            {
                return new List<Type>();
            }
            var type = GetEventType<TEventData>();
            _handlerList.TryGetValue(type, out List<Type> types);
            return types;
        }
    }
}
