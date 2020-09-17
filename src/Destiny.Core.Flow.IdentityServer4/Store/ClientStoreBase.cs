using IdentityServer4.Stores;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.IdentityServer.Store
{
    public abstract class ClientStoreBase : IClientStore
    {

        //private readonly IEFCoreRepository<IdentityServer4.EntityFramework.Entities.Client, int> _clientRepository;

        //public ClientStoreBase(IEFCoreRepository<IdentityServer4.EntityFramework.Entities.Client, int> clientRepository)
        //{
        //    _clientRepository = clientRepository;

        //}

        public async Task<IdentityServer4.Models.Client> FindClientByIdAsync(string clientId)
        {
            await Task.CompletedTask;
            //IdentityServer4.EntityFramework.Entities.Client
            return new IdentityServer4.Models.Client();
        }
    }
}
