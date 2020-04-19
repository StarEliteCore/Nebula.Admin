using AutoMapper;
using Destiny.Core.Flow.Model.Entities.Menu;

namespace Destiny.Core.Flow.Dtos.Menu
{
    public class MenuTableProfile : Profile
    {
        public MenuTableProfile()
        {
            CreateMap<MenuEntity, MenuTableOutDto>();
        }
    }
}