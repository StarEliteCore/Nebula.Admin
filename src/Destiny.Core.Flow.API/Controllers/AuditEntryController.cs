using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Destiny.Core.Flow.AspNetCore.Api;
using Destiny.Core.Flow.AspNetCore.Ui;
using Destiny.Core.Flow.Audit;
using Destiny.Core.Flow.Audit.Dto;
using Destiny.Core.Flow.Dtos.Audits;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.IServices.Audit;
using Destiny.Core.Flow.Ui;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace Destiny.Core.Flow.API.Controllers
{
    /// <summary>
    /// 数据审计
    /// </summary>
    [Description("数据审计")]
    [AllowAnonymous]
    [DisableAuditing]
    public class AuditEntryController : ApiControllerBase
    {


        private readonly IAuditStore _auditStore = null;
        private readonly IAuditService _auditService = null;

        public AuditEntryController(IAuditStore auditStore, IAuditService auditService)
        {
            _auditStore = auditStore;
            _auditService = auditService;
        }


        /// <summary>
        /// 异步得到数据审计分页
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("异步得到数据审计分页")]
        public async Task<PageList<AuditEntryOutputPageDto>> GetAuditEntryPageAsync([FromBody] PageRequest request)
        {
            return (await _auditStore.GetAuditEntryPageAsync(request)).ToPageList();
        }

        /// <summary>
        /// 异步得到实体属性分页
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("异步得到实体属性分页")]
        public async Task<PageList<AuditPropertyEntryOutputPageDto>> GetAuditEntryPropertyPageAsync([FromBody] PageRequest request)
        {
            return (await _auditStore.GetAuditEntryPropertyPageAsync(request)).ToPageList();
        }

        /// <summary>
        /// 异步加载审计实体
        /// </summary>
        /// <param name="id">审计实体Id</param>
        /// <returns></returns>
        [HttpGet]
        [Description("异步加载审计实体")]
        public async Task<AjaxResult> LoadAuditEntryByIdAsync(ObjectId id)
        {
            return (await _auditService.LoadAuditEntryByIdAsync(id)).ToAjaxResult();
        }


    }
}
