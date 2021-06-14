using Destiny.Core.Flow.Shared.Entity;
using DestinyCore.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Destiny.Core.Flow.Model.Entities
{
    /// <summary>
    /// 资产
    /// </summary>
    [DisplayName("资产")]
    public partial class Asset : FullAuditedEntityWithEntity<Guid,Guid>
    {
        /// <summary>
        /// 后缀名
        /// </summary>
        [DisplayName("后缀名")]

        public string Suffix { get; set; }

        /// <summary>
        /// 路径
        /// </summary>
        [DisplayName("路径")]
        public string Path { get; set; }

        /// <summary>
        /// 大小
        /// </summary>
        [DisplayName("大小")]
        public int Size { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [DisplayName("类型")]
        public string AssetType { get; set; }


        /// <summary>
        /// 名字
        /// </summary>
        [DisplayName("名字")]
        public string Name { get; set; }

  
    }
}
