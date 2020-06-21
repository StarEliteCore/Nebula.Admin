using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Destiny.Core.Flow.AspNetCore.Api;
using Destiny.Core.Flow.AspNetCore.Ui;
using Destiny.Core.Flow.Dtos;
using Destiny.Core.Flow.Dtos.Menu;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.IServices.IMenu;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Destiny.Core.Flow.API.Controllers.Menu
{
    [Description("角色管理")]
    //[Authorize]
    public class MenuController : ApiControllerBase
    {
        private readonly IMenuServices _menuServices;

        public MenuController(IMenuServices menuServices)
        {
            _menuServices = menuServices;
        }

        /// <summary>
        /// 根据角色Id获取树形菜单信息
        /// </summary>
        /// <param name="roleid">角色Id</param>
        /// <returns></returns>
        [HttpGet]
        [Description("获取树形菜单信息")]
        public async Task<TreeModel<MenuOutDto>> GetTreeAsync(Guid roleid)
        {
            var result = await _menuServices.GetMenuAsync(roleid);
            return result.ToTreeModel();
        }
        /// <summary>
        /// 获取表格菜单信息
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpGet]
        [Description("获取表格菜单信息")]
        public async Task<TreeModel<MenuTableOutDto>> GetTableAsync()
        {
            var result = await _menuServices.GetMenuTableAsync();
            return new TreeModel<MenuTableOutDto>()
            {
                ItemList = result.ItemList,
                Message = result.Message,
                Success = result.Success
            };
        }
        /// <summary>
        /// 添加菜单
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Description("添加菜单")]
        public async Task<AjaxResult> AddMenuAsync([FromBody]MenuInputDto dto)
        {
            if (dto.Id == Guid.Empty)
            {
                return (await _menuServices.CareateAsync(dto)).ToAjaxResult();
            }
            return (await _menuServices.UpdateAsync(dto)).ToAjaxResult();
        }
        /// <summary>
        /// 修改菜单
        /// </summary>
        /// <returns></returns>
        [HttpPut]
        [Description("修改菜单")]
        public async Task<AjaxResult> UpdateMenuAsync([FromBody] MenuInputDto dto)
        {
            return (await _menuServices.UpdateAsync(dto)).ToAjaxResult();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        [Description("删除菜单")]
        public async Task<AjaxResult> DeleteAsync(Guid? id)
        {
            return (await _menuServices.DeleteAsync(id.Value)).ToAjaxResult();
        }

        /// <summary>
        /// 异步得到菜单树数据
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Description("异步得到菜单树数据")]

        public async Task<TreeModel<MenuEntityItem>> GetMenuTreeAsync()
        {
            return (await _menuServices.GetMenuTreeAsync()).ToTreeModel();
        }
    }
}