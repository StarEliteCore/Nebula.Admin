using Destiny.Core.Flow.Audit;
using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Extensions;
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

        public async Task Save(AuditLog auditLog,List<AuditEntryInputDto> auditEntry)
        {
            var ss=auditEntry.MapToList<AuditEntry>();
            List<AuditEntry> auditentrylist = new List<AuditEntry>();
            List<AuditPropertysEntry> auditpropertysentrylist = new List<AuditPropertysEntry>();
            foreach (var item in auditEntry)
            {
                var model =item.MapTo<AuditEntry>();
                model.AuditLogId = auditLog.Id;
                foreach (var auditProperty in item.AuditPropertys)
                {
                    var auditPropertymodel= auditProperty.MapTo<AuditPropertysEntry>();
                    auditPropertymodel.AuditEntryId = model.Id;
                    auditpropertysentrylist.Add(auditPropertymodel);
                }
                auditentrylist.Add(model);
            }
            await _auditLogRepository.InsertAsync(auditLog);
            await _auditEntryRepository.InsertAsync(auditentrylist.ToArray());
            await _auditPropertysEntryRepository.InsertAsync(auditpropertysentrylist.ToArray());
        }
    }
}
