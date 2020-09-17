using Destiny.Core.Flow.Model.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Destiny.Core.Flow.Model.EntityConfigurations
{
    public class RoleConfiguration : EntityMappingConfiguration<Role, Guid>
    {
        public override void Map(EntityTypeBuilder<Role> b)
        {
            b.HasKey(o => o.Id);
            b.Property(o => o.Name).HasMaxLength(10).IsRequired();
            b.Property(o => o.ConcurrencyStamp).HasMaxLength(256);
            b.Property(o => o.NormalizedName).HasMaxLength(50);
            b.Property(o => o.Description).HasMaxLength(500);
            b.Property(o => o.ConcurrencyStamp).IsConcurrencyToken();
            b.Property(o => o.IsDeleted).HasDefaultValue(false);
            b.Property(o => o.Code).HasMaxLength(20);
            b.ToTable("Role");

            //b.HasData(new Role()
            //{
            //  Id=Guid.Parse("B8551E97-0723-47FC-BD7E-AFF35BB1B1E7"),
            //  Name= "系统管理员",
            //  NormalizedName= "系统管理员",
            //  ConcurrencyStamp=Guid.NewGuid().ToString(),
            //  CreatorUserId= Guid.Parse("a1e89f45-4fa8-4751-9df9-dec86f7e6c14"),
            //  CreatedTime=DateTime.Now,
            //  IsDeleted=false,
            //  Description="拥有系统上所有有权限请不要删除!",
            //  IsAdmin=true
            //});
        }
    }
}