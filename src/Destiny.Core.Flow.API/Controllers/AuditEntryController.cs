using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Destiny.Core.Flow.AspNetCore.Api;
using Destiny.Core.Flow.AspNetCore.Ui;
using Destiny.Core.Flow.Audit;
using Destiny.Core.Flow.Audit.Dto;
using Destiny.Core.Flow.Filter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Destiny.Core.Flow.API.Controllers
{
    /// <summary>
    /// 数据审计
    /// </summary>
    [Description("数据审计")]
    [AllowAnonymous]
    public class AuditEntryController : ApiControllerBase
    {


        private readonly IAuditStore _auditStore = null;

        public AuditEntryController(IAuditStore auditStore)
        {
            _auditStore = auditStore;
        }


        /// <summary>
        /// 异步得到数据审计分页
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("异步得到数据审计分页")]
        public async Task<PageList<AuditEntryOutputDto>> GetAuditEntryPageAsync([FromBody] PageRequest request)
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
        public async Task<PageList<AuditPropertyEntryOutputDto>> GetAuditEntryPropertyPageAsync([FromBody] PageRequest request)
        {
            return (await _auditStore.GetAuditEntryPropertyPageAsync(request)).ToPageList();
        }
    }
}
