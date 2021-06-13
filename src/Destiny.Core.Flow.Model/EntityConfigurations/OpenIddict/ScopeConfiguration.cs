using Destiny.Core.Flow.OpenIddict.Entities;
using DestinyCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Model.EntityConfigurations.OpenIddict
{
    public class ScopeConfiguration : EntityMappingConfiguration<OpenIddictScope, Guid>
    {
        public override void Map(EntityTypeBuilder<OpenIddictScope> b)
        {
            b.HasKey(o => o.Id);
            b.Property(o => o.DisplayName).HasMaxLength(ModelConsts.NameMaxLength);
            b.Property(o => o.Description).HasMaxLength(ModelConsts.NameMaxLength);
            b.Property(o => o.Name).HasMaxLength(ModelConsts.NameMaxLength);
            b.Property(o => o.ConcurrencyToken).HasMaxLength(ModelConsts.NameMaxLength);
            b.Property(o => o.DisplayNames).HasMaxLength(ModelConsts.JsonMaxLength);
            b.Property(o => o.Descriptions).HasMaxLength(ModelConsts.JsonMaxLength);
            b.Property(o => o.Properties).HasMaxLength(ModelConsts.JsonMaxLength);
            b.Property(o => o.Resources).HasMaxLength(ModelConsts.NameMaxLength);
            b.ToTable("OpenIddictScopes");
        }
    }
}
