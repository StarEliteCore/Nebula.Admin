


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
    public partial class DocumentInputDto : InputDto<Guid>
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
