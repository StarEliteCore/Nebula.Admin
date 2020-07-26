using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Modules
{
    /// <summary>
    /// 应用初始化
    /// </summary>
   public interface IApplicationInitialization
    {
        void ApplicationInitialization(ApplicationContext context);
    }
}
