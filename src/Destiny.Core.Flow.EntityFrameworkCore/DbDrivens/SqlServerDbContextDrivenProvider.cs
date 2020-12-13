using Destiny.Core.Flow.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.DbDrivens
{
    /// <summary>
    /// SqlServer驱动提供者
    /// </summary>
    public class SqlServerDbContextDrivenProvider : IDbContextDrivenProvider
    {
        public DatabaseType DatabaseType => DatabaseType.SqlServer;

        public DbContextOptionsBuilder Builder(DbContextOptionsBuilder builder, string connectionString, DestinyContextOptionsBuilder optionsBuilder)
        {
            builder.UseSqlServer(connectionString, options => options.MigrationsAssembly(optionsBuilder.MigrationsAssemblyName));
            return builder;
        }
    }
}
