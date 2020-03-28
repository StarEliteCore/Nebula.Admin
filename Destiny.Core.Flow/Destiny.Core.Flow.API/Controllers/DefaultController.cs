using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Destiny.Core.Flow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class DefaultController : ControllerBase
    {

        // GET: api/Default1
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

    } 
}