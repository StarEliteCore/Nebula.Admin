using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Interceptor
{
    public class AuditInterceptor: SaveChangesInterceptor
    {
        protected readonly IServiceProvider _serviceProvider = null;

        public AuditInterceptor(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public override int SavedChanges(SaveChangesCompletedEventData eventData, int result)
        {
            return base.SavedChanges(eventData, result);
        }
    }
}
