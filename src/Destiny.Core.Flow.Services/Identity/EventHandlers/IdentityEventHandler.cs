using Destiny.Core.Flow.Caching;
using Destiny.Core.Flow.Events;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Helpers;
using Destiny.Core.Flow.Services.Identity.Events;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Services.Identity.EventHandlers
{
    public class IdentityEventHandler : NotificationHandlerBase<IdentityEvent>
    {
        private IServiceProvider _serviceProvider = null;
        private readonly ILogger _logger = null;
        private readonly ICache _cache = null;

        public IdentityEventHandler(IServiceProvider serviceProvider, ICache cache)
        {
            _serviceProvider = serviceProvider;
            _logger = serviceProvider.GetLogger<IdentityEventHandler>();
            _cache = cache;
        }

        public override Task Handle(IdentityEvent @event, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"事件信息:{@event.ToJson()}");

            return Task.CompletedTask;
        }
    }
}