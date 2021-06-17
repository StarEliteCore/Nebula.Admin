using Destiny.Core.Flow.OpenIddict.Entities;
using DestinyCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Destiny.Core.Flow.OpenIddict.EntityFrameworkCore
{
    public class OpenIddictEntityDefaultDbContext : DbContextBase
    {
        public DbSet<OpenIddictApplication> OpenIddictApplications { get; set; }

        public DbSet<OpenIddictAuthorization> OpenIddictAuthorizations { get; set; }

        public DbSet<OpenIddictScope> OpenIddictScopes { get; set; }

        public DbSet<OpenIddictToken> OpenIddictTokens { get; set; }

        public OpenIddictEntityDefaultDbContext(DbContextOptions options, IServiceProvider serviceProvider) : base(options, serviceProvider)
        {
        }
    }
}
