using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Model.DestinyIdentityServer4;
using IdentityServer4.Stores;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.IdentityServer.Store
{
    public abstract class ClientStoreBase : IClientStore
    {

        private readonly IEFCoreRepository<Client, Guid> _clientRepository;

        public ClientStoreBase(IEFCoreRepository<Client, Guid> clientRepository)
        {
            _clientRepository = clientRepository;

        }

        public async Task<IdentityServer4.Models.Client> FindClientByIdAsync(string clientId)
        {
             await Task.CompletedTask;
            var client=await _clientRepository
                .Entities.Where(x => x.ClientId == clientId)
                .FirstOrDefaultAsync();
            var dto= client?.MapTo<IdentityServer4.Models.Client>();
            return dto;
        }
    }
}
