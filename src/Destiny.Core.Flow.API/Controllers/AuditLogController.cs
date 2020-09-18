using Destiny.Core.Flow.AspNetCore.Ui;
using Destiny.Core.Flow.Audit;
using Destiny.Core.Flow.Audit.Dto;
using Destiny.Core.Flow.Filter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.API.Controllers
{
    /// <summary>
    /// 审计日志
    /// </summary>
    [Description("审计日志")]
    [Authorize]
    public class AuditLogController : ControllerBase
    {
        private readonly IAuditStore _auditStore = null;

        public AuditLogController(IAuditStore auditStore)
        {
            _auditStore = auditStore;
        }
        /// <summary>
        /// 异步得到功能分页
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("分页获取审计日志")]
        public async Task<PageList<AuditLogOutputPageDto>> GetAuditLogPageAsync([FromBody] PageRequest request)
        {
            return (await _auditStore.GetAuditLogPageAsync(request)).ToPageList();
        }
        /// <summary>
        /// 获取操作实体列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Description("获取操作实体列表")]
        public async Task<AjaxResult> GetAuditEntryListByAuditLogIdAsync(Guid? id)
        {
            return (await _auditStore.GetAuditEntryListByAuditLogIdAsync(id.Value)).ToAjaxResult();
        }
        /// <summary>
        /// 获取实体属性列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Description("获取实体属性列表")]
        public async Task<AjaxResult> GetAuditEntryListByAuditEntryIdAsync(Guid? id)
        {
            return (await _auditStore.GetAuditEntryListByAuditEntryIdAsync(id.Value)).ToAjaxResult();
        }
    }
}
