using AutoMapper;
using Destiny.Core.Flow.Model.Entities.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Dtos.Menu
{
    public class MenuProfile : Profile
    {
        public MenuProfile()
        {
            CreateMap<MenuEntity, MenuOutDto>().ForMember(x => x.title, opt => opt.MapFrom(x => x.Name));
        }
                
    }
}
