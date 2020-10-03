using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.IdentityServer;
using Destiny.Core.Flow.Model.DestinyIdentityServer4;
using Destiny.Core.Flow.Model.SeedDatas;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Destiny.Core.Flow.AuthenticationCenter.SeedDatas
{
    [Dependency(ServiceLifetime.Singleton)]
    public class IdentityServer4ClientSeedData : SeedDataDefaults<Client, Guid>
    {
   
        public IdentityServer4ClientSeedData(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        
        }
        protected override Expression<Func<Client, bool>> Expression(Client entity)
        {
            return o => o.ClientId == entity.ClientId;
        }
        protected override Client[] SetSeedData()
        {
            List<Client> clients = new List<Client>();
            foreach (var item in Config.GetClients())
            {
                var model = item.MapTo<Client>();
                model.CreatedTime = DateTime.Now;
                model.CreatorUserId = Guid.Parse("a1e89f45-4fa8-4751-9df9-dec86f7e6c14");
                model.IsDeleted = false;
                clients.Add(model);
            }
            return clients.ToArray();
        }
    }
}
