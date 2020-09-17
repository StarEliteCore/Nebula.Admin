using AutoMapper;
using Destiny.Core.Flow.Model.Entities.Menu;

namespace Destiny.Core.Flow.Dtos.Menu
{
    public class MenuProfile : Profile
    {
        public MenuProfile()
        {
            CreateMap<MenuEntity, MenuTreeOutDto>().
                ForMember(x => x.title, opt => opt.MapFrom(x => x.Name))
                .ForMember(x => x.Key, opt => opt.MapFrom(x => x.Id));
        }
    }
}