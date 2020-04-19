using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.AspNetCore.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[EnableCors("Destiny.Core.Flow.API")]
    public abstract  class ApiControllerBase : ControllerBase
    {


    }
}
