using AutoMapper;
using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Model.Entities.Dictionary;
using System;
using System.ComponentModel;

namespace Destiny.Core.Flow.Dtos.DataDictionnary
{
    [AutoMap(typeof(DataDictionaryEntity))]
    public class DataDictionaryOutPageListDto : IOutputDto
    {
        /// <summary>
        /// id
        /// </summary>
        [DisplayName("Id")]
        public string Id { get; set; }
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

    }
}