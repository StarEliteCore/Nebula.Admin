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

            var connection = services.GetFileByConfiguration("Destiny:MongoDBs:MongoDBConnectionString", "未找到存放MongoDB数据库链接的文件");

            services.AddMongoDbContext<DefaultMongoDbContext>(options =>
            {
                options.ConnectionString = connection;
            });

        }
    }

}
