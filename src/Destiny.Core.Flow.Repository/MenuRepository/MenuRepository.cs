using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Model.Entities.Menu;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Destiny.Core.Flow.Repository.MenuRepository
{
    [Dependency(ServiceLifetime.Scoped)]
    public class MenuRepository : Repository<MenuEntity, Guid>, IMenuRepository
    {
        public MenuRepository(IServiceProvider serviceProvider) : base(serviceProvider)
        {

        }
    }

    public interface IMenuRepository : IEFCoreRepository<MenuEntity, Guid>
    {
    }
}