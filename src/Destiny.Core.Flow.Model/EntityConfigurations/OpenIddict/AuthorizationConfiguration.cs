using Destiny.Core.Flow.OpenIddict.Entities;
using DestinyCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Destiny.Core.Flow.Model.EntityConfigurations.OpenIddict
{
    public class AuthorizationConfiguration : EntityMappingConfiguration<OpenIddictAuthorization, Guid>
    {
        public override void Map(EntityTypeBuilder<OpenIddictAuthorization> b)
        {
            b.HasKey(o => o.Id);
            b.Property(o => o.ConcurrencyToken).HasMaxLength(ModelConsts.NameMaxLength);
            b.Property(o => o.Subject).HasMaxLength(ModelConsts.NameMaxLength);
            b.Property(o => o.Properties).HasMaxLength(ModelConsts.JsonMaxLength);
            b.Property(o => o.Scopes).HasMaxLength(ModelConsts.JsonMaxLength);
            b.Property(o => o.Status).HasMaxLength(ModelConsts.StatusMaxLength);
            b.Property(o => o.Type).HasMaxLength(ModelConsts.TypeMaxLength);
            b.ToTable("OpenIddictAuthorizations");
        }
    }
}
