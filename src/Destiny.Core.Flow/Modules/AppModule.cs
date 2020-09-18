using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Destiny.Core.Flow.Modules
{
    public class AppModule : IAppModule
    {
        public bool Enable { get; set; } = true;

        public virtual void ApplicationInitialization(ApplicationContext context)
        {

        }

        public virtual void ConfigureServices(ConfigureServicesContext context)
        {

        }

        public Type[] GetDependedTypes(Type moduleType = null)
        {
            if (moduleType == null)
            {
                moduleType = GetType();
            }

            var dependedTypes = moduleType.GetCustomAttributes().OfType<IDependedTypesProvider>().ToArray();
            if (dependedTypes.Length == 0)
            {
                return new Type[0];
            }
            List<Type> dependList = new List<Type>();
            foreach (var dependedType in dependedTypes)
            {
                var dependeds = dependedType.GetDependedTypes();
                if (dependeds.Length == 0)
                {
                    continue;
                }
                dependList.AddRange(dependeds);

                foreach (Type type in dependeds)
                {
                    dependList.AddRange(GetDependedTypes(type));
                }

            }
            return dependList.Distinct().ToArray();
        }




        public static bool IsAppModule(Type type)
        {
            var typeInfo = type.GetTypeInfo();
            return typeInfo.IsClass &&
                 !typeInfo.IsAbstract &&
                 !typeInfo.IsGenericType &&
                 typeof(IAppModule).GetTypeInfo().IsAssignableFrom(type);
        }
    }
}
