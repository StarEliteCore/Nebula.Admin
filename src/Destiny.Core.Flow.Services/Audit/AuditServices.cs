using Destiny.Core.Flow.Audit;
using Destiny.Core.Flow.Audit.Dto;
using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.MongoDB.Repositorys;
using Destiny.Core.Flow.Ui;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task Save(AuditLog auditLog, List<AuditEntryInputDto> auditEntry)
        {
            var ss = auditEntry.MapToList<AuditEntry>();
            List<AuditEntry> auditentrylist = new List<AuditEntry>();
            List<AuditPropertysEntry> auditpropertysentrylist = new List<AuditPropertysEntry>();
            foreach (var item in auditEntry)
            {
                var model = item.MapTo<AuditEntry>();
                model.AuditLogId = auditLog.Id;
                foreach (var auditProperty in item.AuditPropertys)
                {
                    var auditPropertymodel = auditProperty.MapTo<AuditPropertysEntry>();
                    auditPropertymodel.AuditEntryId = model.Id;
                    auditpropertysentrylist.Add(auditPropertymodel);
                }
                auditentrylist.Add(model);
            }
            await _auditLogRepository.InsertAsync(auditLog);
            await _auditEntryRepository.InsertAsync(auditentrylist.ToArray());
            await _auditPropertysEntryRepository.InsertAsync(auditpropertysentrylist.ToArray());
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public async Task<PageResult<AuditLogOutputPageDto>> GetAuditLogPageAsync(PageRequest request)
        {
            var list = await _auditLogRepository.Entities.Skip(request.PageSize * (request.PageIndex - 1)).Take(request.PageSize).Select(x => new AuditLogOutputPageDto
            {
                BrowserInformation = x.BrowserInformation,
                Ip = x.Ip,
                FunctionName = x.FunctionName,
                Action = x.Action,
                ExecutionDuration = x.ExecutionDuration,
                CreatorUserId = x.CreatorUserId,
                CreatedTime = x.CreatedTime,
                Id = x.Id
            }).ToListAsync();
            return new PageResult<AuditLogOutputPageDto>(list, _auditLogRepository.Entities.Count());
        }

        public async Task<OperationResponse> GetAuditEntryListByAuditLogIdAsync(Guid id)
        {
            var list = await _auditEntryRepository.Entities.Where(x => x.AuditLogId == id)
                .Select(x => new AuditEntryOutputDto
                {
                    EntityAllName = x.EntityAllName,
                    EntityDisplayName = x.EntityDisplayName,
                    TableName = x.TableName,
                    KeyValues = x.KeyValues,
                    OperationType = x.OperationType,
                }).ToListAsync();
            return new OperationResponse(MessageDefinitionType.LoadSucces, list, OperationResponseType.Success);
        }

        public async Task<OperationResponse> GetAuditEntryListByAuditEntryIdAsync(Guid id)
        {
            var list = await _auditPropertysEntryRepository.Entities.Where(x => x.AuditEntryId == id).Select(x => new AuditPropertyEntryOutputDto
            {
                Properties = x.Properties,
                PropertieDisplayName = x.PropertieDisplayName,
                OriginalValues = x.OriginalValues,
                NewValues = x.NewValues,
                PropertiesType = x.PropertiesType,
            }).ToListAsync();
            return new OperationResponse(MessageDefinitionType.LoadSucces, list, OperationResponseType.Success);
        }
    }
}