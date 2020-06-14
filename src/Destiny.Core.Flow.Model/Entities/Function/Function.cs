using Destiny.Core.Flow.Data;
using Destiny.Core.Flow.Entity;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Destiny.Core.Flow.Model.Entities.Function
{
    [DisplayName("功能")]
    public class Function : EntityBase<Guid>, IFullAuditedEntity<Guid>
    {

        public Function()
        {
            Id = ComnGuid.NewGuid();
        }

        [DisplayName("功能名字")]
        /// <summary>
        /// 功能名字
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// 区域
        /// </summary>
        [DisplayName("区域")]
        public string Area { get; set; }


        /// <summary>
        /// 控制器
        /// </summary>
        [DisplayName("控制器")]
        public string Controller { get; set; }


        /// <summary>
        /// 方法
        /// </summary>
        [DisplayName("方法")]
        public string Action { get; set; }

        /// <summary>
        /// 创建者
        /// </summary>
        [DisplayName("创建者")]
        public Guid? CreatorUserId { get; set; }


        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 最后修改者
        /// </summary>
        [DisplayName("最后修改者")]
        public Guid? LastModifierUserId { get; set; }


        /// <summary>
        /// 最后修改时间
        /// </summary>
        [DisplayName("最后修改时间")]
        public DateTime? LastModifierTime { get; set; }

        /// <summary>
        /// 是否删除
        /// </summary>
        [DisplayName("是否删除")]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// 是否可用
        /// </summary>
        [DisplayName("是否可用")]
        public bool IsEnabled { get; set; }

    }
}
