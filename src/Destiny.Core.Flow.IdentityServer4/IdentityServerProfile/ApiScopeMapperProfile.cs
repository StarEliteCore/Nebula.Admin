using AutoMapper;
using Destiny.Core.Flow.Model.DestinyIdentityServer4;
using System.Collections.Generic;
using System.Linq;

namespace Destiny.Core.Flow.IdentityServer.IdentityServerProfile
{
    public class ApiScopeMapperProfile : Profile
    {
        /// <summary>
        /// <see cref="ApiScopeMapperProfile"/>
        /// </summary>
        public ApiScopeMapperProfile()
        {
            CreateMap<ApiScopeProperty, KeyValuePair<string, string>>()
                .ReverseMap();

            CreateMap<ApiScopeClaim, string>()
               .ConstructUsing(x => x.Type)
               .ReverseMap()
               .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src));

            CreateMap<ApiScope,IdentityServer4. Models.ApiScope>(MemberList.Destination)
                .ConstructUsing(src => new IdentityServer4.Models.ApiScope())
                .ForMember(x => x.Properties, opts => opts.MapFrom(x => x.Properties))
                .ForMember(x => x.UserClaims, opts => opts.MapFrom(x => x.UserClaims))
                .ReverseMap();
        }
    }
}
