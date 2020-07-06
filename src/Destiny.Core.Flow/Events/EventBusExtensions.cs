using Destiny.Core.Flow.Events.EventBus;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Destiny.Core.Flow.Events
{
  public static  class EventBusExtensions
    {

        public static IServiceCollection AddEventBusDefaults(this IServiceCollection services,params Assembly[] assemblies)
        {
            services.AddMediatR(assemblies);
            services.AddScoped<IEventBus, InMemoryDefaultBus>();
            return services;
        }
    }
}
