using AspectCore.DynamicProxy;
using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.EventBus;
using Destiny.Core.Flow.EventBus.Abstractions;
using Destiny.Core.Flow.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Destiny.Core.Tests
{

    public  class EventBusTest
    {
        private readonly IServiceCollection _service = null;
        public EventBusTest()
        {
            _service = new ServiceCollection();
        }

        [Fact]
        public void Test_EventBus()
        {
            _service.AddSingleton<IEventBus, EventBus>();
            _service.AddSingleton<IEventStore, InMemoryEventStore>();


            var bus=  _service.GetService<IEventBus>();
            bus.Subscribe<TestEvent, TestEventHandler>();
            bus.PublishAsync(new TestEvent() { Name="大黄瓜"});
        }

    }

    public class TestEvent : EventDataBase
    { 
       public string Name { get; set; }
    
    }



    public class TestEventHandler : IEventHandler<TestEvent>
    {
        public async Task HandleAsync(TestEvent eventData)
        {

            await Task.CompletedTask;
        }
    }

 
}
