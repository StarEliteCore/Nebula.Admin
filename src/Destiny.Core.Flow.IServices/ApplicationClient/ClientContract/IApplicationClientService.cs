using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Dtos.Application;
using Destiny.Core.Flow.Ui;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.IServices
{
    public interface IApplicationClientService : IScopedDependency
    {
        Task<OperationResponse> CreateAsync(ClientAddInputDto input);
    }
}
