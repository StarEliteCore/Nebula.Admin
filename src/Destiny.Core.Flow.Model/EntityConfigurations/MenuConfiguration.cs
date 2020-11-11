using Destiny.Core.Flow.Model.Entities.Menu;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Destiny.Core.Flow.Model.EntityConfigurations
{
    public class MenuConfiguration : EntityMappingConfiguration<MenuEntity, Guid>
    {
        public override void Map(EntityTypeBuilder<MenuEntity> b)
        {
            b.HasKey(x => x.Id);
            b.Property(x => x.Name).HasMaxLength(50).IsRequired();
            b.Property(x => x.ParentId).HasDefaultValue(Guid.Empty);
            b.Property(x => x.Path).HasMaxLength(200).IsRequired();
            b.Property(x => x.Component).HasMaxLength(400).IsRequired();
            b.Property(x => x.Sort).HasDefaultValue(0);
            b.Property(x => x.Icon).HasMaxLength(50);
            b.Property(x => x.IsDeleted).HasDefaultValue(0);
            b.Property(x => x.Layout).HasMaxLength(500).IsRequired(false);
            b.Property(x => x.IsHide).HasDefaultValue(false);
            b.Property(x => x.EventName).HasMaxLength(100).IsRequired(false);
            b.ToTable("Menu");
        }
    }
}