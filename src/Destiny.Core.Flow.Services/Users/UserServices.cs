using AutoMapper;
using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Dtos;
using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.ExpressionUtil;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.IServices.Users;
using Destiny.Core.Flow.Model.Entities.Identity;
using Destiny.Core.Flow.Ui;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Destiny.Core.Flow.Services.Users
{
    [Dependency(ServiceLifetime.Scoped)]
    public class UserServices : IUserServices
    {
        private readonly UserManager<User> _userManager = null;

        public UserServices(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<OperationResponse> CreateAsync(UserInputDto dto)
        {

            dto.NotNull(nameof(dto));
            var passwordHash = dto.PasswordHash;

            var user = dto.MapTo<User>();

            var result = passwordHash.IsNullOrEmpty() ? await _userManager.CreateAsync(user) : await _userManager.CreateAsync(user, passwordHash);
            if (!result.Succeeded)
            {
                return result.ToOperationResponse();
            }

            return new OperationResponse("添加用户成功", OperationResponseType.Success);
        }


        public async Task<OperationResponse> DeleteAsync(Guid id)
        {
            id.NotNull(nameof(id));
            var user = await _userManager.FindByIdAsync(id.ToString());
            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                return result.ToOperationResponse();
            }

            return new OperationResponse("删除成功!!", OperationResponseType.Success);
        }

        public async Task<OperationResponse<UserOutputDto>> LoadFormUserAsync(Guid id)
        {

            var user = await _userManager.FindByIdAsync(id.ToString());

            var userDto = user.MapTo<UserOutputDto>();
            return new OperationResponse<UserOutputDto>("加载成功", userDto, OperationResponseType.Success);
        }

        public async Task<OperationResponse> UpdateAsync(UserInputDto dto)
        {
            dto.NotNull(nameof(dto));
            var user = await _userManager.FindByIdAsync(dto.Id.ToString());
            user = dto.MapTo(user);
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                return result.ToOperationResponse();
            }
            return new OperationResponse("更新成功!!", OperationResponseType.Success);
        }

        /// <summary>
        /// 异步得到用户分页
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<PageResult<UserOutputPageListDto>> GetUserPageAsync(PageRequest request)
        {

            request.NotNull(nameof(request));
            var expression = FilterHelp.GetExpression<User>(request.FilterJson);
            //var expression = FilterHelp.GetExpression<User>(request.Filters);
            return await _userManager.Users.AsNoTracking().ToPageAsync<User, UserOutputPageListDto>(request);

        }
    }
}
