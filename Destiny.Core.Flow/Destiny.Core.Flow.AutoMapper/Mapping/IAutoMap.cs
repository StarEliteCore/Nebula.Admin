using System;
using System.Collections.Generic;
using System.Text;


namespace Destiny.Core.Flow.AutoMapper
{
    /// <summary>
    /// 自动映射接口
    /// </summary>

   public interface IAutoMap
    {
        /// <summary>
        /// 创建映射
        /// </summary>
        void CreateMap(Type[] types=null);
    }
}
