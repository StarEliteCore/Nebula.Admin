using Destiny.Core.Flow.Audit;
using Destiny.Core.Flow.Audit.Dto;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.IServices.Audit;
using Destiny.Core.Flow.MongoDB.Repositorys;
using Destiny.Core.Flow.Ui;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Services.Audit
{
    public class AuditService : IAuditService
    {

        private readonly IMongoDBRepository<AuditLog, ObjectId> _auditLogRepository;
        private readonly IMongoDBRepository<AuditEntry, ObjectId> _auditEntryRepository;
        private readonly IMongoDBRepository<AuditPropertysEntry, ObjectId> _auditPropertysEntryRepository;

        public AuditService(IMongoDBRepository<AuditLog, ObjectId> auditLogRepository, IMongoDBRepository<AuditEntry, ObjectId> auditEntryRepository, IMongoDBRepository<AuditPropertysEntry, ObjectId> auditPropertysEntryRepository)
        {
            _auditLogRepository = auditLogRepository;
            _auditEntryRepository = auditEntryRepository;
            _auditPropertysEntryRepository = auditPropertysEntryRepository;
        }


        /// <summary>
        /// 根据Id加载审计日志数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public async Task<OperationResponse<AuditLogOutputPageDto>> LoadAuditLogByIdAsync(ObjectId id)
        {
            var auditLog = await _auditLogRepository.FindByIdAsync(id);
            return OperationResponse<AuditLogOutputPageDto>.Ok("操作成功", auditLog.MapTo<AuditLogOutputPageDto>());
        }


        /// <summary>
        /// 根据Id加载审计实体数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public async Task<OperationResponse<AuditEntryOutputPageDto>> LoadAuditEntryByIdAsync(string id)
        {
            var newId = id.AsTo<ObjectId>();
            var auditEntry = await _auditEntryRepository.FindByIdAsync(newId);
            return OperationResponse<AuditEntryOutputPageDto>.Ok("加载成功", auditEntry.MapTo<AuditEntryOutputPageDto>());
        }



        /// <summary>
        /// 得到审计实体属性
        /// </summary>
        /// <param name="auditEntryId"></param>
        /// <returns></returns>
        public async Task<OperationResponse> GetAuditEntryPropertyByAuditEntryIdListAsnyc(string auditEntryId)
        {
            var newAuditEntryId = auditEntryId.AsTo<ObjectId>();
            var entryPropertys = await _auditPropertysEntryRepository.Collection.Find(o => o.AuditEntryId == newAuditEntryId).ToListAsync();
            var dtos = entryPropertys.MapToList<AuditPropertyEntryOutputPageDto>();
            return OperationResponse.Ok("操作成功", dtos);
        }
    }
}
