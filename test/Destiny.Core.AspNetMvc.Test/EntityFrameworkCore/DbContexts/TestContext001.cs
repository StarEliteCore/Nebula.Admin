using DestinyCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkCore.DbContexts
{
    public class TestContext001 : DbContextBase
    {
        public TestContext001(DbContextOptions options, IServiceProvider serviceProvider) : base(options,serviceProvider)
        {
        }
    }
}
