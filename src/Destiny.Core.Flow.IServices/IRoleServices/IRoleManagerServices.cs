using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Dtos.RoleDtos;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.Filter.Abstract;
using Destiny.Core.Flow.Ui;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.IServices.IRoleServices
{
    public interface IRoleManagerServices : IScopedDependency
    {
        /// <summary>
        /// 添加角色
        /// </summary>
        /// <returns></returns>
        Task<OperationResponse> AddRoleAsync(RoleInputDto dto);

        /// <summary>
        /// 修改角色
        /// </summary>
        /// <returns></returns>
        Task<OperationResponse> UpdateRoleAsync(RoleInputDto dto);

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<OperationResponse> DeleteAsync(Guid id);

        Task<OperationResponse<IEnumerable<SelectListItem>>> GetRolesToSelectListItemAsync();

        /// <summary>
        /// 分页查询角色
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IPagedResult<RoleOutputPageListDto>> GetRolePageAsync(PageRequest request);

        /// <summary>
        /// 设置角色菜单
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <param name="menuIds">菜单ID集合</param>
        /// <returns></returns>
        Task<OperationResponse> SetRoleMenu(Guid roleId, Guid[] menuIds);
    }
}