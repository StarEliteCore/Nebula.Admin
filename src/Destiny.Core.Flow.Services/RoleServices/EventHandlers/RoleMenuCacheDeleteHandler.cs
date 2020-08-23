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
    public class RoleMenuCacheDeleteHandler : CacheHandlerBase<RoleMenuEventCacehDeleteEvent>
    {
        private IServiceProvider _serviceProvider = null;


        public RoleMenuCacheDeleteHandler(IServiceProvider serviceProvider, ICache cache):base(cache)
        {
            _serviceProvider = serviceProvider;
           
        }

        public override async Task Handle(RoleMenuEventCacehDeleteEvent notification, CancellationToken cancellationToken)
        {
            var key = $"{CacheKeys.roleMenuKeyPrefix}{notification.RoleId}";
          await  _cache.RemoveAsync(key);
        }
    }
}
