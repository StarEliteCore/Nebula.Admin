using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Shared.Options
{
    public class MongoOptions
    {

        /// <summary>
        /// 链接字符
        /// </summary>
        public string MongoDBConnectionString { get; set; }

        public bool Enabled { get; set; } = true;
    }
}
