using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Mapping;
using Destiny.Core.Flow.Model.Entities.Dictionary;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Destiny.Core.Flow.Dtos.DataDictionnary
{
    [AutoMapping(typeof(DataDictionaryEntity))]
    public class DataDictionaryOutDto : OutputDto<Guid>
    {
        /// <summary>
        /// 数据字典标题
        /// </summary>
        [DisplayName("数据字典标题")]
        public string Title { get; set; }

        /// <summary>
        /// 数据字典值
        /// </summary>
        [DisplayName("数据字典值")]
        public string Value { get; set; }

        /// <summary>
        /// 数据字典备注
        /// </summary>
        [DisplayName("数据字典备注")]
        public string Remark { get; set; }

        /// <summary>
        /// 数据字典父级
        /// </summary>
        [DisplayName("数据字典父级")]
        public Guid ParentId { get; set; } = Guid.Empty;

        /// <summary>
        /// 排序
        /// </summary>
        [DisplayName("排序")]
        public int Sort { get; set; }

        /// <summary>
        ///获取或设置 编码
        /// </summary>
        [DisplayName("编码")]
        public string Code { get; set; }

        /// <summary>
        /// 子集
        /// </summary>
        public List<DataDictionaryOutDto> children { get; set; } = new List<DataDictionaryOutDto>();
    }
}