using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Destiny.Core.Flow.AspNetCore.Api;
using Destiny.Core.Flow.AspNetCore.Ui;
using Destiny.Core.Flow.Dtos.Functions;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.IServices.Functions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Destiny.Core.Flow.API.Controllers
{
    /// <summary>
    /// 功能管理
    /// </summary>
    [Description("功能管理")]
    [Authorize]
    public class FunctionController : ApiControllerBase
    {

        private readonly IFunctionService _functionService;

        public FunctionController(IFunctionService functionService)
        {
            _functionService = functionService ?? throw new ArgumentNullException(nameof(functionService));
        }



        /// <summary>
        /// 异步得到功能分页
        /// </summary>
        /// <param name="request">请求分页参数</param>
        /// <returns></returns>
        [Description("异步得到功能分页")]
        [HttpPost]
        public async Task<PageList<FunctionOutputPageList>> GetFunctionPageAsync([FromBody] PageRequest request)
        {
            return (await _functionService.GetFunctionPageAsync(request)).ToPageList();
        
        }
    }
}
