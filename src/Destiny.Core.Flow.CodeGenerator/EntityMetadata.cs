using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.CodeGenerator
{
    /// <summary>
    /// 实体元数据
    /// </summary>
   public class EntityMetadata
    {

        /// <summary>
        /// 实体名
        /// </summary>
        public string EntityName { get; set; }

        /// <summary>
        /// 显示名
        /// </summary>
        public string DisplayName { get; set; }

        public string PrimaryKeyType { get; set; }

        public string PrimaryKeyColName { get; set; }
    }
}
