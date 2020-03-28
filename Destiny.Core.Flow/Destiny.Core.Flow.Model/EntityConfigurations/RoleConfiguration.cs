using Destiny.Core.Flow.Model.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Model.EntityConfigurations
{
    public class RoleConfiguration : EntityMappingConfiguration<Role, Guid>
    {
        public override void Map(EntityTypeBuilder<Role> b)
        {
            b.HasKey(o => o.Id);
            b.Property(o => o.Name).HasMaxLength(10).IsRequired();
            b.Property(o => o.ConcurrencyStamp).HasMaxLength(256);
            b.Property(o => o.NormalizedName).HasMaxLength(50);
            b.Property(o => o.Description).HasMaxLength(500);
            b.Property(o => o.ConcurrencyStamp).IsConcurrencyToken();
            b.Property(o => o.IsDeleted).HasDefaultValue(false);
            b.Property(o => o.Code).HasMaxLength(20);
            b.ToTable("Role");
        }
    }
}
