using DestinyCore.Dependency;
using Destiny.Core.Flow.Model.Entities.Rolemenu;
using Microsoft.Extensions.DependencyInjection;
using System;
using DestinyCore.EntityFrameworkCore;
using DestinyCore;

namespace Destiny.Core.Flow.Repository.RoleMenuRepository
{
    [Dependency(ServiceLifetime.Scoped)]
    public class RoleMenuRepository : Repository<RoleMenuEntity, Guid>, IRoleMenuRepository
    {
        public RoleMenuRepository(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }

    public interface IRoleMenuRepository : IRepository<RoleMenuEntity, Guid>
    {
    }
}