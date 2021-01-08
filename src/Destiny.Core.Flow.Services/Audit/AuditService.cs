using Destiny.Core.Flow.Audit;
using Destiny.Core.Flow.Dtos.Audits;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.IServices.Audit;
using Destiny.Core.Flow.MongoDB.Repositorys;
using Destiny.Core.Flow.Ui;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Services.Audit
{
    public class AuditService: IAuditService
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

        public async Task<OperationResponse<AuditLogOutputDto>> LoadAuditLogByIdAsync(ObjectId id)
        {
           var auditLog=  await  _auditLogRepository.FindByIdAsync(id);
           return  OperationResponse<AuditLogOutputDto>.Ok("操作成功", auditLog.MapTo<AuditLogOutputDto>());
        }


        /// <summary>
        /// 根据Id加载审计实体数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        public async Task<OperationResponse<AuditEntryOutputDto>> LoadAuditEntryByIdAsync(ObjectId id)
        {
            var auditEntry = await _auditEntryRepository.FindByIdAsync(id);
            return OperationResponse<AuditEntryOutputDto>.Ok("加载成功", auditEntry.MapTo<AuditEntryOutputDto>());
        }



        /// <summary>
        /// 得到审计实体属性
        /// </summary>
        /// <param name="auditEntryId"></param>
        /// <returns></returns>
        public async  Task<OperationResponse> GetAuditEntryPropertyByAuditEntryIdListAsnyc(ObjectId auditEntryId)
        {

            var entryPropertys =await _auditPropertysEntryRepository.Collection.Find(o => o.AuditEntryId == auditEntryId).ToListAsync();
            var dtos= entryPropertys.MapToList<AuditEntryPropertyOutputDto>();
            return OperationResponse.Ok("操作成功",dtos);
        }
    }
}
