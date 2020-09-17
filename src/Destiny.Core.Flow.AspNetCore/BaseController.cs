using Destiny.Core.Flow.AspNetCore.Api;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Destiny.Core.Flow.AspNetCore
{
    [ApiController]
    public class BaseController<T> : ApiControllerBase
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