using Destiny.Core.Flow.AspNetCore.Ui;
using Destiny.Core.Flow.Dtos;
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

        //Task<OperationResponse> GetTreeSelectTreeDataAsync();
        /// <summary>
        /// 创建一个菜单
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        Task<OperationResponse> CreateAsync(MenuInputDto input);

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
        /// 查询菜单
        /// </summary>
        /// <returns></returns>
        Task<OperationResponse<SelectedItem<MenuTreeOutDto, Guid>>> GetMenuTreeAsync(Guid? roleId);
        /// <summary>
        /// 返回表格
        /// </summary>
        /// <param name="requst"></param>
        /// <returns></returns>
        Task<TreeResult<MenuTableOutDto>> GetMenuTableAsync();
        ///// <summary>
        ///// 异步得到菜单树
        ///// </summary>
        ///// <returns></returns>
        //Task<TreeResult<MenuEntityItem>> GetMenuTreeAsync();
        /// <summary>
        /// 根据ID获取一个菜单
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<OperationResponse<MenuOutputLoadDto>> LoadFormMenuAsync(Guid Id);
    }
}