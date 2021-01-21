using Destiny.Core.Flow.Audit.Dto;
using Destiny.Core.Flow.Audit.EntityHistory;
using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Options;
using Destiny.Core.Flow.Reflection;
using DnsClient.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace Destiny.Core.Flow
{

    /// <summary>
    /// 上下文基类
    /// </summary>
    public abstract class DbContextBase : DbContext
    {
        protected readonly IServiceProvider _serviceProvider = null;
        protected readonly AppOptionSettings _option = null;
        protected readonly Microsoft.Extensions.Logging.ILogger _logger = null;
        private readonly IPrincipal _principal;
        protected DbContextBase(DbContextOptions options, IServiceProvider serviceProvider)
             : base(options)
        {
            _serviceProvider = serviceProvider;
            _option = serviceProvider.GetService<IObjectAccessor<AppOptionSettings>>()?.Value;
            _logger = serviceProvider.GetLogger(GetType());
            _principal = serviceProvider.GetService<IPrincipal>();

        }

        public IUnitOfWork UnitOfWork { get; set; }



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
            ApplyConcepts();
            var result = OnBeforeSaveChanges();
            int count = await base.SaveChangesAsync(cancellationToken);
            _logger.LogInformation($"成功保存{count}条数据");
            return count;
        }
        protected virtual void ApplyConcepts()
        {
            var entries = this.FindChangedEntries().ToList();
            foreach (var entity in entries)
            {
                if (entity.Entity is ICreationAudited<Guid> createdTime && entity.State == EntityState.Added)
                {
                    createdTime.CreatedTime = DateTime.Now;
                    createdTime.CreatorUserId = _principal.Identity.GetUesrId<Guid>();
                }
                if (entity.Entity is IModificationAudited<Guid> ModificationAuditedUserId && entity.State == EntityState.Modified)
                {
                    ModificationAuditedUserId.LastModifionTime = DateTime.Now;
                    ModificationAuditedUserId.LastModifierUserId = _principal.Identity.GetUesrId<Guid>();
                }
            }
        }

        protected virtual void OnCompleted(int count, object sender)
        {

            if (_option.AuditEnabled)
            {
                if (count > 0 && sender != null && sender is List<AuditEntryDto> senders)
                {
                    var scoped = _serviceProvider.GetService<DictionaryScoped>();
                    var auditChange = scoped.AuditChange;
                    if (auditChange != null)
                    {
                        auditChange.AuditEntitys.AddRange(senders);
                    }


                }
            }
            _logger.LogInformation($"进入保存更新成功方法");
        }
        protected virtual object OnBeforeSaveChanges()
        {
            _logger.LogInformation($"进入开始保存更改方法");
            return GetAuditEntitys();
        }


        protected virtual IEnumerable<AuditEntryDto> GetAuditEntitys()
        {
            if (!_option.AuditEnabled)
            {
                return null;
            }
            IEnumerable<EntityEntry> entityEntry = FindChangedEntries();
            return _serviceProvider.GetRequiredService<IAuditHelper>()?.GetAuditEntity(entityEntry);

        }
        /// <summary>
        /// 保存更改
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            ApplyConcepts();
            var result = OnBeforeSaveChanges();
            int count = base.SaveChanges();
            _logger.LogInformation($"成功保存{count}条数据");
            OnAfterSaveChanges();
            OnCompleted(count, result);
            return count;
        }
        /// <summary>
        /// 结束保存
        /// </summary>
        protected virtual void OnAfterSaveChanges()
        {

            _logger.LogInformation($"进入结束保存更改");
        }

        protected virtual IReadOnlyList<EntityEntry> FindChangedEntries()
        {
            return this.ChangeTracker.Entries()
                .Where(x =>
                    x.State == EntityState.Added ||
                    x.State == EntityState.Modified ||
                    x.State == EntityState.Deleted)
                .ToList();
        }

        protected virtual bool HasCreationAuditedIdProperty(EntityEntry entity)
        {
            return entity.GetType().GetProperty(nameof(ICreationAudited<Guid>.CreatorUserId)) != null;
        }
        protected virtual bool HasCreatedTimeProperty(EntityEntry entity)
        {
            return entity.GetType().GetProperty(nameof(ICreationAudited<Guid>.CreatedTime)) != null;
        }
    }


}
