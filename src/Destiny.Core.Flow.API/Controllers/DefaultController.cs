using Destiny.Core.Flow.Model.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.ComponentModel;
using System.Threading.Tasks;

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