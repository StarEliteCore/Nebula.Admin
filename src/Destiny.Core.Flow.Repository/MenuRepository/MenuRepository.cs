using DestinyCore.Dependency;
using Destiny.Core.Flow.Model.Entities.Menu;
using System;
using DestinyCore;
using DestinyCore.EntityFrameworkCore;

namespace Destiny.Core.Flow.Repository.MenuRepository
{
    public class MenuRepository : Repository<MenuEntity, Guid>, IMenuRepository
    {
        public MenuRepository(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }

    public interface IMenuRepository : IRepository<MenuEntity, Guid>, IScopedDependency
    {
    }
}