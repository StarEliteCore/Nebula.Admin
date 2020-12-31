using Destiny.Core.Flow.Audit.Dto;
using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.Filter.Abstract;
using Destiny.Core.Flow.Ui;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Audit
{
    public interface IAuditStore : IScopedDependency
    {
 

        /// <summary>
        /// 异步保存
        /// </summary>
        /// <param name="auditChange"></param>
        /// <returns></returns>
        Task SaveAsync(AuditChange auditChange);
        /// <summary>
        /// 分页获取审计日志
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IPagedResult<AuditLogOutputPageDto>> GetAuditLogPageAsync(PageRequest request);


        /// <summary>
        /// 分页获取数据实体审计 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IPagedResult<AuditEntryOutputDto>> GetAuditEntryPageAsync(PageRequest request);


        /// <summary>
        /// 分页获取数据实体属性审计 
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IPagedResult<AuditPropertyEntryOutputDto>> GetAuditEntryPropertyPageAsync(PageRequest request);

   
    }
}