using Destiny.Core.Flow.Audit;
using Destiny.Core.Flow.Audit.Dto;
using Destiny.Core.Flow.Audit.EntityHistory;
using Destiny.Core.Flow.Audit.Events;
using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Events.EventBus;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Destiny.Core.Flow
{
    public class DefaultDbContext : DbContextBase
    {

        public DefaultDbContext(DbContextOptions<DefaultDbContext> options, IServiceProvider serviceProvider)
          : base(options, serviceProvider)
        {
         
        }



        /// <summary>
        /// 异步保存
        /// </summary>
        /// <param name="cancellationToken"></param> 
        /// <returns></returns>

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            IEnumerable<AuditEntryDto> auditEntitys = new List<AuditEntryDto>();
            IEnumerable<EntityEntry> entityEntry = this.ChangeTracker.Entries();
            if (_option.AuditEnabled)
            {

                auditEntitys = _serviceProvider.GetRequiredService<IAuditHelper>()?.GetAuditEntity(entityEntry);
            }
            int count = await base.SaveChangesAsync(cancellationToken);
            _logger.LogInformation($"成功保存多少条{count}数据");
            if (count > 0 && auditEntitys.Count() > 0)
            {
                var _bus = _serviceProvider.GetService<IEventBus>();
                await _bus.PublishAsync(new AuditEntityEventData() { AuditEntitys = auditEntitys.ToList() });
            }
            return count;
        }

        /// <summary>
        /// 保存更改
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            IEnumerable<AuditEntryDto> auditEntitys = new List<AuditEntryDto>();
            IEnumerable<EntityEntry> entityEntry = this.ChangeTracker.Entries();
            if (_option.AuditEnabled)
            {

                auditEntitys = _serviceProvider.GetRequiredService<IAuditHelper>()?.GetAuditEntity(entityEntry);
            }
            int count = base.SaveChanges();
            _logger.LogInformation($"成功保存多少条{count}数据");
            if (count > 0 && auditEntitys.Count() > 0)
            {
                var _bus = _serviceProvider.GetService<IEventBus>();
                _bus.PublishAsync(new AuditEntityEventData() { AuditEntitys = auditEntitys.ToList() }).GetAwaiter();
            }
            return count;
        }

    }
}