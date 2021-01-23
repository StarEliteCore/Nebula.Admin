using Destiny.Core.Flow.AspNetCore.Api;
using Destiny.Core.Flow.Audit;
using Destiny.Core.Flow.IServices.IdentityServer4;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Destiny.Core.Flow.AspNetCore.Ui;
using Destiny.Core.Flow.Dtos.IdentityServer4;

namespace Destiny.Core.Flow.API.Controllers.IdentityServer4
{

    [DisableAuditing]
    [Description("Api资源管理")]
    public class ApiResourceController : ApiControllerBase
    {

        private readonly IApiResourceService _apiResourceService = null;

        public ApiResourceController(IApiResourceService apiResourceService)
        {
            
            _apiResourceService = apiResourceService;
        }

        /// <summary>
        /// 异步创建Api资源
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Description("创建Api资源")]
        [HttpPost]
        public async Task<AjaxResult> CreateApiResourceAsync([FromBody] ApiResourceInputDto dto)
        { return (await _apiResourceService.CreateApiResourceAsync(dto)).ToAjaxResult();
        }
    }
}
