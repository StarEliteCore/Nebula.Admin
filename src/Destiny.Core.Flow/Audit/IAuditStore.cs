using Destiny.Core.Flow.Audit.Dto;
using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.Ui;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Audit
{
    public interface IAuditStore : IScopedDependency
    {
        Task Save(AuditLog auditLog, List<AuditEntryInputDto> auditEntry);

        /// <summary>
        /// 分页获取审计日志
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<PageResult<AuditLogOutputPageDto>> GetAuditLogPageAsync(PageRequest request);

        /// <summary>
        /// 获取操作明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<OperationResponse> GetAuditEntryListByAuditLogIdAsync(Guid id);

        /// <summary>
        /// 获取实体明细
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<OperationResponse> GetAuditEntryListByAuditEntryIdAsync(Guid id);
    }
}