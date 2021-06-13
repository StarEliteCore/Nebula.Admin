using Destiny.Core.AspNetMvc.Test.EntityFrameworkCore.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Destiny.Core.AspNetMvc.Test
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<TestContext>
    {
        public TestContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TestContext>();
            optionsBuilder.UseMySql("", new MySqlServerVersion(new Version(8, 0, 21)), options => options.MigrationsAssembly("Destiny.Core.AspNetMvc.Test"));

            return new TestContext(optionsBuilder.Options);
        }
    }
}
