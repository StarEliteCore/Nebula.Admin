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
    public class IdentityServer4IdentityResourceSeedData : SeedDataDefaults<IdentityResource, Guid>
    {
 



        public IdentityServer4IdentityResourceSeedData(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        
        }

        protected override Expression<Func<IdentityResource, bool>> Expression(IdentityResource entity)
        {
            return o => o.Name == entity.Name;
        }
        protected override IdentityResource[] SetSeedData()
        {


            List<IdentityResource> identityResources = new List<IdentityResource>();
            foreach (var item in Config.GetIdentityResources())
            {
                var model = item.MapTo<IdentityResource>();
                model.CreatedTime = DateTime.Now;
                model.CreatorUserId = Guid.Parse("a1e89f45-4fa8-4751-9df9-dec86f7e6c14");
                model.IsDeleted = false;
                identityResources.Add(model);
            }
            return identityResources.ToArray();
        }
    }



 

}
