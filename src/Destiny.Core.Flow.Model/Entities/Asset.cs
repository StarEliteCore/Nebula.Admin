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
    public partial class Asset : EntityBase<Guid>, IFullAuditedEntity<Guid>
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

        /// <summary>
        /// 获取或设置最后修改用户
        /// </summary>
        [DisplayName("最后修改用户")]
        public Guid? LastModifierUserId { get; set; }
        /// <summary>
        /// 获取或设置最后修改时间
        /// </summary>
        [DisplayName("最后修改时间")]
        public DateTime? LastModifionTime { get; set; }
        /// <summary>
        /// 获取或设置是否删除
        /// </summary>
        [DisplayName("是否删除")]
        public bool IsDeleted { get; set; }
        /// <summary>
        /// 获取或设置创建用户ID
        /// </summary>
        [DisplayName("创建用户ID")]
        public Guid? CreatorUserId { get; set; }
        /// <summary>
        /// 获取或设置创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime CreatedTime { get; set; }
    }
}
