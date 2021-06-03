using DestinyCore.Dependency;
using Destiny.Core.Flow.Model.Entities.Menu;
using Microsoft.Extensions.DependencyInjection;
using System;
using DestinyCore.EntityFrameworkCore;
using DestinyCore;

namespace Destiny.Core.Flow.Repository.MenuRepository
{
    /// <summary>
    /// 菜单功能
    /// </summary>
    [Dependency(ServiceLifetime.Scoped)]
    public class MenuFunctionRepository : Repository<MenuFunction, Guid>, IMenuFunctionRepository
    {
        public MenuFunctionRepository(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }

    public interface IMenuFunctionRepository : IRepository<MenuFunction, Guid>
    {
    }
}