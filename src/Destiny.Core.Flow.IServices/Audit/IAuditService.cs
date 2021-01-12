using Destiny.Core.Flow.Audit.Dto;
using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Ui;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.IServices.Audit
{
    public interface IAuditService : IScopedDependency
    {
        /// <summary>
        /// 根据Id加载审计日志数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<OperationResponse<AuditLogOutputPageDto>> LoadAuditLogByIdAsync(ObjectId id);
        /// <summary>
        /// 根据Id加载审计实体数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        Task<OperationResponse<AuditEntryOutputPageDto>> LoadAuditEntryByIdAsync(string id);
        /// <summary>
        /// 得到审计实体属性
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<OperationResponse> GetAuditEntryPropertyByAuditEntryIdListAsnyc(string auditEntryId);
    }
}
