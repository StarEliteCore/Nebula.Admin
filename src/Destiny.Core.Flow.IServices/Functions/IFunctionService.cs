using Destiny.Core.Flow.Dtos.Functions;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.Filter.Abstract;
using Destiny.Core.Flow.Ui;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.IServices.Functions
{
    /// <summary>
    /// 功能
    /// </summary>
   public interface IFunctionService
    {
        /// <summary>
        /// 异步创建功能
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<OperationResponse> CreateAsync(FunctionInputDto dto);




        /// <summary>
        /// 删除功能
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<OperationResponse> DeleteAsync(Guid id);

        /// <summary>
        /// 更新功能
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<OperationResponse> UpdateAsync(FunctionInputDto dto);


        /// <summary>
        /// 异步加载表单功能
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<OperationResponse<FunctionOutputDto>> LoadFormFunctionAsync(Guid id);

        /// <summary>
        /// 异步得到功能分页
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IPagedResult<FunctionOutputPageList>> GetFunctionPageAsync(PageRequest request);
    }
}
