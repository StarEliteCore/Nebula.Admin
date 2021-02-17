using Destiny.Core.Flow.AspNetCore.Api;
using Destiny.Core.Flow.AspNetCore.Ui;
using Destiny.Core.Flow.Audit;
using Destiny.Core.Flow.Dtos.IdentityServer4;
using Destiny.Core.Flow.Filter;
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
    /// Api范围
    /// </summary>
    [DisableAuditing]
    [Description("Api范围管理")]

    public class ApiScopeController : AdminControllerBase
    {

        private readonly IApiScopeService _apiScopeService;

        public ApiScopeController(IApiScopeService apiScopeService)
        {
            _apiScopeService = apiScopeService;
        }

        /// <summary>
        /// 异步创建API范围
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("异步创建API范围")]
        public async Task<AjaxResult> CreateApiScopeAsync([FromBody] ApiScopeDto dto)
        {

           return  (await _apiScopeService.CreateApiScopeAsync(dto)).ToAjaxResult();
        }


        /// <summary>
        /// 异步得到API范围分页
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("异步得到API范围分页")]
        public async Task<PageList<ApiScopeOutputPageListDto>> GetApiScopePageAsync([FromBody] PageRequest request)
        {

            return (await _apiScopeService.GetApiScopePageAsync(request)).ToPageList();
        }


        /// <summary>
        /// 异步API范围
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>

        [HttpDelete]
        [Description("异步API范围")]

        public  Task<AjaxResult> DeleteAsync(Guid id)
        {
            return  _apiScopeService.DeleteAsync(id).ToAjaxResult();
            //return (await _apiScopeService.DeleteAsync(id)).ToAjaxResult();

        }
    }
}
