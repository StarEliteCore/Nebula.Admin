using Destiny.Core.Flow.Audit.Dto;
using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Options;
using Destiny.Core.Flow.Reflection;
using DnsClient.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Destiny.Core.Flow.Audit.EntityHistory;
using Destiny.Core.Flow.Events.EventBus;
using Destiny.Core.Flow.Audit.Events;
using Destiny.Core.Flow.Dependency;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Destiny.Core.Flow
{
    /// <summary>
    /// 上下文基类
    /// </summary>
    public abstract class DbContextBase : DbContext
    {
        private readonly IServiceProvider _serviceProvider = null;
        private readonly AppOptionSettings _option = null;
        private readonly Microsoft.Extensions.Logging.ILogger _logger = null;

        protected DbContextBase(DbContextOptions options, IServiceProvider serviceProvider)
             : base(options)
        {
            _serviceProvider = serviceProvider;
            _option = serviceProvider.GetService<IObjectAccessor<AppOptionSettings>>()?.Value;


            _logger = serviceProvider.GetLogger(GetType());
        }

        public IUnitOfWork UnitOfWork { get; set; }

        protected virtual Task BeforeSaveChanges() => Task.CompletedTask;

        protected virtual Task AfterSaveChanges() => Task.CompletedTask;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var typeFinder = _serviceProvider.GetService<ITypeFinder>();

            IEntityMappingConfiguration[] mappings = typeFinder.Find(o => o.IsDeriveClassFrom<IEntityMappingConfiguration>()).Select(o => Activator.CreateInstance(o) as IEntityMappingConfiguration).ToArray();
            foreach (var item in mappings)
            {
                item.Map(modelBuilder);
            }
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
                var _bus= _serviceProvider.GetService<IEventBus>();
                await _bus.PublishAsync(new AuditEntityEventData() { AuditEntitys= auditEntitys.ToList() });
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
            int count= base.SaveChanges();
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