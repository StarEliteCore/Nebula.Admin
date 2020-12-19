using Destiny.Core.Flow.Audit;
using System;

namespace Destiny.Core.Flow.Entity
{
    public interface IModificationTime
    {
        /// <summary>
        /// 最后修改时间
        /// </summary>
        [DisableAuditing]
        DateTime? LastModifionTime { get; set; }
    }
}