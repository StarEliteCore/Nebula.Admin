using Destiny.Core.Flow.Dtos;
using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.Events.EventBus;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.IServices.Identity;
using Destiny.Core.Flow.Model.Entities.Identity;
using Destiny.Core.Flow.Security.Jwt;
using Destiny.Core.Flow.Services.Identity.Events;
using Destiny.Core.Flow.Ui;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Services.Identity
{
    public class IdentityServices : IIdentityServices
    {
        private readonly SignInManager<User> _signInManager = null;
        private readonly UserManager<User> _userManager = null;
        private readonly IJwtBearerService _jwtBearerService = null;
        private readonly IMediatorHandler _bus;
        private readonly IPrincipal _principal;

        public IdentityServices(SignInManager<User> signInManager, UserManager<User> userManager, IJwtBearerService jwtBearerService, IMediatorHandler bus, IPrincipal principal)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _jwtBearerService = jwtBearerService;
            _bus = bus;
            _principal = principal;
        }

        public async Task<OperationResponse> ChangePassword(ChangePassInputDto dto)
        {
            dto.NotNull(nameof(dto));
            var userId = _principal.Identity?.GetUesrId<string>();
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return new OperationResponse("此用户不存在!!", OperationResponseType.Error);
            }
            var signInResult = await _signInManager.CheckPasswordSignInAsync(user, dto.OldPassword, true);
            if (!signInResult.Succeeded)
            {
                return OperationResponse.Error("密码不正确!!");
            }

            var result = await _userManager.ChangePasswordAsync(user, dto.OldPassword, dto.NewPassword);

            return result.ToOperationResponse();
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
                if (signInResult.IsLockedOut)
                {
                    return (new OperationResponse($"用户因密码错误次数过多而被锁定 {_userManager.Options.Lockout.DefaultLockoutTimeSpan.TotalMinutes} 分钟，请稍后重试", OperationResponseType.Error), new Claim[] { });
                }
                if (signInResult.IsNotAllowed)
                {
                    return (new OperationResponse("不允许登录。", OperationResponseType.Error), new Claim[] { });
                }
                return (new OperationResponse("登录失败，用户名或账号无效。", OperationResponseType.Error), new Claim[] { });
            }

            var jwtToken = _jwtBearerService.CreateToken(user.Id, user.UserName);
            await _bus.PublishAsync(new IdentityEvent() { UserName = loginDto.UserName });
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
