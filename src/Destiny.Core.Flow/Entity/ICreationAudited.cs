namespace Destiny.Core.Flow.Entity
{
    /// <summary>
    /// 定义创建审计
    /// </summary>
    public interface ICreationAudited<TUserKey> : ICreatedTime

        where TUserKey : struct
    {
        /// <summary>
        /// 创建者用户ID
        /// </summary>
        TUserKey? CreatorUserId { get; set; }
    }
}