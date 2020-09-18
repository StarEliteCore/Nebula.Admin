using Destiny.Core.Flow.Exceptions;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.MongoDB.DbContexts;
using Microsoft.Extensions.DependencyInjection;
using System.IO;

namespace Destiny.Core.Flow.API.Startups
{
    public class MongoDBModelule : MongoDBModuleBase
    {


        protected override void AddDbContext(IServiceCollection services)
        {
            var dbpath = services.GetConfiguration()["Destiny:DbContext:MongoDBConnectionString"];

            var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath; //获取项目路径
            var dbcontext = Path.Combine(basePath, dbpath);
            if (!File.Exists(dbcontext))
            {
                throw new AppException("未找到存放数据库链接的文件");
            }
            var connection = File.ReadAllText(dbcontext).Trim();



            services.AddMongoDbContext<DefaultMongoDbContext>(options =>
            {
                options.ConnectionString = connection;
            });

        }
    }

}
