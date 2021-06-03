using Destiny.Core.Flow.Model.DestinyIdentityServer4;
using DestinyCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Destiny.Core.Flow.Model.DestinyIdentityServer4.EntityConfigurations.IdentityServer4.Clients
{
    public class ClientRedirectUriConfiguration : EntityMappingConfiguration<ClientRedirectUri, Guid>
    {
        public override void Map(EntityTypeBuilder<ClientRedirectUri> b)
        {
            b.HasKey(o => o.Id);
            b.ToTable("ClientRedirectUri");
        }
    }
}
