
using Destiny.Core.Flow.Dtos;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.Ui;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.IServices.Users
{
   public interface IUserService
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
        Task<OperationResponse> UpdateAsync(UserInputDto dto);


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
        Task<PageResult<UserOutputPageListDto>> GetUserPageAsync(PageRequest request);
    }
}
