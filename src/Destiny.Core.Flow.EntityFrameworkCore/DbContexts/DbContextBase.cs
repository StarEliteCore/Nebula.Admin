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
        protected readonly IServiceProvider _serviceProvider = null;
        protected readonly AppOptionSettings _option = null;
        protected readonly Microsoft.Extensions.Logging.ILogger _logger = null;

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

        public override  Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);

        }

        /// <summary>
        /// 保存更改
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            return base.SaveChanges();
       
        }

  

    }
}