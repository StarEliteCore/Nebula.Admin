using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Events;
using Destiny.Core.Flow.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Audit.Events
{
    public class AuditEntityEventHandler : NotificationHandlerBase<AuditEntityEventData>
    {
        private readonly DictionaryScoped _dictionaryScoped = null;

        public AuditEntityEventHandler(DictionaryScoped dictionaryScoped)
        {
            _dictionaryScoped = dictionaryScoped;
        }

        public override Task Handle(AuditEntityEventData eventData, CancellationToken cancellationToken)
        {
            eventData.NotNull(nameof(eventData));
            cancellationToken.ThrowIfCancellationRequested();
            var auditChange= _dictionaryScoped.AuditChange;
            if (auditChange == null)
            {
                return Task.CompletedTask;
            }

            auditChange.AuditEntitys.AddRange(eventData.AuditEntitys);
            return Task.CompletedTask;
        }
    }
}
