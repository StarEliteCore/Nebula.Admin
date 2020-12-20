using Destiny.Core.Flow.AspNetCore.Api;
using Destiny.Core.Flow.AspNetCore.Mvc.Filters;
using Destiny.Core.Flow.AspNetCore.Ui;
using Destiny.Core.Flow.Dtos.RoleDtos;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.IServices.IRoleServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel;
using System.Threading.Tasks;


namespace Destiny.Core.Flow.API.Controllers
{
    /// <summary>
    /// 角色管理
    /// </summary>
    [Description("角色管理")]

    public class RoleController : AdminControllerBase
    {
        private readonly IRoleManagerServices _roleManagerServices = null;

        public RoleController(IRoleManagerServices roleManagerServices)
        {
            _roleManagerServices = roleManagerServices;
        }

        /// <summary>
        /// 异步得到分页
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Description("异步得到角色分页")]
        public async Task<PageList<RoleOutputPageListDto>> GetRolePageAsync([FromBody] PageRequest request)
        {

            return (await _roleManagerServices.GetRolePageAsync(request)).ToPageList();
        }

        /// <summary>
        /// 异步创建角色
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [Description("异步创建角色")]
        [HttpPost]
        public async Task<AjaxResult> CreateAsync([FromBody] RoleInputDto dto)
        {
            return (await _roleManagerServices.AddRoleAsync(dto)).ToAjaxResult();
        }

        /// <summary>
        /// 异步更新角色
        /// </summary>
        /// <param name="dto"></param>
        [Description("异步更新角色")]
        [HttpPut]
        public async Task<AjaxResult> UpdateAsync([FromBody] RoleInputDto dto)
        {
            return (await _roleManagerServices.UpdateRoleAsync(dto)).ToAjaxResult();
        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        [Description("异步删除角色")]
        [HttpDelete]
        public async Task<AjaxResult> DeleteAsync(Guid id)
        {
            return (await _roleManagerServices.DeleteAsync(id)).ToAjaxResult();
        }

        /// <summary>
        /// 异步创建或添加角色
        /// </summary>
        /// <param name="dto"></param>
        [Description("异步创建或添加角色")]
        [HttpPost]
        public async Task<AjaxResult> AddOrUpdateAsync([FromBody] RoleInputDto dto)
        {
            if (dto.Id == Guid.Empty)
            {
                return (await _roleManagerServices.AddRoleAsync(dto)).ToAjaxResult();
            }
            return (await _roleManagerServices.UpdateRoleAsync(dto)).ToAjaxResult();
        }

        /// <summary>
        /// 异步得到角色下拉数据
        /// </summary>
        /// <returns></returns>
        [Description("异步得到角色下拉数据")]
        [HttpGet]
        public async Task<AjaxResult> GetRoleSelectListAsync()
        {


            return (await _roleManagerServices.GetRolesToSelectListItemAsync()).ToAjaxResult();
        }

        /// <summary>
        /// 异步设置角色菜单
        /// </summary>
        /// <returns></returns>
        [Description("异步设置角色菜单")]
        [HttpPost]
        [ServiceFilter(typeof(UnitOfWorkAtrrribute))]
        public async Task<AjaxResult> SetRoleMenuAsync([FromQuery]Guid roleId, [FromBody]Guid[] menuIds)
        {


            return (await _roleManagerServices.SetRoleMenu(roleId,menuIds)).ToAjaxResult();
        }
    }
}
