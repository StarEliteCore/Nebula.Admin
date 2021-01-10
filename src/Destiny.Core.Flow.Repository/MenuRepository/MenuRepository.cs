using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Model.Entities.Menu;
using System;

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