using AutoMapper;
using Destiny.Core.Flow.Model.Entities.Organizational;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Dtos.Organization
{
   public class OrganizationProfile: Profile
    {

        public OrganizationProfile()
        {
            CreateMap<OrganizatedEntity, OrganizationOutDto>().ForMember(x => x.title, opt => opt.MapFrom(x => x.Name));
        }
    }
}
