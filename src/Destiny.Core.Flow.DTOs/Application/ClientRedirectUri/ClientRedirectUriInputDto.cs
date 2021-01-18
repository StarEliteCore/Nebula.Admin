using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Mapping;
using Destiny.Core.Flow.Model.DestinyIdentityServer4;
using System;
using System.ComponentModel;

namespace IDN.Services.BasicsService.Dtos.Application
{
    [AutoMapTo(typeof(ClientRedirectUri))]
    public class ClientRedirectUriInputDto : InputDto<Guid>
    {
        /// <summary>
        /// 重定向uri
        /// </summary>
        [DisplayName("重定向uri")]
        public string RedirectUri { get; set; }
        /// <summary>
        /// 客户端id
        /// </summary>
        [DisplayName("客户端id")]
        public Guid ClientId { get; set; }
    }
}
