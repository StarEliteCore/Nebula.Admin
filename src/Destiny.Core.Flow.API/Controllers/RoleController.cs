using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Destiny.Core.Flow.IServices.IRoleServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Destiny.Core.Flow.AspNetCore.Ui;
using Destiny.Core.Flow.Dtos.RoleDtos;
using Destiny.Core.Flow.AspNetCore.Api;

namespace Destiny.Core.Flow.API.Controllers
{
    /// <summary>
    /// 角色管理
    /// </summary>
    [Description("角色管理")]
    public class RoleController : ApiControllerBase
    {
        private readonly IRoleManagerServices _roleManagerServices = null;

        public RoleController(IRoleManagerServices roleManagerServices)
        {
            _roleManagerServices = roleManagerServices;
        }

        // GET: api/Role
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        /// <summary>
        /// 
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
        /// 
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
        public async Task<AjaxResult> Delete(Guid? id)
        {
            return (await _roleManagerServices.DeleteAsync(id.Value)).ToAjaxResult();
        }
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="dto"></param>
        [Description("异步创建或添加角色")]
        [HttpPost]
        public async Task<AjaxResult> AddOrUpdateAsync([FromBody] RoleInputDto dto)
        {
            if(dto.Id==Guid.Empty)
            {
                return (await _roleManagerServices.AddRoleAsync(dto)).ToAjaxResult();
            }
            return (await _roleManagerServices.UpdateRoleAsync(dto)).ToAjaxResult();
        }
    }
}
