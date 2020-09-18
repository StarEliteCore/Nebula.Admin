using Destiny.Core.Flow;
using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.ExpressionUtil;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.Filter.Abstract;
using Destiny.Core.Flow.MongoDB;
using Destiny.Core.Flow.MongoDB.DbContexts;
using Destiny.Core.Flow.MongoDB.Repositorys;
using Destiny.Core.Flow.TestBase;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Concurrent;
using System.ComponentModel;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace Destiny.Core.Tests
{


    public class MongoDBTests : IntegratedTest<MongoDBModelule>
    {

        private readonly IMongoDBRepository<TestDB, ObjectId> _mongoDBRepository = null;
        public MongoDBTests()
        {
            _mongoDBRepository = ServiceProvider.GetService<IMongoDBRepository<TestDB, ObjectId>>();
            //BsonClassMap.RegisterClassMap<Test001>(cm =>
            //{
            //    cm.MapIdProperty(o => o.Id);
            //    cm.MapProperty(o => o.Name);
            //    cm.ToCollection("Test001");
            //});


        }


        [Fact]

        public async Task InsertEntityAsync_Test()
        {


            for (int i = 0; i < 100; i++)
            {
                TestDB test = new TestDB();
                test.IsDeleted = false;
                test.CreatedTime = DateTime.Now;
                test.Name = $"大黄瓜18CM_{i}";
                test.Id = ObjectId.GenerateNewId();
                await _mongoDBRepository.InsertAsync(test);
            }

            var count = await _mongoDBRepository.Entities.CountAsync();
            Assert.True(count > 0);
        }




        [Fact]
        public async Task GetPageAsync_Test()
        {
            FilterCondition condition = new FilterCondition();
            QueryFilter filter = new QueryFilter();
            condition.Field = "Name";
            condition.Value = "大黄瓜18CM";
            filter.Conditions.Add(condition);
            var exp = FilterBuilder.GetExpression<TestDB>(filter);
            OrderCondition[] orderConditions = new OrderCondition[] {
                new OrderCondition("Name",Flow.Enums.SortDirection.Descending),
                new OrderCondition("CreatedTime")
               };
            PagedRequest pagedRequest = new PagedRequest();
            pagedRequest.OrderConditions = orderConditions;
            var page = await _mongoDBRepository.Collection.ToPageAsync(exp, pagedRequest);

            Assert.True(page.ItemList.Count == 10);


            var page1 = await _mongoDBRepository.Collection.ToPageAsync(exp, pagedRequest, o => new TestDto
            {
                Id = o.Id,
                Name = o.Name
            });


            Assert.True(page1.ItemList.Count == 10);

        }



        [Fact]
        public async Task UpdateAsync_Test()
        {


            try
            {

                //var entity =await  _mongoDBRepository.FindAsync(new ObjectId("5f5b695806303c854f0ba8be"));

                var update = Builders<TestDB>.Update
            .Set(t => t.IsDeleted, true);
                var filter = Builders<TestDB>.Filter.Eq(e => e.Id, new ObjectId("5f5b695906303c854f0ba8bf"));
                var re = await _mongoDBRepository.Collection.UpdateOneAsync(filter, update);
                Assert.True(re.ModifiedCount > 0);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                throw;
            }
        }
    }

    public class PagedRequest : IPagedRequest
    {

        public PagedRequest()
        {
            PageIndex = 1;
            PageSize = 10;
            OrderConditions = new OrderCondition[] { };
        }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public OrderCondition[] OrderConditions { get; set; }
    }

    public class MongoDBModelule : MongoDBModuleBase
    {

        //public override void ConfigureServices(ConfigureServicesContext context)
        //{
        //    var builder = new ConfigurationBuilder();
        //    var configuration= builder.AddJsonFile("appsettings.json").Build();

        //    var dbpath = configuration["Destiny:DbContext:MongoDBConnectionString"];
        //    var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath; //获取项目路径
        //    var dbcontext = Path.Combine(basePath, dbpath);
        //    if (!File.Exists(dbcontext))
        //    {
        //        throw new Exception("未找到存放数据库链接的文件");
        //    }
        //    var connection = File.ReadAllText(dbcontext).Trim();


        //    var services = context.Services;
        //    services.AddMongoDbContext<DefaultMongoDbContext>(options => {
        //        options.ConnectionString = connection;
        //    });
        //    //services.AddSingleton<MongoDbContextOptions>(mongoDbContextOptions);
        //    //services.AddScoped<MongoDbContext,MongoDbContext>();
        //    services.AddScoped(typeof(IMongoDBRepository<,>), typeof(MongoDBRepository<,>));
        //}
        protected override void AddDbContext(IServiceCollection services)
        {
            var builder = new ConfigurationBuilder();
            var configuration = builder.AddJsonFile("appsettings.json").Build();

            var dbpath = configuration["Destiny:DbContext:MongoDBConnectionString"];
            var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath; //获取项目路径
            var dbcontext = Path.Combine(basePath, dbpath);
            if (!File.Exists(dbcontext))
            {
                throw new Exception("未找到存放数据库链接的文件");
            }
            var connection = File.ReadAllText(dbcontext).Trim();



            services.AddMongoDbContext<TestMongoDbContext>(options =>
            {
                options.ConnectionString = connection;
            });

        }
    }


    public class TestMongoDbContext : MongoDbContextBase
    {

        public TestMongoDbContext(MongoDbContextOptions options) : base(options)
        {

        }


    }





    [MongoDBTable("TestDB")]//

    public class TestDB : MongoEntity, IFullAuditedEntity<ObjectId>
    {






        public string Name { get; set; }

        /// <summary>
        ///  获取或设置 最后修改用户
        /// </summary>
        [DisplayName("最后修改用户")]
        public virtual ObjectId? LastModifierUserId { get; set; }
        /// <summary>
        /// 获取或设置 最后修改时间
        /// </summary>
        [DisplayName("最后修改时间")]
        public virtual DateTime? LastModifionTime { get; set; }
        /// <summary>
        ///获取或设置 是否删除
        /// </summary>
        [DisplayName("是否删除")]
        public virtual bool IsDeleted { get; set; }
        /// <summary>
        ///获取或设置 创建用户ID
        /// </summary>
        [DisplayName("创建用户ID")]
        public virtual ObjectId? CreatorUserId { get; set; }
        /// <summary>
        ///获取或设置 创建时间
        /// </summary>
        [DisplayName("创建时间")]
        public virtual DateTime CreatedTime { get; set; }


    }


    public class TestDto
    {
        public ObjectId Id { get; set; }

        public string Name { get; set; }
    }

    public static partial class Extensions
    {

        private static ConcurrentDictionary<Type, string> Dic = new System.Collections.Concurrent.ConcurrentDictionary<Type, string>();

        public static BsonClassMap<TEntity> ToCollection<TEntity>(this BsonClassMap<TEntity> bson, string collection)
        {

            Dic.GetOrAdd(bson.ClassType, collection);
            return bson;
        }

        public static string GetBsonClassCollection(Type type)
        {
            Dic.TryGetValue(type, out string value);
            return value;
        }

    }

    public class Test001
    {

        public ObjectId Id { get; set; }

        public string Name { get; set; }


    }
}
