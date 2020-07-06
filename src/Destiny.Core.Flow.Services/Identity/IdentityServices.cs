using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Dtos.Identitys;
using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.Events.EventBus;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.IServices.Identity;
using Destiny.Core.Flow.IServices.UserRoles;
using Destiny.Core.Flow.Model.Entities.Identity;
using Destiny.Core.Flow.Security.Jwt;
using Destiny.Core.Flow.Services.Identity.Events;
using Destiny.Core.Flow.Ui;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Services.Identity
{
    [Dependency(ServiceLifetime.Scoped)]
    public class IdentityServices : IIdentityServices
    {
        private readonly SignInManager<User> _signInManager = null;
        private readonly UserManager<User> _userManager = null;
        private readonly IJwtBearerService _jwtBearerService = null;
        private readonly IEventBus _bus;
        public IdentityServices(SignInManager<User> signInManager, UserManager<User> userManager, IJwtBearerService jwtBearerService, IEventBus bus)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtBearerService = jwtBearerService;
            _bus = bus;
        }

        public async Task<(OperationResponse item, Claim[] cliams)> Login(LoginDto loginDto)
        {
            loginDto.NotNull(nameof(loginDto));
            var user = await _userManager.FindByNameAsync(loginDto.UserName);
            if (user == null)
            {
                return (new OperationResponse("此用户不存在!!", OperationResponseType.Error), new Claim[] { });
            }
            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, true);
            if (!signInResult.Succeeded)
            {
                //if (signInResult.IsLockedOut)
                //{
                //    return (new OperationResponse($"用户因密码错误次数过多而被锁定 {_userManager.Options.Lockout.DefaultLockoutTimeSpan.TotalMinutes} 分钟，请稍后重试", OperationResponseType.Error), new Claim[] { });
                //}
                if (signInResult.IsNotAllowed)
                {
                    return (new OperationResponse("不允许登录。", OperationResponseType.Error), new Claim[] { });
                }
                return (new OperationResponse("登录失败，用户名或账号无效。", OperationResponseType.Error), new Claim[] { });
            }
            //var Role= await _userManager.GetRolesAsync(user);
            var jwtToken = _jwtBearerService.CreateToken(user.Id, user.UserName);
            await  _bus.PublishAsync(new IdentityEvent() { UserName= loginDto.UserName});
            return (new OperationResponse("登录成功", new
            {
                AccessToken = jwtToken.AccessToken,
                NickName = user.NickName,
                UserId = user.Id.ToString(),
                AccessExpires = jwtToken.AccessExpires
            }, OperationResponseType.Success), jwtToken.claims);
        }
    }
}
