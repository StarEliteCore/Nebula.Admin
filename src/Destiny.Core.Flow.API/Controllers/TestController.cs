using DestinyCore.Caching;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
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


    
        private ICache _cache1 = null;
        private IConfiguration _configuration;
        private ILogger _logger = null;
        public TestController( ICache cache1, IConfiguration configuration,ILoggerFactory loggerFactory)
        {
      
            _cache1 = cache1;
            _configuration = configuration;
            _logger = loggerFactory.CreateLogger<TestController>();
        }

        [Route("GetPage")]
        [HttpGet]
        public IEnumerable<string> Get()
        {


            Console.WriteLine($"client: {_configuration["MysqlConnectionString"]}");
            var item = _configuration.GetValue<string>("TEST1.Destiny_Apollo:MysqlConnectionString");
            Console.WriteLine(item);
           
            var values = _cache1.Get<List<Test>>("aa");
            return new string[] { "🐕威威还是没用给我链接字符串", "🐕威威也没有给我远程仓库的权限,无法上传代码." };
        }

        // GET: api/Test/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            _logger.LogError("出错拉");
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


