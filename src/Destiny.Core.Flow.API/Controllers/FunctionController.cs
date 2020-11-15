using Destiny.Core.Flow.AspNetCore.Api;
using Destiny.Core.Flow.AspNetCore.Ui;
using Destiny.Core.Flow.Dtos.Functions;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.IServices.Functions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.API.Controllers
{
    /// <summary>
    /// 功能管理
    /// </summary>
    [Description("功能管理")]

    public class FunctionController : AdminControllerBase
    {

        private readonly IFunctionService _functionService;

        public FunctionController(IFunctionService functionService)
        {
            _functionService = functionService ?? throw new ArgumentNullException(nameof(functionService));
        }


        /// <summary>
        /// 异步创建功能
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("异步创建功能")]

        public async Task<AjaxResult> CreateAsync([FromBody] FunctionInputDto dto)
        {

            return (await _functionService.CreateAsync(dto)).ToAjaxResult();
        }


        /// <summary>
        /// 异步更新功能
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>

        [HttpPost]
        [Description("异步更新功能")]

        public async Task<AjaxResult> UpdateAsync([FromBody] FunctionInputDto dto)
        {

            return (await _functionService.UpdateAsync(dto)).ToAjaxResult();
        }

        /// <summary>
        /// 异步删除功能
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns></returns>

        [HttpDelete]
        [Description("异步删除功能")]
        public async Task<AjaxResult> DeleteAsync(Guid id)
        {

            return (await _functionService.DeleteAsync(id)).ToAjaxResult();

        }

        /// <summary>
        /// 异步得到功能分页
        /// </summary>
        /// <param name="request">请求分页参数</param>
        /// <returns></returns>
        [Description("异步得到功能分页")]
        [HttpPost]
        public async Task<PageList<FunctionOutputPageList>> GetFunctionPageAsync([FromBody] FunctionPageRequestDto request)
        {
            return (await _functionService.GetFunctionPageAsync(request)).ToPageList();
        }
        /// <summary>
        /// 异步获取功能下拉框列表
        /// </summary>
        /// <returns></returns>
        [Description("异步获取功能下拉框列表")]
        [HttpGet]
        public async Task<AjaxResult> GetFunctionSelectListItemAsync()
        {
            return (await _functionService.GetFunctionSelectListItemAsync()).ToAjaxResult();
        }

        /// <summary>
        /// 异步加载功能
        /// </summary>
        /// <returns></returns>
        [Description("异步加载功能")]
        [HttpGet]
        public async Task<AjaxResult> LoadAsync(Guid id)
        {

            return (await _functionService.LoadFormFunctionAsync(id)).ToAjaxResult();
        }

        /// <summary>
        /// 异步创建或更新功能
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("异步创建或更新功能")]
        public async Task<AjaxResult> AddOrUpdateAsync([FromBody] FunctionInputDto dto)
        {


            if (dto.Id == Guid.Empty)
            {
                return (await _functionService.CreateAsync(dto)).ToAjaxResult();
            }
            return (await _functionService.UpdateAsync(dto)).ToAjaxResult();
        }



    }
}
