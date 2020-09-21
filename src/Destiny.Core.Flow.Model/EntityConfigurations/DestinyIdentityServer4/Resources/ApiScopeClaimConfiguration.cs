using Destiny.Core.Flow.Model.DestinyIdentityServer4;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Model.DestinyIdentityServer4.EntityConfigurations.IdentityServer4.Resources
{
    public class ApiScopeClaimConfiguration : EntityMappingConfiguration<ApiScopeClaim, Guid>
    {
        public override void Map(EntityTypeBuilder<ApiScopeClaim> b)
        {
            b.HasKey(o => o.Id);
            b.ToTable("ApiScopeClaim");
        }
    }
}
