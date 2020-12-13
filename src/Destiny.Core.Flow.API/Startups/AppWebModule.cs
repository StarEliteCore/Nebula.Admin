using Destiny.Core.Flow.AspNetCore.Module;
using Destiny.Core.Flow.AutoMapper;
using Destiny.Core.Flow.Caching.CSRedis;
using Destiny.Core.Flow.CodeGenerator;
using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Events;
using Destiny.Core.Flow.MiniProfiler;
using Destiny.Core.Flow.Model;
using Destiny.Core.Flow.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.API.Startups
{
    [DependsOn(typeof(DestinyCoreModule),
           typeof(MvcModule),
           typeof(MiniProfilerModule),
           typeof(AspNetCoreSwaggerModule),
           typeof(IdentityModule),
           typeof(FunctionModule),
           typeof(EntityFrameworkCoreModule),
           typeof(AutoMapperModule),
           typeof(CSRedisModule),
           typeof(MongoDBModelule),
           typeof(MigrationModule),
           typeof(CodeGeneratorModeule)
    //typeof(FluentValidationModuleBase)

    )]
    public class AppWebModule : AppModule
    {
    }
}
