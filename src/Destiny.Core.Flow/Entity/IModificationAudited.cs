using Destiny.Core.Flow.Audit;

namespace Destiny.Core.Flow.Entity
{
    /// <summary>
    /// 修改审核信息
    /// </summary>
    public interface IModificationAudited<TUserKey> : IModificationTime
        where TUserKey : struct

    {
        /// <summary>
        /// 最后修改用户ID
        /// </summary>
        [DisableAuditing]
        TUserKey? LastModifierUserId { get; set; }
    }

}
