using DestinyCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Destiny.Core.Flow.OpenIddict.EntityFrameworkCore
{
    public class OpenIddictEntityDefaultDbContext : DbContextBase
    {
        public OpenIddictEntityDefaultDbContext(DbContextOptions options, IServiceProvider serviceProvider) : base(options, serviceProvider)
        {
        }
    }
}
