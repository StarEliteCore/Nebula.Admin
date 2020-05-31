using Destiny.Core.Flow.EventBus.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Destiny.Core.Flow.Extensions;
using System.Linq;

namespace Destiny.Core.Flow.EventBus
{
    public  class EventBus : IEventBus
    {
  
        private readonly IServiceProvider _serviceProvider;

        private readonly IEventStore _eventStore;

        public EventBus(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _eventStore = _serviceProvider.GetService<IEventStore>();
        }



        public async Task PublishAsync<TEvent>(TEvent @event) where TEvent : IEventData
        {
            _eventStore.NotNull("_eventStore");
            @event.NotNull("@event");
            var eventHandlerTypes = _eventStore.GetEventHandlerTtyps<TEvent>().ToList();

            foreach (var eventHandler in eventHandlerTypes)
            {

                var handler= _serviceProvider.GetServiceOrCreateInstance(eventHandler) as IEventHandler<TEvent>;
                if (handler.IsNotNull())
                {
                   await handler.HandleAsync(@event);
                }
     
            }
        }

   

        public void Subscribe<TEvent, TEventHandler>()
            where TEvent : IEventData
            where TEventHandler : IEventHandler<TEvent>, new()
        {
            _eventStore.NotNull("_eventStore");
            _eventStore.AddSubscribe<TEvent, TEventHandler>();
        }

        public void UnSubscribe<TEvent, TEventHandler>()
            where TEvent : IEventData
            where TEventHandler : IEventHandler<TEvent>, new()
        {

            _eventStore.NotNull("_eventStore");
            _eventStore.RemoveSubscribe<TEvent, TEventHandler>();
        }
    }
}
