using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Model.Entities.Function;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Model.EntityConfigurations
{
    public class FunctionConfiguration : EntityMappingConfiguration<Function, Guid>
    {
        public override void Map(EntityTypeBuilder<Function> b)
        {
            b.HasKey(o => o.Id);
            b.Property(o => o.Name).HasMaxLength(50).IsRequired();
            b.Property(o=>o.Area).HasMaxLength(25);
            b.Property(o => o.Controller).HasMaxLength(30);
            b.Property(o => o.Action).HasMaxLength(30);
            b.Property(o => o.Url).HasMaxLength(500);
            b.Property(o => o.IsDeleted).HasDefaultValue(false).IsRequired();
            b.Property(o=>o.IsEnabled).HasDefaultValue(true).IsRequired(); ;
            b.Property(o => o.Description).HasMaxLength(1000);
            b.ToTable("Function");
        }
    }
}
