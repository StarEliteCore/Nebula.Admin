using AutoMapper;
using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Model.DestinyIdentityServer4;
using System;
using System.ComponentModel;

namespace Destiny.Core.Flow.Dtos.Application
{
    /// <summary>
    /// 
    /// </summary>
    [AutoMap(typeof(Client))]
    public class ClientOutPutPageDto : OutputDtoBase<Guid>
    {
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enabled { get; set; } = true;
        /// <summary>
        /// 客户端Id
        /// </summary>
        [DisplayName("客户端Id")]
        public string ClientId { get; set; }
        /// <summary>
        /// 协议类型
        /// </summary>
        [DisplayName("协议类型")]
        public string ProtocolType { get; set; } = "oidc";
        /// <summary>
        /// 客户端名称
        /// </summary>
        [DisplayName("客户端名称")]
        public string ClientName { get; set; }
        /// <summary>
        /// 说明
        /// </summary>
        [DisplayName("说明")]
        public string Description { get; set; }
    }
}
