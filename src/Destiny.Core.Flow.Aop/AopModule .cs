using AspectCore.Configuration;
using AspectCore.DynamicProxy;
using AspectCore.Extensions.DependencyInjection;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Modules;
using Destiny.Core.Flow.Reflection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Aop
{
   public  class AopModule: AppModule
    {
        public override void ConfigureServices(ConfigureServicesContext context)
        {
            var service = context.Services;
            var typefinder = service.GetService<ITypeFinder>();
            typefinder.NotNull(nameof(typefinder));
            var typs = typefinder.Find(o => o.IsClass && !o.IsAbstract && !o.IsInterface && o.IsSubclassOf(typeof(AbstractInterceptor)));
            var  interceptorsModule = service.GetConfiguration()["Destiny:InterceptorsModule"];
 

            if (typs?.Length > 0)
            {
                List<Type> types = new List<Type>();
    
                foreach (var item in typs)
                {
                    //service.AddTransient(item);
                    service.ConfigureDynamicProxy(cof =>
                    {
                        var enabled = service.GetConfiguration()[$"Destiny:AopManager:{item.Name}:Enabled"].ObjToBool();
                        if (enabled)
                            cof.Interceptors.AddTyped(item, Predicates.ForNameSpace(interceptorsModule)/*,Predicates.ForNameSpace(IInterceptorsModule)*/);////这种是配置只需要代理的层, Predicates.ForNameSpace("Sukt.Core.Application.Contracts")
                        //config.NonAspectPredicates.AddService("IUnitofWork");//需要过滤掉不需要代理的服务层
                    });
                }
            }
        }

      
    }
}
