using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Destiny.Core.Flow.Model.Entities.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Destiny.Core.Flow.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Description("测试")]
    public class DefaultController : ControllerBase
    {
        private readonly UserManager<User> _userManager = null;

        public DefaultController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }


        // GET: api/Default1
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            var list = await _userManager.Users.ToListAsync();
             return list.AsEnumerable();
                
        }

    } 
}