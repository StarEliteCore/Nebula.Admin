using Destiny.Core.Flow.Dependency;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Audit
{
    public interface IGetChangeTracker : IScopedDependency
    {
        Task<List<AuditEntryInputDto>> GetChangeTrackerList(IEnumerable<EntityEntry> Entries);
    }
}