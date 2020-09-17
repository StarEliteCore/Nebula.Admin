using System;
using System.ComponentModel;
using Destiny.Core.Flow.Entity;

namespace Destiny.Core.Flow.IdentityServer.Entities
{
    /// <summary>
    /// 属性
    /// </summary>
    public abstract class Property : IEntity<Guid>
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 键
        /// </summary>
        [DisplayName("键")]
        public string Key { get; set; }

        /// <summary>
        /// 值
        /// </summary>
        [DisplayName("值")]
        public string Value { get; set; }

    }

    /// <summary>
    /// 客户端属性
    /// </summary>
    public class ClientProperty : Property
    {
        /// <summary>
        /// 客户端id
        /// </summary>
        [DisplayName("客户端id")]
        public int ClientId { get; set; }

        /// <summary>
        /// 所属客户端
        /// </summary>
        [DisplayName("所属客户端")]
        public Client Client { get; set; }
    }
}
