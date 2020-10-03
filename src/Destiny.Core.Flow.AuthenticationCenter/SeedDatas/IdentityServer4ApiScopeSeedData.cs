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
    public class IdentityServer4ApiScopeSeedData : SeedDataDefaults<ApiScope, Guid>
    {
       
        public IdentityServer4ApiScopeSeedData(IServiceProvider serviceProvider) : base(serviceProvider)
        {
         
        }

        protected override Expression<Func<ApiScope, bool>> Expression(ApiScope entity)
        {
            return o => o.Name == entity.Name;
        }

        protected override ApiScope[] SetSeedData()
        {
            List<ApiScope> apiScopes = new List<ApiScope>();
            foreach (var item in Config.GetApiScopes())
            {
                var model = item.MapTo<ApiScope>();
                model.CreatedTime = DateTime.Now;
                model.CreatorUserId = Guid.Parse("a1e89f45-4fa8-4751-9df9-dec86f7e6c14");
                model.IsDeleted = false;
                apiScopes.Add(model);
            }
            return apiScopes.ToArray();
        }
    }
}
