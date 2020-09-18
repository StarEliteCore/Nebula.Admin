using Destiny.Core.Flow.Caching;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Destiny.Core.Flow.API.Controllers
{
    [Route("api/test")]
    [ApiController]
    [AllowAnonymous]
    //[Authorize]
    public class TestController : ControllerBase
    {


        private ICache<Test> _cache = null;
        private ICache _cache1 = null;
        private IConfiguration _configuration;

        public TestController(ICache<Test> cache, ICache cache1, IConfiguration configuration)
        {
            _cache = cache;
            _cache1 = cache1;
            _configuration = configuration;
        }

        [Route("GetPage")]
        [HttpGet]
        public IEnumerable<string> Get()
        {


            Console.WriteLine($"client: {_configuration["MysqlConnectionString"]}");
            var item = _configuration.GetValue<string>("TEST1.Destiny_Apollo:MysqlConnectionString");
            Console.WriteLine(item);
            List<Test> test = new List<Test>();

            for (int i = 0; i < 10; i++)
            {
                test.Add(new Test { Name = i.ToString() });
            }
            _cache.Set("_test", new Test { Name = "大黄瓜" });
            var value = _cache.Get("_test");
            _cache1.Set("aa", test);
            var values = _cache1.Get<List<Test>>("aa");
            return new string[] { "🐕威威还是没用给我链接字符串", "🐕威威也没有给我远程仓库的权限,无法上传代码." };
        }

        // GET: api/Test/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Test
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Test/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }


    public class Test
    {
        public string Name { get; set; }
    }
}


