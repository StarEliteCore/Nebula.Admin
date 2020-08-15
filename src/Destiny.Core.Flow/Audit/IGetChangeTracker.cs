using Destiny.Core.Flow.Dependency;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Audit
{
    public interface IGetChangeTracker:IScopedDependency
    {
        Task<List<AuditEntry>> GetChangeTrackerList(IEnumerable<EntityEntry> Entries);

    }
}
