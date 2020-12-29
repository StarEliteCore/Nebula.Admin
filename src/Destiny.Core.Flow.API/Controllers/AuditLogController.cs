using Destiny.Core.Flow.AspNetCore.Api;
using Destiny.Core.Flow.AspNetCore.Ui;
using Destiny.Core.Flow.Audit;
using Destiny.Core.Flow.Audit.Dto;
using Destiny.Core.Flow.Filter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using Destiny.Core.Flow.Extensions;

namespace Destiny.Core.Flow.API.Controllers
{
    /// <summary>
    /// 审计日志
    /// </summary>
    [Description("审计日志")]
    [AllowAnonymous]
    [DisableAuditing]
    public class AuditLogController : ApiControllerBase
    {
        private readonly IAuditStore _auditStore = null;

        public AuditLogController(IAuditStore auditStore)
        {
            _auditStore = auditStore;
        }
        /// <summary>
        /// 分页获取审计日志
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("分页获取审计日志")]
        public async Task<PageList<AuditLogOutputPageDto>> GetAuditLogPageAsync([FromBody] PageRequest request)
        {
            return (await _auditStore.GetAuditLogPageAsync(request)).ToPageList();
        }
  
    }
}
