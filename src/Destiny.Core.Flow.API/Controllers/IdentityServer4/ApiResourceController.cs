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
using Destiny.Core.Flow.Filter;
using Microsoft.AspNetCore.Authorization;

namespace Destiny.Core.Flow.API.Controllers.IdentityServer4
{

    /// <summary>
    /// Api资源管理
    /// </summary>
    [DisableAuditing]
    [Description("Api资源管理")]
    public class ApiResourceController : AdminControllerBase
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
        {
            return (await _apiResourceService.CreateApiResourceAsync(dto)).ToAjaxResult();
        }

        /// <summary>
        /// 异步加载 API资源
        /// </summary>
        /// <param name="id">资源ID</param>
        /// <returns></returns>
        [Description("加载API资源")]
        [HttpGet]
        public async Task<AjaxResult> LoadAsync(Guid id)
        {

           return (await  _apiResourceService.LoadApiResourceDataAsync(id)).ToAjaxResult();
        }

        /// <summary>
        /// 异步得到API资源分页
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("异步得到API资源分页")]
        public async Task<PageList<ApiResourceOutputPageListDto>> GetApiResourcePageAsync(
            [FromBody] PageRequest request)
        {
            return (await _apiResourceService.GetApiResourcePageAsync(request)).ToPageList();
        }

        /// <summary>
        /// 得到JWTClaim类型下拉项
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Description("得到JWTClaim类型下拉项")]
        public AjaxResult GetJwtClaimTypeSelectItem()
        {
            return _apiResourceService.GetJwtClaimTypeSelectItem().ToAjaxResult();
        }


        /// <summary>
        /// 异步删除资源
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>

        [HttpDelete]
        [Description("异步删除资源")]

        public async Task<AjaxResult> DeleteAsync(Guid id)
        {
            return (await _apiResourceService.DeleteAsync(id)).ToAjaxResult();

        }

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="dto"></param>
        ///// <returns></returns>

        //public async Task<AjaxResult> AddOrUpdate([FromBody] ApiResourceInputDto dto)
        //{

        //    if (dto.Id == Guid.Empty)
        //    {
        //        return (await _apiResourceService.CreateApiResourceAsync(dto)).ToAjaxResult();
        //    }
        //}
    }
}
