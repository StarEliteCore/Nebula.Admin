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
                .ForMember(x => x.Access, opt => opt.MapFrom(s => s.Name))
                .ForMember(x => x.Name, opt => opt.MapFrom(s => s.Name))
                .ForMember(x => x.Icon, opt => opt.MapFrom(s => s.Icon))
                .ForMember(x => x.Path, opt => opt.MapFrom(s => s.Path))
                .ForMember(x => x.Component, opt => opt.MapFrom(s => s.Component))
                .ForMember(x => x.Redirect, opt => opt.MapFrom(s => s.Redirect))
                ;
        }
    }
}