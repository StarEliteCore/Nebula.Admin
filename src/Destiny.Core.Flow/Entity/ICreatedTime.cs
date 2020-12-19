using Destiny.Core.Flow.Audit;
using System;

namespace Destiny.Core.Flow.Entity
{
    /// <summary>
    /// 创建时间
    /// </summary>
    public interface ICreatedTime
    {
        [DisableAuditing]
        DateTime CreatedTime { get; set; }
    }
}