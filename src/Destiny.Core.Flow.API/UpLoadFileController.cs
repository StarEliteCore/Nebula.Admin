using Destiny.Core.Flow.AspNetCore.Api;
using Destiny.Core.Flow.Filter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.API
{
    //[Route("api/[controller]")]
    //[ApiController]
    [Description("文件上传")]
    public class UpLoadFileController : ApiControllerBase
    {
        /// <summary>
        /// 文件分片上传接口
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [DisableRequestSizeLimit]
        [Description("病历文件")]
        [AllowAnonymous]
        public async Task<string> Upload([FromServices] IWebHostEnvironment environment,[FromBody] PageRequest request)
        {
            await Task.CompletedTask;
            return "";
        }
    }
}
