using AutoMapper;
using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.Model.Entities.Identity;

using System;

namespace Destiny.Core.Flow.Dtos
{
    [AutoMap(typeof(User))]
    public class UserOutputDto : OutputDto<Guid>
    {
        public UserOutputDto()
        {
            RoleIds = new Guid[] { };
        }

        public string UserName { get; set; }

        public string NickName { get; set; }

        public DateTime CreatedTime { get; set; }

        public bool IsSystem { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 姓别
        /// </summary>
        public Sex Sex { get; set; }

        public Guid[] RoleIds { get; set; }
    }
}
