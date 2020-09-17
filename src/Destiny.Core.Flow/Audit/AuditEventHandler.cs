using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Events;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Audit
{
    public class AuditEventHandler : NotificationHandlerBase<AuditEvent>
    {
        private IServiceProvider _serviceProvider = null;
        private readonly DictionaryAccessor _dictionaryAccessor = null;
        //private readonly ILogger _logger = null;

        public AuditEventHandler(IServiceProvider serviceProvider/*, ILogger logger*/, DictionaryAccessor dictionaryAccessor)
        {
            _serviceProvider = serviceProvider;
            _dictionaryAccessor = dictionaryAccessor;
            //_dictionaryAccessor = serviceProvider.GetService<DictionaryAccessor>();
            //_logger = logger;
        }

        public override Task Handle(AuditEvent @event, CancellationToken cancellationToken)
        {
            //var model = new AuditEntry();
            //foreach (var entityEntry in @event.Entries)
            //{
            //    model.NewValues = new Dictionary<string, object>();
            //    model.OriginalValues = new Dictionary<string, object>();
            //    var properties = entityEntry.Metadata.GetProperties();
            //    foreach (var propertie in properties)
            //    {
            //        var propertyEntry = entityEntry.Property(propertie.Name);//获取字段名
            //        switch (entityEntry.State)
            //        {
            //            case EntityState.Detached:
            //                model.OperationType = DataOperationType.None;
            //                model.NewValues.Add(propertie.Name, propertyEntry.CurrentValue?.ToString());//当前值
            //                model.OriginalValues.Add(propertie.Name, propertyEntry.OriginalValue?.ToString());//原始值
            //                break;
            //            case EntityState.Unchanged:
            //                model.OperationType = DataOperationType.None;
            //                model.NewValues.Add(propertie.Name, propertyEntry.CurrentValue?.ToString());//当前值
            //                model.OriginalValues.Add(propertie.Name, propertyEntry.OriginalValue?.ToString());//原始值
            //                break;
            //            case EntityState.Deleted:
            //                model.OperationType = DataOperationType.Delete;
            //                model.NewValues.Add(propertie.Name, propertyEntry.CurrentValue?.ToString());//当前值
            //                model.OriginalValues.Add(propertie.Name, propertyEntry.OriginalValue?.ToString());//原始值
            //                break;
            //            case EntityState.Modified:
            //                model.OperationType = DataOperationType.Update;
            //                model.NewValues.Add(propertie.Name, propertyEntry.CurrentValue?.ToString());//当前值
            //                model.OriginalValues.Add(propertie.Name, propertyEntry.OriginalValue?.ToString());//原始值
            //                break;
            //            case EntityState.Added:
            //                model.OperationType = DataOperationType.Add;
            //                model.NewValues.Add(propertie.Name, propertyEntry.CurrentValue?.ToString());//当前值
            //                model.OriginalValues.Add(propertie.Name, propertyEntry.OriginalValue?.ToString());//原始值
            //                break;
            //        }
            //    }
            //}
            var scope = _serviceProvider.CreateScope();
            _dictionaryAccessor.GetOrAdd("audit", @event.AuditEntries);
            //var dic = _dictionaryAccessor.GetRequiredService<DictionaryAccessor>();
            //dic.ddd = false;
            //dic["audit"] = model;

            return Task.CompletedTask;
        }
    }
}