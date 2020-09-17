using Destiny.Core.Flow.Model.Entities.Menu;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Destiny.Core.Flow.Model.EntityConfigurations.Menu
{
    public class MenuFunctionConfiguration : EntityMappingConfiguration<MenuFunction, Guid>
    {
        public override void Map(EntityTypeBuilder<MenuFunction> b)
        {
            b.HasKey(o => o.Id);
            b.Property(o => o.MenuId);
            b.Property(o => o.FunctionId);
            b.ToTable("MenuFunction");
        }
    }
}