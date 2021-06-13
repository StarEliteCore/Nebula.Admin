using DestinyCore.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Destiny.Core.AspNetMvc.Test.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {



        [Route("GetPage")]
        [HttpGet]
        public IActionResult Get()
        {

            return Content("Ok");
        }

        [Route("GetPost")]
        [HttpPost]
        public IActionResult GetPost([FromBody] TestPost post)
        {

            return Content("Ok");
        }


        [Route("GetDelete")]
        [HttpDelete]
        public IActionResult GetDelete(int id)
        {
            return Content("Ok");
        }
    }

    public class TestPost { 
    
      public int Id { get; set; }

      public string Name { get; set; }
    }
}
