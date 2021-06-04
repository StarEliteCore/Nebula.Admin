using Destiny.Core.Flow.Model.Entities;
using DestinyCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Model.EntityConfigurations
{
    /// <summary>
    /// 资产
    /// </summary>
    //public class AssetConfiguration : EntityMappingConfiguration<Asset, Guid>
    //{
    //    public override void Map(EntityTypeBuilder<Asset> b)
    //    {
    //        b.HasKey(o => o.Id);
    //        b.Property(o => o.Suffix).HasMaxLength(10).HasComment("后缀名").IsRequired();
    //        b.Property(o => o.Path).HasMaxLength(500).HasComment("路径").IsRequired();
    //        b.Property(o => o.Size).HasDefaultValue(0).HasComment("大小").IsRequired();
    //        b.Property(o => o.AssetType).HasMaxLength(10).HasComment("类型").IsRequired();
    //        b.Property(o => o.Name).HasMaxLength(500).HasComment("名字").IsRequired();
    //        b.Property(o => o.IsDeleted).HasDefaultValue(false).HasComment("是否删除").IsRequired();
    //        b.ToTable("Asset");
    //    }
    //}
}
