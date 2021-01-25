using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Dtos.IdentityServer4.ClientApplication;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.Filter.Abstract;
using Destiny.Core.Flow.Ui;
using System;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.IServices
{
    public interface IApplicationClientService : IScopedDependency
    {
        Task<OperationResponse> CreateAsync(ClientAddInputDto input);
        Task<IPagedResult<ClientOutputPageListDto>> GetPageAsync(PageRequest request);
        /// <summary>
        /// 删除客户端
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<OperationResponse> DeleteAsync(Guid id);
    }
}
