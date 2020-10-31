using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Dtos.Menu;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.Filter.Abstract;
using Destiny.Core.Flow.Model.Entities.Menu;
using Destiny.Core.Flow.Ui;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.IServices.IMenu
{
    public interface IMenuServices : IScopedDependency
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

        /// <summary>
        /// 根据登录的用户获取角色并获取菜单
        /// </summary>
        /// <returns></returns>
        Task<OperationResponse<Dictionary<string, bool>>> GetMenuAsync();

        /// <summary>
        /// 异步得到菜单下的按钮
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<OperationResponse<List<MenuOutputLoadDto>>> GetMenuChildrenButton(Guid Id);

        /// <summary>
        /// 获取菜单树形
        /// </summary>
        /// <returns></returns>
        Task<OperationResponse> GetUserMenuTreeAsync();

        /// <summary>
        /// 获取有权限的菜单列表
        /// </summary>
        /// <returns></returns>
        Task<OperationResponse> GetMenuListAsync();

        /// <summary>
        /// 异步得到所有菜单
        /// </summary>
        /// <returns></returns>
        Task<TreeResult<MenuTreeOutDto>> GetAllMenuTreeAsync(MenuEnum menu = MenuEnum.Menu);


        /// <summary>
        /// 得到菜单分页数据（不是树，只是普通表格）
        /// </summary>
        /// <param name="request">请求参数</param>
        /// <returns></returns>
        Task<IPagedResult<MenuOutPageListDto>> GetMenuPageAsync(PageRequest request);
    }
}