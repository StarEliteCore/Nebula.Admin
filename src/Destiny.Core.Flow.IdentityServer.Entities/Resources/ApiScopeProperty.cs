using System;
using System.ComponentModel;

namespace Destiny.Core.Flow.IdentityServer.Entities
{
    /// <summary>
    /// api授权范围属性
    /// </summary>
    [DisplayName("api授权范围属性")]
    public class ApiScopeProperty : Property
    {
        /// <summary>
        /// 范围id
        /// </summary>
        [DisplayName("范围id")]
        public Guid ScopeId { get; set; }

        /// <summary>
        /// 范围
        /// </summary>
        [DisplayName("范围")]
        public ApiScope Scope { get; set; }
    }
}