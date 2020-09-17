using Destiny.Core.Flow.Model.Entities.Function;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Destiny.Core.Flow.Model.EntityConfigurations
{
    public class FunctionConfiguration : EntityMappingConfiguration<Function, Guid>
    {
        public override void Map(EntityTypeBuilder<Function> b)
        {
            b.HasKey(o => o.Id);
            b.Property(o => o.Name).HasMaxLength(50).IsRequired();

            b.Property(o => o.LinkUrl).HasMaxLength(500);
            b.Property(o => o.IsDeleted).HasDefaultValue(false).IsRequired();
            b.Property(o => o.IsEnabled).HasDefaultValue(true);
            b.Property(o => o.Description).HasMaxLength(1000);
            b.ToTable("Function");
        }
    }
}