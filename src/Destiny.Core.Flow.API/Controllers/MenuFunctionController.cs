using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Destiny.Core.Flow.AspNetCore.Api;
using Destiny.Core.Flow.AspNetCore.Ui;
using Destiny.Core.Flow.Dtos.Menu;
using Destiny.Core.Flow.Dtos.MenuFunction;
using Destiny.Core.Flow.IServices.IMenu;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Destiny.Core.Flow.API.Controllers
{
    /// <summary>
    /// 菜单功能
    /// </summary>
    [Description("菜单功能")]
    
    public class MenuFunctionController : AdminControllerBase
    {
        private readonly IMenuFunctionServices _menuFunctionServices;

        public MenuFunctionController(IMenuFunctionServices menuFunctionServices)
        {
            _menuFunctionServices = menuFunctionServices;
        }


        /// <summary>
        /// 批量添加功能菜单
        /// </summary>
        /// <param name="menuFunctionInputDto">输入DTO</param>
        /// <returns></returns>
        [HttpPost]
        [Description("批量添加功能菜单")]
        public async Task<AjaxResult> BatchAddMenuFunctionAsync([FromBody] BatchAddMenuFunctionInputDto menuFunctionInputDto)
        {
            return (await _menuFunctionServices.BatchAddMenuFunctionAsync(menuFunctionInputDto)).ToAjaxResult();
        }


        /// <summary>
        /// 批量删除功能菜单
        /// </summary>
        /// <param name="menuFunctionInputDto">输入DTO</param>
        /// <returns></returns>
        [HttpDelete]
        [Description("批量删除功能菜单")]
        public async Task<AjaxResult> BatchDeleteMenuFunctionAsync([FromBody]MenuFunctionInputDto menuFunctionInputDto)
        {
      
            return (await _menuFunctionServices.BatchDeleteMenuFunctionAsync(menuFunctionInputDto)).ToAjaxResult();
        }


        /// <summary>
        /// 根据菜单ID得到菜单功能分页
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("根据菜单ID得到菜单功能分页")]
        public async Task<PageList<MenuFunctionOutPageListDto>> GetMenuFunctionByMenuIdPageAsync([FromBody] MenuFunctionPageRequestDto request)
        {
            return (await _menuFunctionServices.GetMenuFunctionByMenuIdPageAsync(request)).ToPageList();
        }
    }
}
