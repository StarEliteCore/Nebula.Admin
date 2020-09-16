using Destiny.Core.Flow.Dtos.MenuFunction;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.Filter.Abstract;
using Destiny.Core.Flow.IServices.IMenu;
using Destiny.Core.Flow.Model.Entities.Function;
using Destiny.Core.Flow.Model.Entities.Menu;
using Destiny.Core.Flow.Repository.MenuRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Services.Menu
{
    public class MenuFunctionServices : IMenuFunctionServices
    {
        private readonly IMenuFunctionRepository _menuFunctionRepository = null;
        private readonly IEFCoreRepository<Function, Guid> _functionRepository;
        private readonly IMenuRepository _menuRepository = null;

        public MenuFunctionServices(IMenuFunctionRepository menuFunctionRepository, IEFCoreRepository<Function, Guid> functionRepository, IMenuRepository menuRepository)
        {
            _menuFunctionRepository = menuFunctionRepository;
            _functionRepository = functionRepository;
            _menuRepository = menuRepository;
        }

        public async Task<IPagedResult<MenuFunctionOutPageListDto>> GetMenuFunctionListAsync(Guid menuId)
        {
            Action<MenuEntity, ICollection<MenuEntity>> menuItem = null;
            List<Guid> menuIds = new List<Guid>();
            menuItem = (dto, suoure) =>
            {
                var childs = suoure.Where(o => o.ParentId == dto.Id).ToList();
                if (!childs.Any())
                {
                    menuIds.Add(dto.Id);
                }
                foreach (var item in childs)
                {
                    menuIds.Add(item.Id);
                    menuItem(item, suoure);
                }
            };
            var roots = _menuRepository.Entities;
            var menuList = await roots.Where(o => o.Id == menuId).ToListAsync();
            var suoures = await roots.Where(o => o.ParentId == Guid.Empty).ToListAsync();
            foreach (var menu in menuList)
            {
                menuItem(menu, suoures);
            }
            var functionIds = _menuFunctionRepository.Entities.Where(mf => menuIds.Contains(mf.MenuId)).Select(o => o.FunctionId);
            var functionList = await _functionRepository.Entities.Where(f => functionIds.Contains(f.Id)).Select(o => new MenuFunctionOutPageListDto()
            {
                Description = o.Description,
                LinkUrl = o.LinkUrl,
                Name = o.Name
            }).ToListAsync();
            return new PageResult<MenuFunctionOutPageListDto>()
            {
                ItemList = functionList,
                Total = functionList.Count()
            };
        }
    }
}