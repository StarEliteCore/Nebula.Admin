using Destiny.Core.Flow.AspNetCore.Ui;
using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Dtos.Menu;
using Destiny.Core.Flow.Dtos.MenuFunction;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.Filter.Abstract;
using Destiny.Core.Flow.Ui;
using System;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.IServices.IMenu
{
    /// <summary>
    /// 菜单功能
    /// </summary>
    public interface IMenuFunctionServices : IScopedDependency
    {
        /// <summary>
        /// 根据菜单ID得到菜单功能分页
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IPagedResult<MenuFunctionOutPageListDto>> GetMenuFunctionByMenuIdPageAsync(MenuFunctionPageRequestDto request);


        /// <summary>
        /// 批量添加功能菜单
        /// </summary>
        /// <param name="menuFunctionInputDto">输入DTO</param>
        /// <returns></returns>

        Task<OperationResponse> BatchAddMenuFunctionAsync(MenuFunctionInputDto menuFunctionInputDto);


        /// <summary>
        /// 批量删除功能菜单
        /// </summary>
        /// <param name="menuFunctionInputDto">输入DTO</param>
        /// <returns></returns>

        Task<OperationResponse> BatchDeleteMenuFunctionAsync(MenuFunctionInputDto menuFunctionInputDto);
    }
}