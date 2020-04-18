using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Dtos.Menu;
using Destiny.Core.Flow.ExpressionUtil;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.IServices.IMenu;
using Destiny.Core.Flow.Model.Entities.Menu;
using Destiny.Core.Flow.Repository.MenuRepository;
using Destiny.Core.Flow.Ui;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Services.Menu
{
    [Dependency(ServiceLifetime.Scoped)]
    public class MenuServices : IMenuServices
    {

        private readonly IMenuRepository _menuRepository = null;
        public MenuServices(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }
        public async Task<OperationResponse> CareateAsync(MenuInputDto input)
        {
            input.NotNull(nameof(input));
            var response = await _menuRepository.InsertAsync(input);
            return response;
        }

        public async Task<OperationResponse> DeleteAsync(Guid id)
        {
            return await _menuRepository.DeleteAsync(id);
        }


        public async Task<OperationResponse> UpdateAsync(MenuInputDto input)
        {
            input.NotNull(nameof(input));
            return await _menuRepository.UpdateAsync(input);
        }


        public async Task<PageResult<MenuOutPageListDto>> GetMenuPageAsync(PageRequest requst)
        {

            requst.NotNull(nameof(requst));
            //var expression = FilterHelp.GetExpression<MenuEntity>(requst.Filters);
            return await _menuRepository.TrackEntities.ToPageAsync<MenuEntity, MenuOutPageListDto>(requst);

        }
    }
}
