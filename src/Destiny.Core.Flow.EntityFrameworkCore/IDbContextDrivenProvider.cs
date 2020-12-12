using Destiny.Core.Flow.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow
{
    public interface IDbContextDrivenProvider
    {
        DatabaseType DatabaseType { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>

        DbContextOptionsBuilder Builder(DbContextOptionsBuilder builder,string connectionString, DestinyContextOptionsBuilder optionsBuilder);


    }
}
