using DestinyCore.AspNetCore.Api;
using DestinyCore.AspNetCore;
using Destiny.Core.Flow.Dtos.IdentityServer4.ClientApplication;
using DestinyCore.Filter;
using Destiny.Core.Flow.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.API.Controllers.IdentityServer4
{
    /// <summary>
    /// 客户端应用管理
    /// </summary>
    [Description("客户端应用管理")]
    public class ClientApplicationController : ApiControllerBase
    {
        private readonly IApplicationClientService _applicationClientContract;

        public ClientApplicationController(IApplicationClientService applicationClientContract)
        {
            _applicationClientContract = applicationClientContract;
        }

        /// <summary>
        /// 添加客户端
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("添加客户端")]
        public async Task<AjaxResult> CreateAsync([FromBody] ClientAddInputDto input)
        {
            return (await _applicationClientContract.CreateAsync(input)).ToAjaxResult();
        }

        /// <summary>
        /// 分页获取
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("分页获取")]
        public async Task<PageList<ClientOutputPageListDto>> GetPageAsync([FromBody] PageRequest request)
        {
            return (await _applicationClientContract.GetPageAsync(request)).ToPageList();
        }
        /// <summary>
        /// 异步删除客户端
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpDelete]
        [Description("异步删除客户端")]

        public async Task<AjaxResult> DeleteAsync(Guid? id)
        {
            return (await _applicationClientContract.DeleteAsync(id.Value)).ToAjaxResult();
        }
        /// <summary>
        /// 获取授权类型
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>
        [HttpGet]
        [Description("获取授权类型")]
        [AllowAnonymous]

        public AjaxResult GetGrantTypeSelectItemAsync()
        {
            return _applicationClientContract.GetGrantTypeSelectItem().ToAjaxResult();
        }
    }
}
