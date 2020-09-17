using System;
using System.ComponentModel;
using Destiny.Core.Flow.Entity;

namespace Destiny.Core.Flow.IdentityServer.Entities
{
    public class ApiResourceScope : IEntity<Guid>
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 授权范围
        /// </summary>
        [Description("授权范围")]
        public string Scope { get; set; }

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