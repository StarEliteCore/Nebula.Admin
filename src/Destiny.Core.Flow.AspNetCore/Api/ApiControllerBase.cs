using Destiny.Core.Flow.Dependency;
using Microsoft.AspNetCore.Mvc;

namespace Destiny.Core.Flow.AspNetCore.Api
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    //[EnableCors("Destiny.Core.Flow.API")]
    public abstract class ApiControllerBase : ControllerBase
    {
        protected IocManage IocManage => IocManage.Instance;
    }
}