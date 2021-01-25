using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Dtos.IdentityServer4.ClientApplication;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.Filter.Abstract;
using Destiny.Core.Flow.Ui;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.IServices
{
    public interface IApplicationClientService : IScopedDependency
    {
        Task<OperationResponse> CreateAsync(ClientAddInputDto input);
        Task<IPagedResult<ClientOutputPageListDto>> GetPageAsync(PageRequest request);
    }
}
