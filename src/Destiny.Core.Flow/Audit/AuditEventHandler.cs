using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
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
            var model = new AuditEntry();
            foreach (var entityEntry in @event.Entries)
            {
                var properties = entityEntry.Metadata.GetProperties();
                foreach (var propertie in properties)
                {
                    var propertyEntry = entityEntry.Property(propertie.Name);//获取字段名
                    switch (entityEntry.State)
                    {
                        #region MyRegion


                        //case EntityState.Detached:
                        //    model.OperationType = DataOperationType.Add;
                        //    break;
                        //case EntityState.Unchanged:
                        //    model.OperationType = DataOperationType.None;
                        //    model.NewValues = new Dictionary<string, object>();
                        //    model.NewValues[propertie.Name] = propertyEntry.CurrentValue?.ToString();//当前值
                        //    model.OriginalValues[propertie.Name] = propertyEntry.OriginalValue?.ToString();//原始值
                        //    break;
                        #endregion
                        case EntityState.Deleted:
                            model.OperationType = DataOperationType.Delete;
                            model.NewValues = new Dictionary<string, object>();
                            model.NewValues[propertie.Name] = propertyEntry.CurrentValue?.ToString();//当前值
                            model.OriginalValues[propertie.Name] = propertyEntry.OriginalValue?.ToString();//原始值
                            break;
                        case EntityState.Modified:
                            model.OperationType = DataOperationType.Update;
                            model.NewValues = new Dictionary<string, object>();
                            model.NewValues[propertie.Name] = propertyEntry.CurrentValue?.ToString();//当前值
                            model.OriginalValues[propertie.Name] = propertyEntry.OriginalValue?.ToString();//原始值
                            break;
                        case EntityState.Added:
                            model.OperationType = DataOperationType.Add;
                            model.NewValues = new Dictionary<string, object>();
                            model.NewValues[propertie.Name]= propertyEntry.CurrentValue?.ToString();//当前值
                            model.OriginalValues[propertie.Name]= propertyEntry.OriginalValue?.ToString();//原始值
                            break;
                    }
                }
            }
           var scope=  _serviceProvider.CreateScope();
          var dic=  scope.ServiceProvider.GetRequiredService<DictionaryAccessor>();
            dic.ddd = false;
            dic["audit"] = model;

            return Task.CompletedTask;
        }
    }
}
