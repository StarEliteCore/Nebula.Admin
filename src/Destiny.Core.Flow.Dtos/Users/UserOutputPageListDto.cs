using AutoMapper;
using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.Mapping;
using Destiny.Core.Flow.Model.Entities.Identity;
using System;
using System.ComponentModel;

namespace Destiny.Core.Flow.Dtos
{
    [AutoMapping(typeof(User))]
    public class UserOutputPageListDto : IOutputDto
    {
        public Guid Id { get; set; }

        [DisplayName("用户名")]
        public string UserName { get; set; }

        [DisplayName("用户昵称")]
        public string NickName { get; set; }

        [DisplayName("创建时间")]
        public DateTime CreatedTime { get; set; }

        [DisplayName("是否系统")]
        public bool IsSystem { get; set; }

        [DisplayName("最后修改时间")]
        public DateTime? LastModifionTime { get; set; }

        [DisplayName("是否删除")]
        public bool IsDeleted { get; set; }

        [DisplayName("描述")]
        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 姓别
        /// </summary>
        public Sex Sex { get; set; }
    }
}