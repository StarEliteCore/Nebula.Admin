using Destiny.Core.Flow.Entity;
using System;

namespace Destiny.Core.Flow.Options
{
    /// <summary>
    /// 数据库配置
    /// </summary>

    public class DestinyContextOptions
    {

   
        /// <summary>
        /// 数据类型
        /// </summary>
        public DatabaseType DatabaseType { get;set;}

        /// <summary>
        /// 数据库链接
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// 下上文类型名字
        /// </summary>
        public string DbContextTypeName { get; set; }

        /// <summary>
        /// 上下文类型
        /// </summary>
        public Type DbContextType => Type.GetType(DbContextTypeName);

        /// <summary>
        /// 迁移Assembly名字
        /// </summary>
        public string MigrationsAssemblyName { get; set; }
    }
}
