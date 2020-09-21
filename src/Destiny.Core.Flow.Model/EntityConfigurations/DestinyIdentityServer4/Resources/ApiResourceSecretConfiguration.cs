using Destiny.Core.Flow.Model.DestinyIdentityServer4;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Model.DestinyIdentityServer4.EntityConfigurations.IdentityServer4.Resources
{
    public class ApiResourceSecretConfiguration : EntityMappingConfiguration<ApiResourceSecret, Guid>
    {
        public override void Map(EntityTypeBuilder<ApiResourceSecret> b)
        {
            b.HasKey(o => o.Id);
            b.ToTable("ApiResourceSecret");
        }
    }
}
