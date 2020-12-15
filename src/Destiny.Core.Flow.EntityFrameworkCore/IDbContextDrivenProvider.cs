using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow
{

    /// <summary>
    /// 上下文驱动提供者
    /// </summary>
    public interface IDbContextDrivenProvider
    {


        /// <summary>
        /// 构建数据库驱动
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>

        DbContextOptionsBuilder Builder(DbContextOptionsBuilder builder,string connectionString, DestinyContextOptionsBuilder optionsBuilder);


    }
}
