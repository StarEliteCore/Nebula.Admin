using Destiny.Core.Flow.Events;
using Destiny.Core.Flow.Events.EventBus;
using Destiny.Core.Flow.Services.RoleServices.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Destiny.Core.Flow.Caching;
using Microsoft.EntityFrameworkCore.Internal;

namespace Destiny.Core.Flow.Services.RoleServices.EventHandlers
{
    public class RoleMenuCacheAddOrUpdateHandler : NotificationHandlerBase<RoleMenuCacheAddOrUpdateEvent>
    {

        private IServiceProvider _serviceProvider = null;
        private ICache _cache = null;
        public RoleMenuCacheAddOrUpdateHandler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _cache = serviceProvider.GetService<ICache>();

        }
        public override async Task Handle(RoleMenuCacheAddOrUpdateEvent notification, CancellationToken cancellationToken)
        {
   
            var key = notification.GetCacheKey();
            RoleMenuItem roleMenuItem = new RoleMenuItem();
            roleMenuItem.RoleId = notification.RoleId;
            roleMenuItem.MenuIds = notification.MenuIds;

            if (notification.IsAdd)
            {
                await _cache.SetAsync(key, roleMenuItem);
            }
            else {

                await _cache.RemoveAsync(key);
                await _cache.SetAsync(key, roleMenuItem);
            }

        }

        internal class RoleMenuItem
        {
            public Guid RoleId { get; set; }



            public IEnumerable<Guid> MenuIds { get; set; }
        }
    }



 
}
