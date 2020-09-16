using AutoMapper;
using Destiny.Core.Flow.Model.Entities.Menu;

namespace Destiny.Core.Flow.Dtos.Menu
{
    public class MenuTableProfile : Profile
    {
        public MenuTableProfile()
        {
            //CreateMap<MenuEntity, MenuTableOutDto>();
            CreateMap<MenuEntity, MenuPermissionsTreeOutDto>()
                .ForMember(x => x.access, opt => opt.MapFrom(s => s.Name))
                .ForMember(x => x.name, opt => opt.MapFrom(s => s.Name))
                .ForMember(x => x.icon, opt => opt.MapFrom(s => s.Icon))
                .ForMember(x => x.path, opt => opt.MapFrom(s => s.Path))
                .ForMember(x => x.component, opt => opt.MapFrom(s => s.Component))
                .ForMember(x => x.redirect, opt => opt.MapFrom(s => s.Redirect))
                ;
        }
    }
}