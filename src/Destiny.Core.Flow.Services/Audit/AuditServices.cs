using Destiny.Core.Flow.Audit;
using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Services.Audit
{
    public class AuditServices : IAuditStore
    {
        private readonly IMongoDBRepository<AuditEntry, Guid> _mongoDBRepository;

        public AuditServices(IMongoDBRepository<AuditEntry, Guid> mongoDBRepository)
        {
            _mongoDBRepository = mongoDBRepository;
        }

        public async Task Save(List<AuditEntry> auditEntry )
        {
            await _mongoDBRepository.InsertAsync(auditEntry);
        }
    }
}
