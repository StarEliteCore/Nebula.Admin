using Destiny.Core.Flow.AspNetCore.Api;
using Destiny.Core.Flow.AspNetCore.Ui;
using Destiny.Core.Flow.Dtos.Application;
using Destiny.Core.Flow.IServices;
using Microsoft.AspNetCore.Mvc;
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

        ///// <summary>
        ///// 添加客户端
        ///// </summary>
        ///// <param name="input"></param>
        ///// <returns></returns>
        //[HttpPost]
        //[Description("添加客户端")]
        //public async Task<AjaxResult> CreateAsync([FromBody] ClientAddInputDto input)
        //{
        //    return (await _applicationClientContract.CreatAsync(input)).ToAjaxResult();
        //}
    }
}
