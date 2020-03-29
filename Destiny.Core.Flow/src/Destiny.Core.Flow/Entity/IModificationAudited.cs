using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Entity
{
    /// <summary>
    /// 修改审核信息
    /// </summary>
    public interface IModificationAudited<TUserKey>
        where TUserKey:struct

    {

        /// <summary>
        /// 最后修改用户ID
        /// </summary>
        TUserKey? LastModifierUserId { get; set; }

        /// <summary>
        /// 最后修改时间
        /// </summary>
        DateTime? LastModifierTime { get; set; }
    }


}
