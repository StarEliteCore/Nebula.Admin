using Destiny.Core.Flow.AspNetCore.Api;
using Destiny.Core.Flow.AspNetCore.Ui;
using Destiny.Core.Flow.Audit;
using Destiny.Core.Flow.IServices.IdentityServer4;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.API.Controllers.IdentityServer4
{
    /// <summary>
    /// Api资源范围
    /// </summary>
    [DisableAuditing]
    [Description("Api资源范围")]
    public class ApiResourceScopeController : AdminControllerBase
    {

        private readonly IApiResourceScopeService _apiResourceScopeService;

        public ApiResourceScopeController(IApiResourceScopeService apiResourceScopeService)
        {
            _apiResourceScopeService = apiResourceScopeService;
        }



        /// <summary>
        /// 异步得到API资源范围集合数据
        /// </summary>
        /// <returns></returns>
        [Description("得到API资源范围集合")]
        [HttpGet]
        public async Task<AjaxResult> GetApiResourceScopeListAsync()
        {

          return  (await _apiResourceScopeService.GetApiResourceScopeListAsync()).ToAjaxResult();
        }
    }
}
