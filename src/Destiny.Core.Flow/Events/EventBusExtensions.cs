using Destiny.Core.Flow.Events.EventBus;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace Destiny.Core.Flow.Events
{
    public static class EventBusExtensions
    {

        public static IServiceCollection AddEvents(this IServiceCollection services)
        {
          
            return services;
        }

    }
}
