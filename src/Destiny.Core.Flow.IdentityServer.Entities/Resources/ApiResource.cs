using System;
using System.Collections.Generic;
using System.ComponentModel;
using Destiny.Core.Flow.Entity;

namespace Destiny.Core.Flow.IdentityServer.Entities
{
    /// <summary>
    /// api资源
    /// </summary>
    [DisplayName("api资源")]
    public class ApiResource : IEntity<Guid>, ICreatedTime, IModificationTime
    {
        public Guid Id { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        [DisplayName("是否启用")]
        public bool Enabled { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        [DisplayName("名称")]
        public string Name { get; set; }

        /// <summary>
        /// 显示名称
        /// </summary>
        [DisplayName("显示名称")]
        public string DisplayName { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        [DisplayName("描述")]
        public string Description { get; set; }

        /// <summary>
        /// 允许的访问令牌登录算法
        /// </summary>
        [DisplayName("允许的访问令牌登录算法")]
        public string AllowedAccessTokenSigningAlgorithms { get; set; }

        /// <summary>
        /// 是否显示在发现文档中
        /// </summary>
        [DisplayName("是否显示在发现文档中")]
        public bool ShowInDiscoveryDocument { get; set; }

        /// <summary>
        /// 密钥
        /// </summary>
        [DisplayName("密钥")]
        public List<ApiResourceSecret> Secrets { get; set; }

        /// <summary>
        /// 授权范围
        /// </summary>
        [DisplayName("授权范围")]
        public List<ApiResourceScope> Scopes { get; set; }

        /// <summary>
        /// 用户声明
        /// </summary>
        [DisplayName("用户声明")]
        public List<ApiResourceClaim> UserClaims { get; set; }

        /// <summary>
        /// 属性
        /// </summary>
        [DisplayName("属性")]
        public List<ApiResourceProperty> Properties { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public DateTime CreatedTime { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [DisplayName("更新时间")]
        public DateTime? LastModifionTime { get; set; }

        /// <summary>
        /// 最后访问时间
        /// </summary>
        [DisplayName("最后访问时间")]
        public DateTime? LastAccessed { get; set; }

        /// <summary>
        /// 是否不可编辑
        /// </summary>
        [DisplayName("是否不可编辑")]
        public bool NonEditable { get; set; }
    }
}
