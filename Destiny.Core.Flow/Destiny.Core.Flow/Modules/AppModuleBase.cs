using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Modules
{
    /// <summary>
    ///服务模块基类
    /// </summary>
   public abstract class AppModuleBase
    {

        /// <summary>
        /// 将模块服务添加到依赖注入服务容器中
        /// </summary>
        /// <param name="services">依赖注入服务容器</param>
        /// <returns></returns>
        public virtual IServiceCollection ConfigureServices(IServiceCollection services)
        {
            return services;
        }


        /// <summary>
        /// 此方法由运行时调用。使用此方法配置HTTP请求管道。
        /// </summary>
        /// <param name="applicationBuilder"></param>
        public virtual void Configure(IApplicationBuilder applicationBuilder)
        {

        }
    }
}
