using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Entity
{
    /// <summary>
    /// 设置种子数据
    /// </summary>
    public interface ISeedDataAsync
    {

        /// <summary>
        /// 异步种子数据初始化
        /// </summary>
        Task InitializeAsync();

        int Order { get;  }
    }
}
