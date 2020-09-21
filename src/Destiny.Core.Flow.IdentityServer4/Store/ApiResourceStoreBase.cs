using Destiny.Core.Flow.Model.DestinyIdentityServer4;
using IdentityServer4.Stores;
using System;
using System.Collections.Generic;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Destiny.Core.Flow.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Destiny.Core.Flow.IdentityServer.Store
{
    public class ApiResourceStoreBase : IResourceStore
    {
        private readonly IEFCoreRepository<ApiResource, Guid> _apiResourceRepository;
        private readonly IEFCoreRepository<IdentityResource, Guid> _identityResourceRepository;
        private readonly IEFCoreRepository<ApiScope, Guid> _apiScopeRepository;
        private readonly ILogger<ApiResourceStoreBase> _logger;

        public ApiResourceStoreBase(IEFCoreRepository<ApiResource, Guid> apiResourceRepository, IEFCoreRepository<IdentityResource, Guid> identityResourceRepository, IEFCoreRepository<ApiScope, Guid> apiScopeRepository, ILogger<ApiResourceStoreBase> logger)
        {
            _apiResourceRepository = apiResourceRepository;
            _identityResourceRepository = identityResourceRepository;
            _apiScopeRepository = apiScopeRepository;
            _logger = logger;
        }

        public async Task<IEnumerable<IdentityServer4.Models.ApiResource>> FindApiResourcesByNameAsync(IEnumerable<string> apiResourceNames)
        {
            return await _apiResourceRepository.Entities.Where(x => apiResourceNames.Contains(x.Name))
                .Select(x => x.MapTo<IdentityServer4.Models.ApiResource>()).ToArrayAsync();
        }

        public async Task<IEnumerable<IdentityServer4.Models.ApiResource>> FindApiResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
        {
            return await _apiResourceRepository.Entities.Include(x => x.Scopes).Where(x => x.Scopes.Any(s => scopeNames.Contains(s.Scope)))
                .Select(x => x.MapTo<IdentityServer4.Models.ApiResource>()).ToArrayAsync();

        }

        public async Task<IEnumerable<IdentityServer4.Models.ApiScope>> FindApiScopesByNameAsync(IEnumerable<string> scopeNames)
        {
            return await _apiScopeRepository.Entities.Where(x => scopeNames.Contains(x.Name))
                .Select(x => x.MapTo<IdentityServer4.Models.ApiScope>()).ToArrayAsync();
        }

        public async Task<IEnumerable<IdentityServer4.Models.IdentityResource>> FindIdentityResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
        {
            return await _identityResourceRepository.Entities.Where(x => scopeNames.Contains(x.Name))
                .Select(x => x.MapTo<IdentityServer4.Models.IdentityResource>()).ToArrayAsync();
        }

        public async Task<IdentityServer4.Models.Resources> GetAllResourcesAsync()
        {
            var identityResources = await _identityResourceRepository.Entities.Select(x => x.MapTo<IdentityServer4.Models.IdentityResource>()).ToListAsync();
            var apiScopes = await _apiScopeRepository.Entities.Select(x => x.MapTo<IdentityServer4.Models.ApiScope>()).ToListAsync();
            var apiResources = await _apiResourceRepository.Entities.Select(x => x.MapTo<IdentityServer4.Models.ApiResource>()).ToListAsync();
            return new IdentityServer4.Models.Resources(identityResources, apiResources, apiScopes);
        }
    }
}
