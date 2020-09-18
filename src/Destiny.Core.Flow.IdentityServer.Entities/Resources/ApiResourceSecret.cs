using System;
using System.ComponentModel;

namespace Destiny.Core.Flow.IdentityServer.Entities
{
    /// <summary>
    /// api资源
    /// </summary>
    [DisplayName("api资源")]
    public class ApiResourceSecret : Secret
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