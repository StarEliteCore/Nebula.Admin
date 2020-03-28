using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow
{
    public class DefaultDbContext : DbContextBase
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> options, IServiceProvider serviceProvider)
          : base(options, serviceProvider)
        {

        }

        

    }
}
