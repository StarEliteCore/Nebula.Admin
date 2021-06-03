using System;
using System.Collections.Generic;
using System.ComponentModel;
using DestinyCore.Entity;
using Destiny.Core.Flow.Entities;
using DestinyCore.Mapping;
namespace Destiny.Core.Flow.Dtos
{
    /// <summary>
    /// 文档
    /// </summary>
    [AutoMapping(typeof(Document))]
    public partial class DocumentOutputDto : OutputDto<Guid>
    {
        /// <summary>
        /// 获取或设置 内容
        /// </summary>
        public string Content { get; set; }
        /// <summary>
        /// 获取或设置 文档类型ID
        /// </summary>
        public Guid DocumentTypeId { get; set; }
        /// <summary>
        /// 获取或设置 标题
        /// </summary>
        public string Title { get; set; }

    }

}
