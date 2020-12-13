using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
namespace Destiny.Core.Flow.MySql
{
    /// <summary>
    /// MySql驱动提供者
    /// </summary>
    public class MySqlDbContextDrivenProvider : IDbContextDrivenProvider
    {
        public DatabaseType DatabaseType => DatabaseType.MySql;

        public DbContextOptionsBuilder Builder(DbContextOptionsBuilder builder, string connectionString, DestinyContextOptionsBuilder optionsBuilder)
        {
            builder.UseMySql(connectionString, options=>options.MigrationsAssembly(optionsBuilder.MigrationsAssemblyName));
            return builder;
        }
    }
}
