using Destiny.Core.Flow.OpenIddict.Entities;
using DestinyCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Destiny.Core.Flow.Model.EntityConfigurations.OpenIddict
{
    public class OpenIddictTokenConfiguration : EntityMappingConfiguration<OpenIddictToken, Guid>
    {
        public override void Map(EntityTypeBuilder<OpenIddictToken> b)
        {
            b.HasKey(o => o.Id);
            b.Property(o => o.Subject).HasMaxLength(ModelConsts.NameMaxLength);
            b.Property(o => o.ReferenceId).HasMaxLength(ModelConsts.NameMaxLength);
            b.Property(o => o.ConcurrencyToken).HasMaxLength(ModelConsts.NameMaxLength);
            b.Property(o => o.Payload).HasMaxLength(ModelConsts.JsonMaxLength);
            b.Property(o => o.Properties).HasMaxLength(ModelConsts.JsonMaxLength);
            b.Property(o => o.Type).HasMaxLength(ModelConsts.TypeMaxLength);
            b.ToTable("OpenIddictTokens");
        }
    }
}
