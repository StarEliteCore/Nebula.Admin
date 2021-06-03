using DestinyCore.AspNetCore.Api;
using DestinyCore.Filter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.API
{

    /// <summary>
    /// 文件上传
    /// </summary>
    [Description("文件上传")]
    public class UpLoadFileController : AdminControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment = null;


        public UpLoadFileController(IWebHostEnvironment webHostEnvironment)
        {

            _webHostEnvironment = webHostEnvironment;
        }


        /// <summary>
        /// 异步上传
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [DisableRequestSizeLimit]
        [Description("异步上传")]
        [AllowAnonymous]
        public async Task<IActionResult> UploadAsnyc(IFormFileCollection files)
        {
            await Task.CompletedTask;
            long size = files.Sum(f => f.Length);

            foreach (var formFile in files)
            {
      
                if (formFile.Length > 0)
                {
                    var filePath = Path.GetTempFileName();

                    //using (var stream = System.IO.File.Create(filePath))
                    //{
                    //    await formFile.CopyToAsync(stream);
                    //}
                }
            }

            return Ok(new { count = files.Count, size });


        }
    }
}
