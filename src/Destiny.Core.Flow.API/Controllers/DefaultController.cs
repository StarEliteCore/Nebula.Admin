using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.ExpressionUtil;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.Model.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using System.Linq.Dynamic.Core.CustomTypeProviders;
using Microsoft.Extensions.Logging;

namespace Destiny.Core.Flow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Description("测试")]
    public class DefaultController : ControllerBase
    {
        private readonly UserManager<User> _userManager = null;
        private readonly ILogger<DefaultController> _logger = null;
        public DefaultController(UserManager<User> userManager, ILogger<DefaultController> logger)
        {
            _userManager = userManager;
            _logger = logger;
        }


        // GET: api/Default1
        [HttpGet]
        public async Task Get()
        {


            _logger.LogError("测试1212");


            await Task.CompletedTask;

        }

    }

  
    

}