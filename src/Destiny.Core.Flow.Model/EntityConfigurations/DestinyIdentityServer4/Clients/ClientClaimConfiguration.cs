using Destiny.Core.Flow.Model.DestinyIdentityServer4;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Destiny.Core.Flow.Model.DestinyIdentityServer4.EntityConfigurations.DestinyIdentityServer4.Clients
{
    public class ClientClaimConfiguration : EntityMappingConfiguration<ClientClaim, Guid>
    {
        public override void Map(EntityTypeBuilder<ClientClaim> b)
        {
            b.HasKey(o => o.Id);
            b.Ignore(x => x.Client);
            b.ToTable("ClientClaim");
        }
    }
}
