using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Ui;
using IDN.Services.BasicsService.Dtos.Application;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.IServices
{
    public interface IClientRedirectUriService : IScopedDependency
    {
        Task<OperationResponse> CreatAsync(ClientRedirectUriInputDto input);
    }
}
