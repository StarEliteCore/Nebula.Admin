using Destiny.Core.Flow.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Destiny.Core.Flow.IdentityServer.Entities
{
    /// <summary>
    /// 秘密
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    [DisplayName("秘密基类")]
    public abstract class SecretBase<TKey>:IEntity<TKey>
    {
        [DisplayName("主键")]
        public TKey Id { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        [DisplayName("说明")]
        public string Description { get; set; }
        /// <summary>
        /// 值
        /// </summary>
        [DisplayName("值")]
        public string Value { get; set; }
        /// <summary>
        /// 到期时间
        /// </summary>
        [DisplayName("到期时间")]
        public DateTime? Expiration { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        [DisplayName("")]
        public string Type { get; set; } = "SharedSecret";
        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime Created { get; set; } = DateTime.UtcNow;
    }
}
