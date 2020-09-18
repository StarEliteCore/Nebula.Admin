using Destiny.Core.Flow.Model.IdentityServer4;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Destiny.Core.Flow.Model.EntityConfigurations.IdentityServer4.Clients
{
    public class ClientCorsOriginConfiguration : EntityMappingConfiguration<ClientCorsOrigin, Guid>
    {
        public override void Map(EntityTypeBuilder<ClientCorsOrigin> b)
        {
            b.HasKey(o => o.Id);
            b.ToTable("ClientCorsOrigin");
        }
    }
}
