using System.Threading.Tasks;

namespace Destiny.Core.Flow.IdentityServer
{
    public interface IClientRepository
    {
        Task<Client> FindByCliendIdAsync(string clientId);
    }
}
