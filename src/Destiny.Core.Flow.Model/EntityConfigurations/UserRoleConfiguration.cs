using Destiny.Core.Flow.Model.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Destiny.Core.Flow.Model.EntityConfigurations
{
    public class UserRoleConfiguration : EntityMappingConfiguration<UserRole, Guid>
    {
        public override void Map(EntityTypeBuilder<UserRole> b)
        {
            b.HasKey(o => o.Id);
            b.Property(o => o.IsDeleted).HasDefaultValue(false);
            b.ToTable("UserRole");
        }
    }
}