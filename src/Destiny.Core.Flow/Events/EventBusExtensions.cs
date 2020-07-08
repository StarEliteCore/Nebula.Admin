using Destiny.Core.Flow.Events.EventBus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Destiny.Core.Flow.Events
{
  public static  class EventBusExtensions
    {

        public static IServiceCollection AddEvents(this IServiceCollection services)
        {
            services.TryAddSingleton<IEventBus, InMemoryDefaultBus>();
            return services;
        }
    
    }
}
