using Destiny.Core.Flow.Events;
using Destiny.Core.Flow.Events.EventBus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;
using Destiny.Core.Flow.Helpers;

namespace Destiny.Core.Tests
{

   public class MediatRTest
    {
        private IServiceCollection _services = null;

        public MediatRTest()
        {
            _services = new ServiceCollection();

        }

        [Fact]
        public void TestEvent()
        {
            _services.AddMediatR(typeof(MediatRTest).GetTypeInfo().Assembly);
            _services.AddScoped<IEventBus, InMemoryDefaultBus>();
            var bus=  _services.BuildServiceProvider().GetRequiredService<IEventBus>();
            var test = new TestEvent() { Name = "大黄瓜" };
            bus.PublishAsync(test).GetAwaiter();
            var eventDataJson = test.ToJson();
            var @event = eventDataJson.FromJson<TestEvent>();
            Assert.Equal(test.Name, @event.Name);
        }

    }




    public class TestEvent : EventBase
    { 
       public string Name { get; set; }
    }


    public class EventHandler : NotificationHandlerBase<TestEvent>
    {
        public override Task Handle(TestEvent @event, CancellationToken cancellationToken=default)
        {
            var name=   @event.Name;
            return Task.CompletedTask;
        }
    }
}
