using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.AuthenticationCenter.DbContexts
{
    /// <summary>
    /// IdentityServer4上下文
    /// </summary>
    public class IdentityServer4DefaultDbContext : DbContextBase
    {


        public IdentityServer4DefaultDbContext(DbContextOptions<IdentityServer4DefaultDbContext> options, IServiceProvider serviceProvider)
          : base(options, serviceProvider)
        {
          
        }


        public override int SaveChanges()
        {
            return base.SaveChanges();
        }


        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }


    }
}
