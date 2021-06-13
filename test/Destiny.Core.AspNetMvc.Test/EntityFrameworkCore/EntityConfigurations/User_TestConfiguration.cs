using Destiny.Core.AspNetMvc.Test.EntityFrameworkCore.Entities;
using DestinyCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Destiny.Core.AspNetMvc.Test.EntityFrameworkCore.EntityConfigurations
{
    public class User_TestConfiguration : EntityMappingConfiguration<User_Test, Guid>
    {
        public override void Map(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<User_Test> b)
        {
            b.Property(o => o.Name);
            b.Property(o=>o.Description);
            b.HasKey(o => o.Id);
            b.ToTable("User_Test");

        }
    }
}
