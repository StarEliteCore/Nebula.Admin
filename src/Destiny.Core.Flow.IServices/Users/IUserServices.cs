using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Dtos;
using Destiny.Core.Flow.Dtos.Users;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.Filter.Abstract;
using Destiny.Core.Flow.Ui;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.IServices
{
    public interface IUserServices : IScopedDependency
    {
        /// <summary>
        /// 异步创建用户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<OperationResponse> CreateAsync(UserInputDto dto);

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<OperationResponse> DeleteAsync(Guid id);

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<OperationResponse> UpdateAsync(UserUpdateInputDto dto);

        /// <summary>
        /// 异步加载表单用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<OperationResponse<UserOutputDto>> LoadFormUserAsync(Guid id);

        /// <summary>
        /// 异步得到用户分页
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IPagedResult<UserOutputPageListDto>> GetUserPageAsync(PageRequest request);

        /// <summary>
        /// 用户分配角色
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<OperationResponse> AllocationRoleAsync(UserAllocationRoleInputDto dto);

        /// <summary>
        /// 异步得到所有用户
        /// </summary>
        /// <returns></returns>

        Task<OperationResponse<List<UserOutputListDto>>> GetUsersAsync();
        /// <summary>
        /// 得到所有用户并转成下拉
        /// </summary>
        /// <returns></returns>
        Task<OperationResponse<IEnumerable<SelectListItem>>> GetUsersToSelectListItemAsync();
    }
}
