using Destiny.Core.Flow.Entity;
using IdentityServer4.EntityFramework.Stores;
using IdentityServer4.Stores;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IdentityServer4.EntityFramework.Mappers;

namespace Destiny.Core.Flow.IdentityServer.Store
{
    public abstract class ClientStoreBase:IClientStore
    {

        //private readonly IEFCoreRepository<IdentityServer4.EntityFramework.Entities.Client, int> _clientRepository;

        //public ClientStoreBase(IEFCoreRepository<IdentityServer4.EntityFramework.Entities.Client, int> clientRepository)
        //{
        //    _clientRepository = clientRepository;

        //}

        public async Task<IdentityServer4.Models.Client> FindClientByIdAsync(string clientId)
        {
            await Task.CompletedTask;
            return new IdentityServer4.Models.Client();
        }
    }
}
