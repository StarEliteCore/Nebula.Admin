using Destiny.Core.AspNetMvc.Test.Dtos;
using Destiny.Core.AspNetMvc.Test.EntityFrameworkCore.Entities;
using Destiny.Core.Flow.AspNetCore;
using Destiny.Core.Flow.Shared.Abstractions;
using DestinyCore.AspNetCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Destiny.Core.AspNetMvc.Test.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class User_TestController : CrudApiControllerBase<Guid, User_Test, User_TestInputDto, User_TestOutputDto, User_TestOutputPageListDto>
    {

        public User_TestController(ICrudServiceAsync<Guid, User_Test, User_TestInputDto, User_TestOutputDto, User_TestOutputPageListDto> crudServiceAsync) : base(crudServiceAsync)
        {

        }


        [HttpPost]
        protected AjaxResult GetPost([FromBody] User_TestInputDto dto)
        {

            return new AjaxResult(data:dto);
        }
    

    }


    
}
