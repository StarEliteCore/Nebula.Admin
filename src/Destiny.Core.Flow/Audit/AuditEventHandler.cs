using Destiny.Core.Flow.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Audit
{
    public class AuditEventHandler : NotificationHandlerBase<AuditEvent>
    {
        private IServiceProvider _serviceProvider = null;
        //private readonly ILogger _logger = null;

        public AuditEventHandler(IServiceProvider serviceProvider/*, ILogger logger*/)
        {
            _serviceProvider = serviceProvider;
            //_logger = logger;
        }

        public override Task Handle(AuditEvent @event, CancellationToken cancellationToken)
        {
            foreach (var entityEntry in @event.Entries)
            {
                var properties = entityEntry.Metadata.GetProperties();
                foreach (var propertie in properties)
                {
                    var propertyEntry = entityEntry.Property(propertie.Name);//获取字段名
                    string currentValue = propertyEntry.CurrentValue?.ToString();//当前值
                    string originalValue = propertyEntry.OriginalValue?.ToString();//原始值
                }
                //if (entityEntry.State == EntityState.Detached || entityEntry.State == EntityState.Unchanged)
                //{
                //    continue;
                //}
            }
            return Task.CompletedTask;
            Console.WriteLine($"事件信息：{@event}");
            //throw new NotImplementedException();
        }
    }
}
