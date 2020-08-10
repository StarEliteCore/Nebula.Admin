using Destiny.Core.Flow.Caching;
using Destiny.Core.Flow.Events;
using Destiny.Core.Flow.Services.RoleServices.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Destiny.Core.Flow.Extensions;

namespace Destiny.Core.Flow.Services.RoleServices.EventHandlers
{
    public class RoleMenuCacheDeleteHandler : NotificationHandlerBase<RoleMenuEventCacehDeleteEvent>
    {
        private IServiceProvider _serviceProvider = null;
        private ICache _cache = null;
        private ILogger _logger = null;

        public RoleMenuCacheDeleteHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _cache = serviceProvider.GetService<ICache>();
            _logger = serviceProvider.GetLogger<RoleMenuCacheDeleteHandler>();
        }

        public override async Task Handle(RoleMenuEventCacehDeleteEvent notification, CancellationToken cancellationToken)
        {
          await  _cache.RemoveAsync(notification.GetCacheKey());
        }
    }
}
