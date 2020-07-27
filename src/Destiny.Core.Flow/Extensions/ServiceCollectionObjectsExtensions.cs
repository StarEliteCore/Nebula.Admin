using Destiny.Core.Flow.Dependency;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Destiny.Core.Flow.Extensions
{
  public   static partial class Extensions
    {
        public static Objects<T> TryAddObjects<T>(this IServiceCollection services)
        {
            if (services.Any(s => s.ServiceType == typeof(Objects<T>)))
            {
                return services.GetSingletonInstance<Objects<T>>();
            }

            return services.AddObjects<T>();
        }

        public static Objects<T> AddObjects<T>(this IServiceCollection services)
        {
            return services.AddObjects(new Objects<T>());
        }

        public static Objects<T> AddObjects<T>(this IServiceCollection services, T obj)
        {
            return services.AddObjects(new Objects<T>(obj));
        }

        public static Objects<T> AddObjects<T>(this IServiceCollection services, Objects<T> accessor)
        {
            if (services.Any(s => s.ServiceType == typeof(Objects<T>)))
            {
                throw new Exception("在类型“{typeof(T).AssemblyQualifiedName)}”之前注册了对象: ");
            }

            //Add to the beginning for fast retrieve
            services.Insert(0, ServiceDescriptor.Singleton(typeof(Objects<T>), accessor));
            services.Insert(0, ServiceDescriptor.Singleton(typeof(IObjects<T>), accessor));

            return accessor;
        }

        public static T GetObjectOrNull<T>(this IServiceCollection services)
            where T : class
        {
            return services.GetSingletonInstanceOrNull<IObjects<T>>()?.Value;
        }

        public static T GetObject<T>(this IServiceCollection services)
            where T : class
        {
            return services.GetObjectOrNull<T>() ?? throw new Exception($"找不到的对象 {typeof(T).AssemblyQualifiedName} 服务。请确保您以前使用过AddObjects！");
        }
    }
}
