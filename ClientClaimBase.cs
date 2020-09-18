using System;
using System.ComponentModel;
using Destiny.Core.Flow.Entity;

namespace Destiny.Core.Flow.IdentityServer.Entities
{
    /// <summary>
    /// 客户端声明
    /// </summary>
    [DisplayName("客户端声明")]
    public abstract class ClientClaimBase : IEntity<Guid>
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        [DisplayName("类型")]
        public string Type { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        [DisplayName("值")]
        public string Value { get; set; }

        /// <summary>
        /// 客户端id
        /// </summary>
        [DisplayName("客户端id")]
        public int ClientId { get; set; }

        ///// <summary>
        ///// 所属客户端
        ///// </summary>
        //[DisplayName("所属客户端")]
        //public ClientBase Client { get; set; }

    }
}
