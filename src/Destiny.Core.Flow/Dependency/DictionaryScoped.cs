using Destiny.Core.Flow.Audit;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace Destiny.Core.Flow.Dependency
{
    [Dependency(ServiceLifetime.Scoped, AddSelf = true)]
    public class DictionaryScoped : ConcurrentDictionary<string, object>, IDisposable
    {


        /// <summary>
        /// 是否管理
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// 是否系统
        /// </summary>
        public bool IsSystem { get; set; }

        /// <summary>
        /// 角色名集合
        /// </summary>
        public List<string> RoleNames { get; set; }

        /// <summary>
        /// 角色集合
        /// </summary>
        public List<string> RoleIds { get; set; }


        /// <summary>
        /// 审计
        /// </summary>
        public AuditChange AuditChange { get; set; } = new AuditChange();
        public virtual void Dispose()
        {
            this.Clear();
            this.IsAdmin = false;
            this.IsSystem = false;
            this.RoleNames?.Clear();
            this.RoleIds?.Clear();
            this.AuditChange = null;
        }
    }
}