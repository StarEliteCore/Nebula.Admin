using Destiny.Core.Flow.Model.Entities.Dictionary;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Model.EntityConfigurations
{
    public class DataDictionaryConfiguration : EntityMappingConfiguration<DataDictionary, Guid>
    {
        public override void Map(EntityTypeBuilder<DataDictionary> b)
        {
            b.HasKey(o => o.Id);
            b.Property(o => o.Title).HasMaxLength(50).IsRequired();
            b.Property(o => o.Code).HasMaxLength(50).IsRequired();
            b.Property(o => o.Value).HasMaxLength(50);
            b.Property(o => o.Sort).HasDefaultValue(0);
            b.ToTable("DataDictionary");
        }
    }
}
