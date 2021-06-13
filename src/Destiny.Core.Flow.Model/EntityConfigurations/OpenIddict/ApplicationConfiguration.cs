using Destiny.Core.Flow.OpenIddict.Entities;
using DestinyCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Destiny.Core.Flow.Model.EntityConfigurations.OpenIddict
{
    public class ApplicationConfiguration : EntityMappingConfiguration<OpenIddictApplication, Guid>
    {
        public override void Map(EntityTypeBuilder<OpenIddictApplication> b)
        {
            b.HasKey(o => o.Id);
            b.Property(o => o.ClientId).HasMaxLength(ModelConsts.NameMaxLength);
            b.Property(o => o.ClientSecret).HasMaxLength(ModelConsts.NameMaxLength);
            b.Property(o => o.ConcurrencyToken).HasMaxLength(ModelConsts.NameMaxLength);
            b.Property(o => o.ConsentType).HasMaxLength(ModelConsts.TypeMaxLength);
            b.Property(o => o.DisplayName).HasMaxLength(ModelConsts.NameMaxLength);
            b.Property(o => o.Permissions).HasMaxLength(ModelConsts.JsonMaxLength);
            b.Property(o => o.PostLogoutRedirectUris).HasMaxLength(ModelConsts.JsonMaxLength);
            b.Property(o => o.Properties).HasMaxLength(ModelConsts.JsonMaxLength);
            b.Property(o => o.RedirectUris).HasMaxLength(ModelConsts.JsonMaxLength);
            b.Property(o => o.Requirements).HasMaxLength(ModelConsts.JsonMaxLength);
            b.Property(o => o.Type).HasMaxLength(ModelConsts.TypeMaxLength);
            b.ToTable("OpenIddictApplications");
        }
    }
}
