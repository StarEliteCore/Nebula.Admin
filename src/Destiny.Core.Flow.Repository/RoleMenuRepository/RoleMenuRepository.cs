using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Model.Entities.Rolemenu;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Destiny.Core.Flow.Repository.RoleMenuRepository
{
    [Dependency(ServiceLifetime.Scoped)]
    public class RoleMenuRepository : Repository<RolemenuEntity, Guid>, IRoleMenuRepository
    {
        public RoleMenuRepository(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }

    public interface IRoleMenuRepository : IEFCoreRepository<RolemenuEntity, Guid>
    {
    }
}