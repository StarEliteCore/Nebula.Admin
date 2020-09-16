using Destiny.Core.Flow.Model.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Destiny.Core.Flow.Model.EntityConfigurations
{
    public class RoleClaimConfiguration : EntityMappingConfiguration<RoleClaim, Guid>
    {
        public override void Map(EntityTypeBuilder<RoleClaim> b)
        {
            b.HasKey(o => o.Id);
            b.Property(o => o.RoleId).IsRequired();
            b.Property(o => o.ClaimType).HasMaxLength(500);
            b.Property(o => o.ClaimValue).HasMaxLength(500);
            b.Property(o => o.IsDeleted).HasDefaultValue(false);
            b.ToTable("RoleClaim");
        }
    }
}