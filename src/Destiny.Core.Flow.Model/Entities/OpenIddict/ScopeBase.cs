using DestinyCore.Entity;
using System;

namespace Destiny.Core.Flow.Model.Entities.OpenIddict
{
    /// <summary>
    /// 授权范围
    /// </summary>
    /// <typeparam name="TKey">id类型</typeparam>
    public abstract class ScopeBase<TKey> : EntityBase<TKey> where TKey : IEquatable<TKey>
    {
        /// <summary>
        /// 并发令牌 用于乐观锁
        /// </summary>
        public virtual string ConcurrencyToken { get; set; } = Guid.NewGuid().ToString();

        /// <summary>
        /// 描述
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// 本地化描述  序列化为json 
        /// </summary>
        public virtual string Descriptions { get; set; }

        /// <summary>
        /// 显示名称
        /// </summary>
        public virtual string DisplayName { get; set; }

        /// <summary>
        /// 本地化显示名称  序列化为json 
        /// </summary>
        public virtual string DisplayNames { get; set; }


        /// <summary>
        /// 范围名称
        /// </summary>
        public virtual string Name { get; set; }

        /// <summary>
        /// 附加属性列表 序列化为json
        /// </summary>
        public virtual string Properties { get; set; }

        /// <summary>
        /// 关联资源列表 序列化为json
        /// </summary>
        public virtual string Resources { get; set; }
    }
}
