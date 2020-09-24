using AutoMapper;
using Destiny.Core.Flow.Model.DestinyIdentityServer4;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.IdentityServer.IdentityServerProfile
{
    public class PersistedGrantMapperProfile: Profile
    {
        public PersistedGrantMapperProfile()
        {
            CreateMap<PersistedGrant, IdentityServer4.Models.PersistedGrant>(MemberList.Destination)
                .ReverseMap();
        }
    }
}
