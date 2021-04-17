using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.Mapping;
using Destiny.Core.Flow.Model.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Dtos.Users
{
    /// <summary>
    /// 用户输出集合DTO
    /// </summary>
    [AutoMapping(typeof(User))]
    public   class UserOutputListDto : OutputDto<Guid>
    {
        public string UserName { get; set; }

        public string NickName { get; set; }


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
