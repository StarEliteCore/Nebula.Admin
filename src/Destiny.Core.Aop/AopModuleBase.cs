using AspectCore.Configuration;
using AspectCore.DynamicProxy;
using AspectCore.Extensions.DependencyInjection;
using Destiny.Core.Aop.Aop;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Modules;
using Destiny.Core.Flow.Reflection;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Aop
{
    public abstract class AopModuleBase: AppModuleBase
    {
        public override IServiceCollection ConfigureServices(IServiceCollection service)
        {
            var typefinder = service.GetOrAddSingletonService<ITypeFinder, TypeFinder>();
            typefinder.NotNull(nameof(typefinder));
            var typs = typefinder.Find(o => o.IsClass && !o.IsAbstract && !o.IsInterface && o.IsSubclassOf(typeof(AbstractInterceptor)));
            var InterceptorsModule = service.GetConfiguration()["Destiny:InterceptorsModule"];
            if (typs?.Length > 0)
            {
                List<Type> types = new List<Type>();
                types.Add(typeof(AopTran));

                foreach (var item in types)
                {
                    //service.AddTransient(item);
                    service.ConfigureDynamicProxy(cof =>
                    {
                        var Enabled = service.GetConfiguration()[$"Destiny:AopManager:{item.Name}:Enabled"].ObjToBool();
                        if (Enabled)
                            cof.Interceptors.AddTyped(item, Predicates.ForNameSpace("Destiny.Core.Flow.Services"), Predicates.ForNameSpace("Destiny.Core.Flow.IServices"));////这种是配置只需要代理的层
                        //config.NonAspectPredicates.AddService("IUnitofWork");//需要过滤掉不需要代理的服务层  
                    });
                }
            }
            return service;
        }
    }
}
