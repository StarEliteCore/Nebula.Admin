using System;

namespace Destiny.Core.Flow.Modules
{
    /// <summary>
    /// 模块接口
    /// </summary>
    public interface IAppModule : IApplicationInitialization
    {
        void ConfigureServices(ConfigureServicesContext context);





        /// <summary>
        //得到依赖集合
        /// </summary>
        /// <param name="moduleType"></param>
        /// <returns></returns>
        Type[] GetDependedTypes(Type moduleType = null);


        bool Enable { get; set; }


    }
}
