using Destiny.Core.Flow.Model.Entities.Rolemenu;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Destiny.Core.Flow.Model.EntityConfigurations
{
    public class RolemenuConfiguration : EntityMappingConfiguration<RoleMenuEntity, Guid>
    {
        public override void Map(EntityTypeBuilder<RoleMenuEntity> b)
        {
            b.HasKey(p => p.Id);
            b.Property(p => p.RoleId);
            b.Property(p => p.MenuId);
            b.ToTable("RoleMenu");
        }
    }
}