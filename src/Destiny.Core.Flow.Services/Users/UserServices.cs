using AutoMapper;
using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Dtos;
using Destiny.Core.Flow.EntityFrameworkCore;
using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.ExpressionUtil;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.Filter.Abstract;
using Destiny.Core.Flow.IServices;
using Destiny.Core.Flow.IServices.UserRoles;
using Destiny.Core.Flow.Model.Entities.Identity;
using Destiny.Core.Flow.Ui;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Destiny.Core.Flow.Services
{
    [Dependency(ServiceLifetime.Scoped)]
    public class UserServices : IUserServices
    {
        private readonly UserManager<User> _userManager = null;
        private readonly RoleManager<Role> _roleManager = null;
        private readonly IUnitOfWork _unitOfWork = null;
        private readonly IUserRoleService _userRoleService = null;

        public UserServices(UserManager<User> userManager, RoleManager<Role> roleManager, IUnitOfWork unitOfWork, IUserRoleService userRoleService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
            _userRoleService = userRoleService;
        }

        public async Task<OperationResponse> CreateAsync(UserInputDto dto)
        {

            dto.NotNull(nameof(dto));
            var passwordHash = dto.PasswordHash;

            var user = dto.MapTo<User>();
            return await _unitOfWork.UseTranAsync(async () =>
            {
                var result = passwordHash.IsNullOrEmpty() ? await _userManager.CreateAsync(user) : await _userManager.CreateAsync(user, passwordHash);
                if (!result.Succeeded)
                {
                    return result.ToOperationResponse();
                }

                if (dto.RoleIds?.Any() == true)
                {
                    return await this.SetUserRoles(user, dto.RoleIds);
                }
                return new OperationResponse("添加用户成功", OperationResponseType.Success);

            });

        }

        /// <summary>
        /// 删除用户
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<OperationResponse> DeleteAsync(Guid id)
        {
            id.NotNull(nameof(id));
            var user = await _userManager.FindByIdAsync(id.ToString());
            IList<string> existRoleNames = await _userManager.GetRolesAsync(user);
            return await _unitOfWork.UseTranAsync(async () =>
            {
                var result = await _userManager.DeleteAsync(user);
                if (!result.Succeeded)
                {
                    return result.ToOperationResponse();
                }
                result = await _userManager.RemoveFromRolesAsync(user, existRoleNames);
                if (!result.Succeeded)
                {
                    return result.ToOperationResponse();
                }
                return new OperationResponse("删除用户成功", OperationResponseType.Success);
            }); ;

        }



        public async Task<OperationResponse<UserOutputDto>> LoadFormUserAsync(Guid id)
        {

            var user = await _userManager.FindByIdAsync(id.ToString());

            var userDto = user.MapTo<UserOutputDto>();
            userDto.RoleIds =await _userRoleService.GetRoleIdsByUserIdAsync(user.Id);
            return new OperationResponse<UserOutputDto>("加载成功", userDto, OperationResponseType.Success);
        }

        public async Task<OperationResponse> UpdateAsync(UserInputDto dto)
        {
            dto.NotNull(nameof(dto));
            var user = await _userManager.FindByIdAsync(dto.Id.ToString());
            user = dto.MapTo(user);
            return await _unitOfWork.UseTranAsync(async () =>
            {
                var result = await _userManager.UpdateAsync(user);
                if (!result.Succeeded)
                {
                    return result.ToOperationResponse();
                }

                if (dto.RoleIds?.Any() == true)
                {
                    return await this.SetUserRoles(user, dto.RoleIds);
                }

                return new OperationResponse("更新成功!!", OperationResponseType.Success);

            });

        }


        /// <summary>
        /// 设置用户权限
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        private async Task<OperationResponse> SetUserRoles(User user, Guid[] roleIds)
        {
            IList<string> roleNames = await _roleManager.Roles.Where(m => roleIds.Contains(m.Id)).Select(m => m.Name).ToListAsync();

            IList<string> existRoleNames = await _userManager.GetRolesAsync(user);
            try
            {

                IdentityResult result = await _userManager.RemoveFromRolesAsync(user, existRoleNames);
                if (!result.Succeeded)
                {
                    return result.ToOperationResponse();
                }
                result = await _userManager.AddToRolesAsync(user, roleNames);

                if (!result.Succeeded)
                {
                    return result.ToOperationResponse();
                }
                await _userManager.UpdateSecurityStampAsync(user);
            }
            catch (InvalidOperationException ex)
            {

                return new OperationResponse(ex.Message, OperationResponseType.Error);
            }
            return new OperationResponse("添加用户角色成功", OperationResponseType.Success);

        }
        /// <summary>
        /// 异步得到用户分页
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IPagedResult<UserOutputPageListDto>> GetUserPageAsync(PageRequest request)
        {

            request.NotNull(nameof(request));
            Console.WriteLine("方法执行中");
            var expression = FilterHelp.GetExpression<User>(request.Filters);
            //var expression = FilterHelp.GetExpression<User>(request.Filters);
            return await _userManager.Users.AsNoTracking().ToPageAsync<User, UserOutputPageListDto>(request);

        }
    }
}
