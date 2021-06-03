using DestinyCore.Dependency;
using Destiny.Core.Flow.Dtos.IdentityServer4.ClientApplication;
using DestinyCore.Filter;
using DestinyCore.Filter.Abstract;
using DestinyCore.Ui;
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
        OperationResponse GetGrantTypeSelectItem();
    }
}
