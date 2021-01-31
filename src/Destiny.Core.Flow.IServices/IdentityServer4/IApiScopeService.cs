using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Dtos.IdentityServer4;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.Filter.Abstract;
using Destiny.Core.Flow.Ui;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.IServices.IdentityServer4
{
    /// <summary>
    /// API范围服务
    /// </summary>
   public interface IApiScopeService : IScopedDependency
    {
        /// <summary>
        /// 异步创建API范围
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>

        Task<OperationResponse> CreateApiScopeAsync(ApiScopeDto dto);





        /// <summary>
        /// 异步得到API范围分页
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<IPagedResult<ApiScopeOutputPageListDto>> GetApiScopePageAsync(PageRequest request);


        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<OperationResponse> DeleteAsync(Guid id);
 

    }
}
