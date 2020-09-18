using System;
using System.ComponentModel;

namespace Destiny.Core.Flow.IdentityServer.Entities
{
    /// <summary>
    /// api资源属性
    /// </summary>
    [DisplayName("api资源属性")]
    public class ApiResourceProperty : Property
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