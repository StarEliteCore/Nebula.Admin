using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MOSI.IdentityServer4.Identity.Quickstart.Health
{
    [Route("api/health")]
    [ApiController]
    [AllowAnonymous]
    public class HealthController : ControllerBase
    {
        /// <summary>
        /// 健康监测
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("ok");
        }
    }
}