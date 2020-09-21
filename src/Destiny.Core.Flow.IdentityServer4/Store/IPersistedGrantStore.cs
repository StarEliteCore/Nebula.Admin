using Destiny.Core.Flow.Model.DestinyIdentityServer4;
using IdentityServer4.Stores;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.IdentityServer.Store
{
    public class PersistedGrantStoreBase : IPersistedGrantStore
    {
        private readonly IEFCoreRepository<PersistedGrant, Guid> _persistedGrantRepository;

        public PersistedGrantStoreBase(IEFCoreRepository<PersistedGrant, Guid> persistedGrantRepository)
        {
            _persistedGrantRepository = persistedGrantRepository;
        }

        public Task<IEnumerable<IdentityServer4.Models.PersistedGrant>> GetAllAsync(PersistedGrantFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task<IdentityServer4.Models.PersistedGrant> GetAsync(string key)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAllAsync(PersistedGrantFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(string key)
        {
            throw new NotImplementedException();
        }

        public Task StoreAsync(IdentityServer4.Models.PersistedGrant grant)
        {
            throw new NotImplementedException();
        }
    }
}
