using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.IdentityServer;
using Destiny.Core.Flow.Model.DestinyIdentityServer4;
using Destiny.Core.Flow.Model.SeedDatas;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Destiny.Core.Flow.AuthenticationCenter.SeedDatas
{
    [Dependency(ServiceLifetime.Singleton)]
    public class IdentityServer4ApiResourceSeedData : SeedDataDefaults<ApiResource, Guid>
    {
    
        public IdentityServer4ApiResourceSeedData(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        
        }

        protected override Expression<Func<ApiResource, bool>> Expression(ApiResource entity)
        {
            return o => o.Name == entity.Name;
        }

        protected override ApiResource[] SetSeedData()
        {
            List<ApiResource> apiResources = new List<ApiResource>();
            foreach (var item in Config.GetApiResources())
            {
                var model = item.MapTo<ApiResource>();
                model.CreatedTime = DateTime.Now;
                model.CreatorUserId = Guid.Parse("a1e89f45-4fa8-4751-9df9-dec86f7e6c14");
                model.IsDeleted = false;
                apiResources.Add(model);
            }
            return apiResources.ToArray();
        }
    }
}
