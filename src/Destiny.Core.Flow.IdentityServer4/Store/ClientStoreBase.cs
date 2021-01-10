using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Model.DestinyIdentityServer4;
using IdentityServer4.Stores;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.IdentityServer.Store
{
    public class ClientStoreBase : IClientStore
    {
        private readonly ILogger<ClientStoreBase> _logger;

        private readonly IRepository<Client, Guid> _clientRepository;
        private readonly IRepository<ClientGrantType, Guid> _clientGrantTypeRepository;

        public ClientStoreBase(ILogger<ClientStoreBase> logger, IRepository<Client, Guid> clientRepository, IRepository<ClientGrantType, Guid> clientGrantTypeRepository)
        {
            _logger = logger;
            _clientRepository = clientRepository;
            _clientGrantTypeRepository = clientGrantTypeRepository;
        }

        public async Task<IdentityServer4.Models.Client> FindClientByIdAsync(string clientId)
        {
            var client = await _clientRepository
                .Entities.Where(x => x.ClientId == clientId)
                .Include(x => x.AllowedCorsOrigins)
                .Include(x => x.AllowedGrantTypes)
                .Include(x => x.AllowedScopes)//退出登录回调的url
                .Include(x => x.Claims)
                .Include(x => x.ClientSecrets)
                .Include(x => x.IdentityProviderRestrictions)
                .Include(x => x.PostLogoutRedirectUris)
                .Include(x => x.Properties)
                .Include(x => x.RedirectUris)
                .SingleOrDefaultAsync();
            if (client == null)
                return null;
            var dto = client?.MapTo<IdentityServer4.Models.Client>();
            return dto;
        }
    }
}
