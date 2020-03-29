using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Modules
{
    public interface IAppModuleManager
    {

        IServiceCollection LoadModules(IServiceCollection services);

        List<AppModuleBase> SourceModules { get; }

        //此方法由运行时调用。使用此方法配置HTTP请求管道。
        void Configure(IApplicationBuilder applicationBuilder);
    }
}
