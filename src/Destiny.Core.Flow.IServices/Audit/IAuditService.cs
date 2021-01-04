using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Dtos.Audits;
using Destiny.Core.Flow.Ui;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.IServices.Audit
{
    public   interface IAuditService : IScopedDependency
    {
        /// <summary>
        /// 根据Id加载审计日志数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<OperationResponse<AuditLogOutputDto>> LoadAuditLogByIdAsync(ObjectId id);



        /// <summary>
        /// 根据Id加载审计实体数据
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>

        Task<OperationResponse<AuditEntryOutputDto>> LoadAuditEntryByIdAsync(ObjectId id);
    }
}
