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
        private readonly IMongoDBRepository<AuditLog, Guid> _auditLogRepository;
        private readonly IMongoDBRepository<AuditEntry, Guid> _auditEntryRepository;
        private readonly IMongoDBRepository<AuditPropertysEntry, Guid> _auditPropertysEntryRepository;

        public AuditServices(IMongoDBRepository<AuditLog, Guid> auditLogRepository, IMongoDBRepository<AuditEntry, Guid> auditEntryRepository, IMongoDBRepository<AuditPropertysEntry, Guid> auditPropertysEntryRepository)
        {
            _auditLogRepository = auditLogRepository;
            _auditEntryRepository = auditEntryRepository;
            _auditPropertysEntryRepository = auditPropertysEntryRepository;
        }

        public async Task Save(AuditLog auditLog,List<AuditEntry> auditEntry)
        {
            foreach (var item in auditEntry)
            {
                item.AuditLogId = auditLog.Id;
            }
            await _auditLogRepository.InsertAsync(auditLog);
            await _auditEntryRepository.InsertAsync(auditEntry);
            //await _auditEntryRepository.InsertAsync(auditEntry);
        }
    }
}
