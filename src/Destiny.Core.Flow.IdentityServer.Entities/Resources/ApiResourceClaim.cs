using System;
using System.ComponentModel;
using Destiny.Core.Flow.Entity;

namespace Destiny.Core.Flow.IdentityServer.Entities
{
    /// <summary>
    /// api资源声明
    /// </summary>
    [DisplayName("api资源声明")]
    public class ApiResourceClaim : UserClaim
    {

        /// <summary>
        /// api资源id
        /// </summary>
        [Description("api资源id")]
        public Guid ApiResourceId { get; set; }

        /// <summary>
        /// api资源
        /// </summary>
        [Description("api资源")]
        public ApiResource ApiResource { get; set; }
    }
}