using DestinyCore.Exceptions;
using DestinyCore.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using DestinyCore.MongoDB.DbContexts;
using DestinyCore.MongoDB;
using Destiny.Core.Flow.Shared.Options;

namespace Destiny.Core.Flow.API.Startups
{
    public class MongoDBModelule : MongoDBModuleBase
    {


        protected override void AddDbContext(IServiceCollection services)
        {
            var mongoOptions = services.GetObjectOrNull<MongoOptions>();
            var connection = services.GetFileText(mongoOptions?.MongoDBConnectionString, $"未找到存放MongoDB数据库链接的文件");
            services.AddMongoDbContext<DefaultMongoDbContext>(options =>
            {
                options.ConnectionString = connection;
            });

        }
    }

}
