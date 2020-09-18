using Destiny.Core.Flow.AspNetCore.Api;
using Destiny.Core.Flow.AspNetCore.Ui;
using Destiny.Core.Flow.Dtos;
using Destiny.Core.Flow.IServices.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.API.Controllers
{

    /// <summary>
    /// 身份管理
    /// </summary>
    [Description("身份管理")]


    public class IdentityController : ApiControllerBase
    {
        private readonly IIdentityServices _identityService = null;

        public IdentityController(IIdentityServices identityService)
        {
            _identityService = identityService;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginDto"></param>
        /// <returns></returns>

        [HttpPost]
        [Description("登录")]
        [AllowAnonymous]
        public async Task<AjaxResult> LoginAsync([FromBody] LoginDto loginDto)
        {

            var result = await _identityService.Login(loginDto);
            var identity = new ClaimsIdentity(JwtBearerDefaults.AuthenticationScheme);//用户标识
            identity.AddClaims(result.cliams);
            return result.item.ToAjaxResult();
        }

        /// <summary>
        /// 更新密码
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        [HttpPost]
        [Description("更改密码")]
        public async Task<AjaxResult> ChangePassword([FromBody] ChangePassInputDto dto)
        {
            var result = await _identityService.ChangePassword(dto);
            var identity = new ClaimsIdentity(JwtBearerDefaults.AuthenticationScheme);//用户标识
            identity.AddClaims(result.cliams);
            return result.item.ToAjaxResult();
        }



    }
}