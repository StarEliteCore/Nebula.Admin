using Destiny.Core.AspNetMvc.Test.EntityFrameworkCore.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Destiny.Core.AspNetMvc.Test.EntityFrameworkCore.DbContexts
{
    public class TestContext : DbContext
    {

        public TestContext(DbContextOptions<TestContext> options)
          : base(options)
        {

        }

        public DbSet<User_Test> User_Test { get; set; }


    }
}
