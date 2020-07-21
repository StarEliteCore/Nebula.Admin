using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AspectCore.DynamicProxy;
using Destiny.Core.Flow.Events;
using Destiny.Core.Flow.Events.EventBus;
using Destiny.Core.Flow.Model.Entities.Identity;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Destiny.Core.Flow.Caching;
namespace Destiny.Core.Flow.API.Controllers
{
    [Route("api/test")]
    [ApiController]
    [AllowAnonymous]
    //[Authorize]
    public class TestController : ControllerBase
    {


        private ICache<Test> _cache = null;

        public TestController(ICache<Test> cache)
        {
            _cache = cache;
        }

        [Route("GetPage")]
        [HttpGet]
        public IEnumerable<string> Get()
        {

            List<Test> test = new List<Test>();

            for (int i = 0; i < 10; i++)
            {
                test.Add(new Test{Name=i.ToString() });
            }
            _cache.Set("_test",new Test { Name="大黄瓜"});
            var value= _cache.Get("_test");
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


