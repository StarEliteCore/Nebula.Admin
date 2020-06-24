using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.IServices.IMenu;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Services.Menu
{
    [Dependency(ServiceLifetime.Scoped)]
    public class MenuFunctionServices: IMenuFunctionServices
    {

    }
}
