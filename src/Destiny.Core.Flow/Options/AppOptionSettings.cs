using System;
using System.Collections.Generic;
using System.Linq;

namespace Destiny.Core.Flow.Options
{
    public class AppOptionSettings
    {

        public AppOptionSettings()
        {
            DbContexts = new Dictionary<string, DestinyContextOptions>();
        }




        /// <summary>
        /// Jwt操作类
        /// </summary>
        public JwtOptions Jwt { get; set; }

        public CorsOptions Cors { get; set; }

        public AuthOptions Auth { get; set; }

        /// <summary>
        /// 是否自动添加功能
        /// </summary>
        public bool IsAutoAddFunction { get; set; }

        /// <summary>
        /// 是否启用审计 
        /// </summary>
        public bool AuditEnabled { get; set; }

        /// <summary>
        /// 数据操作
        /// </summary>
        public Dictionary<string, DestinyContextOptions> DbContexts { get; set; }


     

    }
}
