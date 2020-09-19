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

        /// <summary>
        /// 主键类型
        /// </summary>
        public string PrimaryKeyType { get; set; }

        /// <summary>
        /// 主键名
        /// </summary>

        public string PrimaryKeyName { get; set; }



        /// <summary>
        /// 属性集合
        /// </summary>
        public List<PropertyMetadata> Properties = new List<PropertyMetadata>();
    }
}
