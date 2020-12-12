using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Extensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
namespace Destiny.Core.Flow.MySql
{
    public class MySqlDbContextDrivenProvider : IDbContextDrivenProvider
    {
        public DatabaseType DatabaseType => DatabaseType.MySql;

        public DbContextOptionsBuilder Builder(DbContextOptionsBuilder builder, string connectionString, DestinyContextOptionsBuilder optionsBuilder)
        {
            builder.UseMySql(connectionString, options => {

                if (!optionsBuilder.MigrationsAssemblyName.IsNullOrEmpty())
                {
                    options.MigrationsAssembly(optionsBuilder.MigrationsAssemblyName);

                }


            });
            return builder;
        }
    }
}
