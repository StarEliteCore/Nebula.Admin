using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Model.Entities.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq.Expressions;

namespace Destiny.Core.Flow.Model.SeedDatas
{
    [Dependency(ServiceLifetime.Singleton)]
    public class RoleSeedData : SeedDataDefaults<Role, Guid>
    {
        public RoleSeedData(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        protected override Expression<Func<Role, bool>> Expression(Role entity)
        {
            return o => o.Name == entity.Name;
        }

        protected override Role[] SetSeedData()
        {
            return new Role[]{  new Role()
            {
                Id = Guid.Parse("B8551E97-0723-47FC-BD7E-AFF35BB1B1E7"),
                Name = "系统管理员",
                NormalizedName = "系统管理员",
                ConcurrencyStamp = Guid.NewGuid().ToString(),
                CreatorUserId = Guid.Parse("a1e89f45-4fa8-4751-9df9-dec86f7e6c14"),
                CreatedTime = DateTime.Now,
                IsDeleted = false,
                Description = "拥有系统上所有有权限请不要删除!",
                IsAdmin = true
            }};
        }
    }
}