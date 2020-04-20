using Destiny.Core.Flow.AspNetCore.Ui;
using Destiny.Core.Flow.Dtos.Menu;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.Ui;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.IServices.IMenu
{
    public interface IMenuServices
    {
        /// <summary>
        /// 创建一个菜单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<OperationResponse> CareateAsync(MenuInputDto input);

        /// <summary>
        /// 删除一个菜单
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<OperationResponse> DeleteAsync(Guid id);

        /// <summary>
        /// 修改菜单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<OperationResponse> UpdateAsync(MenuInputDto input);

        /// <summary>
        /// 分页查询菜单
        /// </summary>
        /// <param name="requst"></param>
        /// <returns></returns>
        Task<PageResult<MenuOutPageListDto>> GetMenuPageAsync(PageRequest requst);

        /// <summary>
        /// 查询菜单
        /// </summary>
        /// <returns></returns>
        Task<TreeResult<MenuOutDto>> GetMenuAsync();
        /// <summary>
        /// 返回表格
        /// </summary>
        /// <param name="requst"></param>
        /// <returns></returns>
        Task<PageResult<MenuTableOutDto>> GetMenuTableAsync(PageRequest requst);
    }
}