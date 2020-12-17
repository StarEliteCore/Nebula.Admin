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
using Destiny.Core.Flow.Audit;
using System.Reflection;
using Destiny.Core.Flow.Helpers;

namespace Destiny.Core.Flow
{
    //public class CompletedEventArgs : EventArgs
    //{

    //    public int Count { get; set; }

    //    public object Sender { get; set; }



    //}
    /// <summary>
    /// 上下文基类
    /// </summary>
    public abstract class DbContextBase : DbContext
    {
        protected readonly IServiceProvider _serviceProvider = null;
        protected readonly AppOptionSettings _option = null;
        protected readonly Microsoft.Extensions.Logging.ILogger _logger = null;

        //public event EventHandler<CompletedEventArgs> Completed;






        protected DbContextBase(DbContextOptions options, IServiceProvider serviceProvider)
             : base(options)
        {
            _serviceProvider = serviceProvider;
            _option = serviceProvider.GetService<IObjectAccessor<AppOptionSettings>>()?.Value;


            _logger = serviceProvider.GetLogger(GetType());

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


        //protected virtual void OnCompleted()
        //{

        //    Completed += (sender, ev) =>
        //    {
        //        if (_option.AuditEnabled)
        //        {
        //            if (ev.Count > 0 && ev.Sender != null && ev.Sender is List<AuditEntryDto> senders)
        //            {
        //                var scoped = _serviceProvider.GetService<DictionaryScoped>();
        //                var auditChange = scoped.AuditChange;
        //                if (auditChange != null)
        //                {
        //                    auditChange.AuditEntitys.AddRange(senders);
        //                }


        //            }
        //        }

               
        //    };
        //}

        /// <summary>
        /// 异步保存
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var result = OnBeforeSaveChanges();
            int count = await base.SaveChangesAsync(cancellationToken);
            _logger.LogInformation($"成功保存{count}条数据");
            OnCompleted(count,result);
            //OnCompleted();
            //Completed?.Invoke(this, new CompletedEventArgs() { Count = count, Sender = result });
            return count;
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
            var result = OnBeforeSaveChanges();
            int count= base.SaveChanges();
            _logger.LogInformation($"成功保存{count}条数据");
            OnCompleted(count, result);
            return count;
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

    }


}