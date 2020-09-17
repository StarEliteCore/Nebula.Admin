using Destiny.Core.Flow.Model.Entities.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Destiny.Core.Flow.Model.EntityConfigurations
{
    public class UserTokenConfiguration : EntityMappingConfiguration<UserToken, Guid>
    {
        public override void Map(EntityTypeBuilder<UserToken> b)
        {
            b.HasKey(o => o.Id);
            b.Property(o => o.IsDeleted).HasDefaultValue(false);
            b.Property(o => o.UserId);
            b.Property(o => o.LoginProvider).HasMaxLength(450);
            b.Property(o => o.Name).HasMaxLength(450);
            b.Property(o => o.Value);
            b.ToTable("UserToken");
        }
    }
}