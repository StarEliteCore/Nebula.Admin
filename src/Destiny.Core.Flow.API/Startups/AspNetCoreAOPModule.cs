using AspectCore.Configuration;
using AspectCore.DynamicProxy;
using AspectCore.Extensions.DependencyInjection;
using Destiny.Core.Flow.AOP;
using Destiny.Core.Flow.Modules;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.API.Startups
{
    public class AspNetCoreAOPModule: AppModuleBase
    {
        /// <summary>
        /// AOP事务
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public override IServiceCollection ConfigureServices(IServiceCollection services)
        {
            services.ConfigureDynamicProxy(
                config =>
                {
                    List<Type> types = new List<Type>();//通过反射获取到AOP实现
                    types.Add(typeof(TranAOP));
                    foreach (var item in types)
                    {
                        if (item.BaseType == typeof(AbstractInterceptor))//判断是否继承AbstractInterceptor如果不是继承该类则不进行注册
                            config.Interceptors.AddTyped(item);
                    }
                    //config.Interceptors.AddTyped<>();
                });

            return services;
        }
    }
}
