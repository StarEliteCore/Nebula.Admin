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
        private readonly DictionaryScoped _dictionaryAccessor = null;

        public AuditEventHandler(IServiceProvider serviceProvider, DictionaryScoped dictionaryAccessor)
        {
            _serviceProvider = serviceProvider;
            _dictionaryAccessor = dictionaryAccessor;
          
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="event"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task Handle(AuditEvent @event, CancellationToken cancellationToken)
        {
         
            //var scope = _serviceProvider.CreateScope();
            _dictionaryAccessor.GetOrAdd("audit", @event.AuditEntries);
           

            return Task.CompletedTask;
        }
    }
}