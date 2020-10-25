using Destiny.Core.Flow.AspNetCore.Api;
using Destiny.Core.Flow.AspNetCore.Ui;
using Destiny.Core.Flow.Dtos.Organization;
using Destiny.Core.Flow.IServices.Organization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.API.Controllers.Organization
{
    /// <summary>
    /// 组织架构管理
    /// </summary>
    [Description("组织架构管理")]
    public class OrganizationController : AuthorizeControllerBase
    {
        private readonly IOrganizationService _organization;

        public OrganizationController(IOrganizationService organization)
        {
            _organization = organization;
        }
        /// <summary>
        /// 获取组织架构
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpGet]
        [Description("获取组织架构")]
        public async Task<TreeModel<OrganizationOutDto>> GetAsync()
        {

            var result = await _organization.GetOrganization();
            return new TreeModel<OrganizationOutDto>()
            {
                ItemList = result.ItemList,
                Message = result.Message,
                Success = result.Success
            };
        }

        /// <summary>
        /// 异步创建组织架构
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("异步创建组织架构")]
        public async Task<AjaxResult> CreateAsync([FromBody] OrganizationInputDto dto)
        {

            return (await _organization.CreateAsync(dto)).ToAjaxResult();
        }
        /// <summary>
        /// 异步修改组织架构
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPut]
        [Description("异步修改组织架构")]
        public async Task<AjaxResult> UpdateAsync([FromBody] OrganizationInputDto dto)
        {

            return (await _organization.UpdateAsync(dto)).ToAjaxResult();
        }
        /// <summary>
        /// 异步删除组织架构
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        [Description("异步删除组织架构")]
        public async Task<AjaxResult> DeleteAsync(Guid id)
        {

            return (await _organization.DeleteAsync(id)).ToAjaxResult();
        }
    }
}