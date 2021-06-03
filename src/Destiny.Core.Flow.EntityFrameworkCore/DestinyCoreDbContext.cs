using DestinyCore.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Destiny.Core.Flow.EntityFrameworkCore
{
    public class DestinyCoreDbContext : DbContextBase
    {
        public DestinyCoreDbContext(DbContextOptions options, IServiceProvider serviceProvider) : base(options, serviceProvider)
        {
        }
    }
}
