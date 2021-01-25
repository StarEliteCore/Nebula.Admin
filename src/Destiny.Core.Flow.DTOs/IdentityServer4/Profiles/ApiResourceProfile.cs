using AutoMapper;
using Destiny.Core.Flow.Model.DestinyIdentityServer4;
using System.Collections.Generic;

namespace Destiny.Core.Flow.Dtos.IdentityServer4.Profiles
{
    /// <summary>
    /// 资源APIProfile
    /// </summary>
    public class ApiResourceProfile : Profile
    {

        public ApiResourceProfile()
        {


            CreateMap<ApiResourceProperty, KeyValuePair<string, string>>()
              .ReverseMap();

            CreateMap<ApiResource, ApiResourceInputDto>(MemberList.Destination)
                .ConstructUsing(src => new ApiResourceInputDto())
                .ForMember(x => x.ApiSecrets, opts => opts.MapFrom(x => x.Secrets))
                .ForMember(x => x.AllowedAccessTokenSigningAlgorithms, opts => opts.ConvertUsing(AllowedSigningAlgorithmsConverter.Converter, x => x.AllowedAccessTokenSigningAlgorithms))
                .ReverseMap()
                .ForMember(x => x.AllowedAccessTokenSigningAlgorithms, opts => opts.ConvertUsing(AllowedSigningAlgorithmsConverter.Converter, x => x.AllowedAccessTokenSigningAlgorithms));


            CreateMap<ApiResourceSecret, ApiResourceSecretDto>(MemberList.Destination)
            .ForMember(dest => dest.Type, opt => opt.Condition(srs => srs != null))
            .ReverseMap();

            CreateMap<ApiResourceClaim, string>()
                .ConstructUsing(x => x.Type)
                .ReverseMap()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src));


            CreateMap<ApiResourceScope, string>()
                .ConstructUsing(x => x.Scope)
                .ReverseMap()
                .ForMember(dest => dest.Scope, opt => opt.MapFrom(src => src));


        }
    }
}
