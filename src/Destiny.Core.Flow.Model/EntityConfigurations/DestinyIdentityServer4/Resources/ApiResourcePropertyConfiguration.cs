using Destiny.Core.Flow.Model.DestinyIdentityServer4;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Model.DestinyIdentityServer4.EntityConfigurations.IdentityServer4.Resources
{
    public class ApiResourcePropertyConfiguration : EntityMappingConfiguration<ApiResourceProperty, Guid>
    {
        public override void Map(EntityTypeBuilder<ApiResourceProperty> b)
        {
            b.HasKey(o => o.Id);
            b.ToTable("ApiResourceProperty");
        }
    }
}
