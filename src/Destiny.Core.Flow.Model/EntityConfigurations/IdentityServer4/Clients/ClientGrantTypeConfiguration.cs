using Destiny.Core.Flow.Model.IdentityServer4;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Destiny.Core.Flow.Model.EntityConfigurations.IdentityServer4.Clients
{
    public class ClientGrantTypeConfiguration : EntityMappingConfiguration<ClientGrantType, Guid>
    {
        public override void Map(EntityTypeBuilder<ClientGrantType> b)
        {
            b.HasKey(o => o.Id);
            b.ToTable("ClientGrantType");
        }
    }
}
