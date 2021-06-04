using Destiny.Core.Flow.Model.Entities.Identity;
using DestinyCore.Options;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Description("测试")]
    [AllowAnonymous]
    public class DefaultController : ControllerBase
    {
        private readonly UserManager<User> _userManager = null;
        private readonly ILogger<DefaultController> _logger = null;
        private readonly IOptions<AppOptionSettings> _options = null;
        public DefaultController(UserManager<User> userManager, ILogger<DefaultController> logger, IOptions<AppOptionSettings> options)
        {
            _userManager = userManager;
            _logger = logger;
            _options = options;
        }


        // GET: api/Default1
        [HttpGet]
        public async Task Get()
        {


            _logger.LogError("测试1212");
           var value= _options.Value;

            await Task.CompletedTask;

        }

    }




}