using AutoMapper;
using Destiny.Core.Flow.Model.Entities.Dictionary;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Dtos.DataDictionnary
{
    public class DataDictionaryProfile : Profile
    {
        public DataDictionaryProfile()
        {
            CreateMap<DataDictionaryEntity, DataDictionaryOutDto>().ForMember(x => x.Title, opt => opt.MapFrom(x => x.Title)).ForMember(x => x.Key, opt => opt.MapFrom(x => x.Id));
        }
    }
}
