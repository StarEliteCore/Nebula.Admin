
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace Destiny.Core.Flow.API.StartupExtension
{
    /// <summary>
    /// AutoMapper注册扩展
    /// </summary>
    public static class AutoMapperExtension
    {
        public static void MapperExtension(this IServiceCollection services)
        {
            //var allType = Assembly.GetEntryAssembly()//获取默认程序集
            //        .GetReferencedAssemblies()//获取所有引用程序集
            //        .Select(Assembly.Load).SelectMany(y => y.DefinedTypes).Where(type => typeof(MapperBase).GetTypeInfo().IsAssignableFrom(type.AsType()));
            //var automapperconfig = new MapperConfigurationExpression();
            //allType.ToList().ForEach(x =>
            //{
            //    var types = x.AsType();
            //    if(typeof(MapperBase).IsAssignableFrom(types) && !types.IsInterface)
            //    {
            //        automapperconfig.AddProfile(types);
            //    }
            //});
            ////services.AddAutoMapper();

            #region 注释代码
            ////获取所有IProfile实现类
            //var allType = Assembly.GetEntryAssembly()//获取默认程序集
            //        .GetReferencedAssemblies()//获取所有引用程序集
            //        .Select(Assembly.Load).SelectMany(y => y.DefinedTypes).Where(type => typeof(MapperBase).GetTypeInfo().IsAssignableFrom(type.AsType()));

            ////allType.ToList().ForEach(x =>
            ////{
            ////    var types = x.AsType();
            ////    if (typeof(MapperBase).IsAssignableFrom(types) && !types.IsInterface)
            ////        cfg.AddProfile(types);
            ////});
            //var cfg = new MapperConfiguration(autopper=>
            //{
            //    autopper.AddProfiles(allType);
            //});
            ////这个语句只能放在注册后，不然会报错【报配置不正确】
            #endregion
        }
    }
}
