using Destiny.Core.Flow.Audit;
using Destiny.Core.Flow.Events.EventBus;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Destiny.Core.Flow
{
    public class DefaultDbContext : DbContextBase
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly IEventBus _bus;
        private readonly IGetChangeTracker _changeTracker;

        public DefaultDbContext(DbContextOptions<DefaultDbContext> options, IServiceProvider serviceProvider)
          : base(options, serviceProvider)
        {
            _serviceProvider = serviceProvider;
            _bus = _serviceProvider.GetService<IEventBus>();
            _changeTracker = _serviceProvider.GetService<IGetChangeTracker>();
        }

        /// <summary>
        ///保存更改操作 
        /// </summary>
        /// <returns></returns>

        public override int SaveChanges()
        {
            var auditlist =  _changeTracker.GetChangeTrackerList(this.ChangeTracker.Entries()).GetAwaiter().GetResult();
            var result = base.SaveChanges();
            if (auditlist.Count > 0)
            {
                _bus.PublishAsync(new AuditEvent() { AuditEntries = auditlist }).GetAwaiter();
            }
    
            return result;
        }

        /// <summary>
        ///保存更改操作 
        /// </summary>
        /// <returns></returns>
        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var auditlist = await _changeTracker.GetChangeTrackerList(this.ChangeTracker.Entries());
            var result = await base.SaveChangesAsync(cancellationToken);
            if (auditlist.Count > 0)
            {
                await _bus.PublishAsync(new AuditEvent() { AuditEntries = auditlist });
            }
 
            return result;
        }

        
    }
}