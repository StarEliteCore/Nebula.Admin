using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Destiny.Core.Flow.API.Controllers
{
    [ApiController]
    public class BaseController<T> : ControllerBase
    {
        /// <summary>
        /// 公共日志记录
        /// </summary>
        public ILogger<T> _logger;
        /// <summary>
        /// 构造注入
        /// </summary>
        /// <param name="logger"></param>
        public BaseController(ILogger<T> logger)
        {
            _logger = logger;
        }
    }
}