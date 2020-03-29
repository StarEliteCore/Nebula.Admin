using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Entity
{
    /// <summary>
    /// 软删除
    /// </summary>
    public interface ISoftDelete
    {

        bool IsDeleted { get; set; }

    }
}
