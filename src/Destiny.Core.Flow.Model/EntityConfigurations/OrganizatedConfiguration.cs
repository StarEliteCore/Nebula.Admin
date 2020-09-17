using Destiny.Core.Flow.Model.Entities.Organizational;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Destiny.Core.Flow.Model.EntityConfigurations
{
    public class OrganizatedConfiguration : EntityMappingConfiguration<OrganizatedEntity, Guid>
    {
        public override void Map(EntityTypeBuilder<OrganizatedEntity> b)
        {
            b.HasKey(o => o.Id);
            b.Property(o => o.Name).HasMaxLength(50).IsRequired();
            b.Property(o => o.ParentId).HasDefaultValue(Guid.Empty);
            b.Property(o => o.LadingCadre).HasDefaultValue(Guid.Empty);
            b.Property(o => o.ParentNumber);
            b.Property(o => o.Depth).HasDefaultValue(0);
            b.ToTable("Organizated");
        }
    }
}