using Destiny.Core.Flow.Model.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Destiny.Core.Flow.Model.EntityConfigurations
{
    public class UserConfiguration : EntityMappingConfiguration<User, Guid>
    {
        public override void Map(EntityTypeBuilder<User> b)
        {
            b.HasKey(o => o.Id);
            b.Property(o => o.UserName).HasMaxLength(20).IsRequired();
            b.Property(o => o.NormalizedUserName).HasMaxLength(50);
            b.Property(o => o.NickName).HasMaxLength(50).IsRequired();
            b.Property(o => o.EmailConfirmed);
            b.Property(o => o.PhoneNumberConfirmed).IsRequired();
            b.Property(o => o.TwoFactorEnabled);
            b.Property(o => o.LockoutEnabled).HasDefaultValue(false);
            b.Property(o => o.AccessFailedCount).HasDefaultValue(0);
            b.Property(o => o.ConcurrencyStamp).IsConcurrencyToken();
            b.Property(o => o.Description).IsRequired(false).HasMaxLength(500);
            b.Property(o => o.IsDeleted).HasDefaultValue(false);
            //初始密码123456
            //b.HasData(new User()
            //{
            //    Id = Guid.Parse("a1e89f45-4fa8-4751-9df9-dec86f7e6c14"),
            //    UserName = "Admin",
            //    NormalizedUserName = "ADMIN",
            //    NickName = "管理员",
            //    EmailConfirmed = false,
            //    PasswordHash = "AQAAAAEAACcQAAAAEEPWhHPCHU1i6Z0ayoApKGbPlZUb38RUdJg4QjUcccVhUSto0sRZtLOXfwWUJ+P2Xw==",
            //    SecurityStamp = "3OWMGQAK5ZTXMSV6OFSGIWWWNIWJ2SX6",
            //    ConcurrencyStamp = "0286cab6-8a4a-44ed-9a97-86b0506c65c3",
            //    PhoneNumberConfirmed = false,
            //    TwoFactorEnabled = false,
            //    LockoutEnabled = true,
            //    AccessFailedCount = 0,
            //    IsSystem = true,
            //    CreatedTime = DateTime.Now,
            //    IsDeleted = false,
            //    Description = "系统管理员拥有所有权限",
            //    Sex = Sex.Man

            //});
            b.ToTable("User");
        }
    }
}