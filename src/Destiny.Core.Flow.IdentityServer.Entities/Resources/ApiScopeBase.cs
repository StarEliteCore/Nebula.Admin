using Destiny.Core.Flow.Entity;
using System;
using System.ComponentModel;

namespace Destiny.Core.Flow.IdentityServer.Entities
{
    /// <summary>
    /// api授权范围
    /// </summary>
    [DisplayName("api授权范围")]
    public abstract class ApiScopeBase : IEntity<Guid>
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        [Description("是否启用")]
        public bool Enabled { get; set; }


        /// <summary>
        /// 名称
        /// </summary>
        [Description("名称")]
        public string Name { get; set; }

        /// <summary>
        /// 显示名称
        /// </summary>
        [Description("显示名称")]
        public string DisplayName { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [Description("描述")]
        public string Description { get; set; }

        /// <summary>
        /// 是否必须
        /// </summary>
        [Description("是否必须")]
        public bool Required { get; set; }

        /// <summary>
        /// 是否强调显示
        /// </summary>
        [Description("是否强调显示")]
        public bool Emphasize { get; set; }

        /// <summary>
        /// 是否显示在发现文档中
        /// </summary>
        [Description("是否显示在发现文档中")]
        public bool ShowInDiscoveryDocument { get; set; }

        ///// <summary>
        ///// 用户声明
        ///// </summary>
        //public List<ApiScopeClaimBase> UserClaims { get; set; }

        ///// <summary>
        ///// 属性
        ///// </summary>
        //public List<ApiScopePropertyBase> Properties { get; set; }
    }
}
