
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Destiny.Core.Flow.Entities;
namespace Destiny.Core.Flow.EntityConfigurations
{

    /// <summary>
    /// 文档类型
    /// </summary>
    public partial class DocumentTypeConfiguration : EntityMappingConfiguration<DocumentType, Guid>
    {
        /// <summary>
        /// 重写以实现实体类型各个属性的数据库配置
        /// </summary>
        /// <param name="builder">实体类型创建器</param>
        public override void Map(EntityTypeBuilder<DocumentType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasComment("名称").IsRequired(true);
            builder.Property(x => x.Sort).HasComment("排序").IsRequired(true).HasDefaultValue(0);
            builder.Property(x => x.ParentId).HasComment("父级").IsRequired(false);
            builder.Property(x => x.IsDeleted).HasComment("是否删除").HasDefaultValue(false);
            builder.Property(x => x.Description).HasComment("描述").IsRequired(false).HasMaxLength(1000);
            builder.ToTable("DocumentType");
        }
    }
}