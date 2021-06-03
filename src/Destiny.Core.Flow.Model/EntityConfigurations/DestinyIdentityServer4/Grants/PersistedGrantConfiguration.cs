using Destiny.Core.Flow.Model.DestinyIdentityServer4;
using DestinyCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Destiny.Core.Flow.Model.DestinyIdentityServer4.EntityConfigurations.IdentityServer4.Grants
{
    public class PersistedGrantConfiguration : EntityMappingConfiguration<PersistedGrant, Guid>
    {
        public override void Map(EntityTypeBuilder<PersistedGrant> b)
        {
            b.HasKey(o => o.Id);
            b.ToTable("PersistedGrant");
        }
    }
}
