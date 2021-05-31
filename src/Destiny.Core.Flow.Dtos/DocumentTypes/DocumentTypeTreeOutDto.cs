using Destiny.Core.Flow.Entities;
using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Dtos.DocumentTypes
{
    /// <summary>
    /// 文档树类型
    /// </summary>
    [AutoMapping(typeof(DocumentType))]
    public  class DocumentTreeOutDto : OutputDto<Guid>
    {

        /// <summary>
        /// 获取或设置 名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 获取或设置 排序
        /// </summary>
        public int Sort { get; set; }
        /// <summary>
        /// 获取或设置 父级
        /// </summary>
        public Guid? ParentId { get; set; }

        /// <summary>
        /// 子级
        /// </summary>
        public List<DocumentTreeOutDto> Children { get; set; } = new List<DocumentTreeOutDto>();
    }
}
