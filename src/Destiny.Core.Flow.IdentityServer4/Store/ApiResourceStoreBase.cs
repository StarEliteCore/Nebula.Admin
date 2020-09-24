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
        private readonly IEFCoreRepository<ApiResourceScope, Guid> _apiResourceScopeRepository;


        private readonly ILogger<ApiResourceStoreBase> _logger;

        public ApiResourceStoreBase(IEFCoreRepository<ApiResource, Guid> apiResourceRepository, IEFCoreRepository<IdentityResource, Guid> identityResourceRepository, IEFCoreRepository<ApiScope, Guid> apiScopeRepository, ILogger<ApiResourceStoreBase> logger, IEFCoreRepository<ApiResourceScope, Guid> apiResourceScopeRepository)
        {
            _apiResourceRepository = apiResourceRepository;
            _identityResourceRepository = identityResourceRepository;
            _apiScopeRepository = apiScopeRepository;
            _logger = logger;
            _apiResourceScopeRepository = apiResourceScopeRepository;
        }

        public async Task<IEnumerable<IdentityServer4.Models.ApiResource>> FindApiResourcesByNameAsync(IEnumerable<string> apiResourceNames)
        {

            var apis = await _apiResourceRepository.Entities.Where(x => apiResourceNames.Contains(x.Name))
                .Include(x => x.Secrets)
                .Include(x => x.Scopes).
                Include(x => x.UserClaims)
                .Include(x => x.Properties).ToArrayAsync();
            return apis.Select(x => x.MapTo<IdentityServer4.Models.ApiResource>());
        }

        public async Task<IEnumerable<IdentityServer4.Models.ApiResource>> FindApiResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
        {
            var query = from api in _apiResourceRepository.Entities
                        where api.Scopes.Where(x => scopeNames.Contains(x.Scope)).Any()
                        select api;
            var apis = await query.Include(x => x.Secrets)
                .Include(x => x.Scopes)
                .Include(x => x.UserClaims)
                .Include(x => x.Properties).ToListAsync();
            var results = apis.Where(api => api.Scopes.Any(x => scopeNames.Contains(x.Scope)));
            return results.Select(x => x.MapTo<IdentityServer4.Models.ApiResource>());

        }

        public async Task<IEnumerable<IdentityServer4.Models.IdentityResource>> FindIdentityResourcesByScopeNameAsync(IEnumerable<string> scopeNames)
        {
            return (await _identityResourceRepository.Entities.Where(x => scopeNames.Contains(x.Name)).Include(x => x.UserClaims).Include(x => x.Properties).ToListAsync()).Where(x => scopeNames.Contains(x.Name)).Select(x => x.MapTo<IdentityServer4.Models.IdentityResource>());
        }


        public async Task<IEnumerable<IdentityServer4.Models.ApiScope>> FindApiScopesByNameAsync(IEnumerable<string> scopeNames)
        {

            return (await _apiScopeRepository.Entities.Where(x => scopeNames.Contains(x.Name)).Include(x => x.UserClaims).Include(x => x.Properties).ToListAsync()).Where(x => scopeNames.Contains(x.Name)).Select(x => x.MapTo<IdentityServer4.Models.ApiScope>());
            
        }
        public async Task<IdentityServer4.Models.Resources> GetAllResourcesAsync()
        {
            var identityResources = ( await _identityResourceRepository.Entities.Include(x => x.UserClaims).Include(x => x.Properties).ToListAsync()).Select(x=>x.MapTo<IdentityServer4.Models.IdentityResource>());
           var apiResources =  (await _apiResourceRepository.Entities.Include(x => x.Secrets)
                .Include(x => x.Scopes)
                .Include(x => x.UserClaims)
                .Include(x => x.Properties).ToListAsync()).Select(x=>x.MapTo<IdentityServer4.Models.ApiResource>());
            var apiScopes = (await _apiScopeRepository.Entities.Include(x => x.UserClaims)
                .Include(x => x.Properties).ToListAsync()).Select(x=>x.MapTo<IdentityServer4.Models.ApiScope>());
            return new IdentityServer4.Models.Resources(identityResources, apiResources, apiScopes);
        }
    }
}
