
using System;
using System.Collections.Generic;
using System.ComponentModel;
using DestinyCore.Entity;
using DestinyCore.Mapping;
using Destiny.Core.Flow.Entities;
namespace Destiny.Core.Flow.Dtos
{

    /// <summary>
    /// 文档
    /// </summary>
    [AutoMapping(typeof(Document))]
    public partial class DocumentPageListDto : OutputDto<Guid>
    {
        [DisplayName("内容")]
        /// <summary>
        /// 获取或设置 内容
        /// </summary>
        public string Content { get; set; }

        [DisplayName("文档类型ID")]
        /// <summary>
        /// 获取或设置 文档类型ID
        /// </summary>
        public Guid DocumentTypeId { get; set; }


        [DisplayName("文档类型名字")]
        /// <summary>
        /// 获取或设置 文档类型名字
        /// </summary>
        public string DocumentTypeName { get; set; }

        [DisplayName("标题")]
        /// <summary>
        /// 获取或设置 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 获取或设置 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 获取或设置 用户昵称
        /// </summary>
        [DisplayName("用户昵称")]
        public string NickName { get; set; }

        /// <summary>
        /// 获取或设置最后修改时间
        /// </summary>
        [DisplayName("最后修改时间")]
        public DateTime? LastModifionTime { get; set; }

    }

}
