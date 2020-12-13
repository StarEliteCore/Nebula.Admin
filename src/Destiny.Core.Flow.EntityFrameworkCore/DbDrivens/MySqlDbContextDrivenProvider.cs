using Destiny.Core.Flow.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.DbDrivens
{
    /// <summary>
    /// MYsql驱动提供者
    /// </summary>
    public class MySqlDbContextDrivenProvider : IDbContextDrivenProvider
    {
        public DatabaseType DatabaseType => DatabaseType.MySql;

        public DbContextOptionsBuilder Builder(DbContextOptionsBuilder builder, string connectionString, DestinyContextOptionsBuilder optionsBuilder)
        {
            builder.UseMySql(connectionString, options => options.MigrationsAssembly(optionsBuilder.MigrationsAssemblyName));
            return builder;
        }
    }
}
