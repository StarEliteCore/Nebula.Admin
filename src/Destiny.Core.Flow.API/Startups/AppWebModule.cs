using Destiny.Core.Flow.EntityFrameworkCore;
using Destiny.Core.Flow.Model;
using DestinyCore.AspNetCore;
using DestinyCore.AutoMapper;
using DestinyCore.Caching.CSRedis;
using DestinyCore.CodeGenerator;
using DestinyCore.MiniProfiler;
using DestinyCore.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.API.Startups
{
    [DependsOn
           (typeof(DestinyCoreConfigModule),
           typeof(MvcModule),
           typeof(MiniProfilerModule),
           typeof(AspNetCoreSwaggerModule),
           typeof(IdentityModule),
           typeof(FunctionModule),
           typeof(EntityFrameworkCoreModule),
           typeof(AutoMapperModule),
           //typeof(CachingDefaultModule), //普通缓存
           typeof(CSRedisModule), //redis缓存
           typeof(MongoDBModelule),
           typeof(MigrationModule),
           typeof(CodeGeneratorModeule)
    //typeof(FluentValidationModuleBase)

    )]
    public class AppWebModule : AppModule
    {
    }
}
