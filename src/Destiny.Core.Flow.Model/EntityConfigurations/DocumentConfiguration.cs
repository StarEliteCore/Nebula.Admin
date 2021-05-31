using Destiny.Core.Flow.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Model.EntityConfigurations
{
    /// <summary>
    /// 文档
    /// </summary>
    public class DocumentConfiguration : EntityMappingConfiguration<Document, Guid>
    {
        /// <summary>
        /// 重写以实现实体类型各个属性的数据库配置
        /// </summary>
        /// <param name="builder">实体类型创建器</param>
        public override void Map(EntityTypeBuilder<Document> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Content).HasComment("内容").IsRequired(true);
            builder.Property(x => x.Title).HasMaxLength(500).HasComment("标题").IsRequired(true);
            builder.Property(x => x.DocumentTypeId).HasComment("文档类型ID").IsRequired(true);
            builder.ToTable("Document");
        }
    }
}
