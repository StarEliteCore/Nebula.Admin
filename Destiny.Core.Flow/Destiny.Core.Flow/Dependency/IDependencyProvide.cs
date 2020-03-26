using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Dependency
{
    /// <summary>
    /// 自动注入服务提供器
    /// </summary>
   public interface IDependencyProvide
    {


        /// <summary>
        ///批量注入服务 
        /// </summary>
        void BulkIntoServices(IServiceCollection services);
    }
}
