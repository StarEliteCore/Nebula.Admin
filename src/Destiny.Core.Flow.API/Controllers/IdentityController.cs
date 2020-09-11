using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Destiny.Core.Flow.AspNetCore.Api;
using Destiny.Core.Flow.AspNetCore.Ui;
using Destiny.Core.Flow.Dtos.Identitys;
using Destiny.Core.Flow.IServices.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
        public async Task<AjaxResult> LoginAsync([FromBody]LoginDto loginDto)
        {

            var result = await _identityService.Login(loginDto);
            var identity = new ClaimsIdentity(JwtBearerDefaults.AuthenticationScheme);//用户标识
            identity.AddClaims(result.cliams);
            return result.item.ToAjaxResult();
        }

        [HttpPost]
        [Description("更改密码")]
        [AllowAnonymous]
        public async Task<AjaxResult> ChangePassword([FromBody] ChangePassDto dto)
        {
            var result = await _identityService.ChangePassword(dto);
            var identity = new ClaimsIdentity(JwtBearerDefaults.AuthenticationScheme);//用户标识
            identity.AddClaims(result.cliams);
            return result.item.ToAjaxResult();
        }



    }
}