using System;
using System.Collections.Generic;
using System.ComponentModel;
using Destiny.Core.Flow.Entity;

namespace Destiny.Core.Flow.Dtos.IdentityServer4
{
    /// <summary>
    /// API资源基类DTO
    /// </summary>
    public class ApiResourceInputBase:IDto<Guid>
    {
        /// <summary>
        /// 主键
        /// </summary>
        [DisplayName("主键")]
        public Guid Id { get; set; }
        
        /// <summary>
        /// 名称
        /// </summary>
        [DisplayName("名称")]
        public string Name { get; set; }

  
        /// <summary>
        /// 是否启用
        /// </summary>
        [DisplayName("是否启用")]
        public bool Enabled { get; set; }

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
        /// 用户声明
        /// </summary>
        [DisplayName("用户声明")]
        
        public ICollection<string> UserClaims { get; set; }

        /// <summary>
        /// Api秘钥
        /// </summary>
        public ICollection<string> ApiSecrets { get; set; }

        /// <summary>
        /// 范围
        /// </summary>
        public ICollection<string> Scopes { get; set; }
    }
}