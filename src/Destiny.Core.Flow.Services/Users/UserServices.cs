using Destiny.Core.Flow.Dtos;
using Destiny.Core.Flow.Dtos.Users;
using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.Events.EventBus;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.Filter.Abstract;
using Destiny.Core.Flow.IServices;
using Destiny.Core.Flow.IServices.UserRoles;
using Destiny.Core.Flow.Model.Entities.Identity;
using Destiny.Core.Flow.Services.Users.Events;
using Destiny.Core.Flow.Ui;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Services
{
    public class UserServices : IUserServices
    {
        private readonly UserManager<User> _userManager = null;
        private readonly RoleManager<Role> _roleManager = null;
        private readonly IUnitOfWork _unitOfWork = null;
        private readonly IUserRoleService _userRoleService = null;
        private readonly IEventBus _bus = null;

        public UserServices(UserManager<User> userManager, RoleManager<Role> roleManager, IUnitOfWork unitOfWork, IUserRoleService userRoleService, IEventBus bus)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _unitOfWork = unitOfWork;
            _userRoleService = userRoleService;
            _bus = bus;
        }

        //[NonGlobalAopTran]
        //[ValidationInterceptor]
        public async Task<OperationResponse> CreateAsync(UserInputDto dto)
        {
            dto.NotNull(nameof(dto));
            var passwordHash = dto.PasswordHash;
            var user = dto.MapTo<User>();
            var result = passwordHash.IsNullOrEmpty() ? await _userManager.CreateAsync(user) : await _userManager.CreateAsync(user, passwordHash);

            return result.ToOperationResponse();
            //return await _unitOfWork.UseTranAsync(async () =>
            //{
            //    var result = passwordHash.IsNullOrEmpty() ? await _userManager.CreateAsync(user) : await _userManager.CreateAsync(user, passwordHash);
            //    if (!result.Succeeded)
            //    {
            //        return result.ToOperationResponse();
            //    }

            //    if (dto.RoleIds.Any() == true)
            //    {
            //        return await this.SetUserRoles(user, dto.RoleIds);
            //    }
            //    return new OperationResponse("添加用户成功", OperationResponseType.Success);
            //});
        }

        public async Task<OperationResponse> AllocationRoleAsync(UserAllocationRoleInputDto dto)
        {
            dto.NotNull(nameof(dto));
            var user = await _userManager.FindByIdAsync(dto.Id.ToString());
            return await _unitOfWork.UseTranAsync(async () =>
            {
                if (dto.RoleIds?.Any() == true)
                {
                    return await this.SetUserRoles(user, dto.RoleIds, false);
                }
                else
                {
                    return await this.DeleteUserRoleAsync(user);
                }
            });
        }

        private async Task<OperationResponse> DeleteUserRoleAsync(User user)
        {
            IList<string> existRoleNames = await _userManager.GetRolesAsync(user);
            IdentityResult result = await _userManager.RemoveFromRolesAsync(user, existRoleNames);

            if (!result.Succeeded)
            {
                return result.ToOperationResponse();
            }
            _bus?.PublishAsync(new UserRoleCacheDeleteEvent() { UserId = user.Id, EventState = Events.EventState.Remove });
            return result.ToOperationResponse();
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
            // IList<string> existRoleNames = await _userManager.GetRolesAsync(user);
            return await _unitOfWork.UseTranAsync(async () =>
            {
                var result = await _userManager.DeleteAsync(user);
                if (!result.Succeeded)
                {
                    return result.ToOperationResponse();
                }

                var result1 = await this.DeleteUserRoleAsync(user);
                if (!result1.Success)
                {
                    return result1;
                }
                return new OperationResponse("删除用户成功", OperationResponseType.Success);
            });
        }

        public async Task<OperationResponse<UserOutputDto>> LoadFormUserAsync(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            var userDto = user.MapTo<UserOutputDto>();
            userDto.RoleIds = await _userRoleService.GetRoleIdsByUserIdAsync(user.Id);
            return new OperationResponse<UserOutputDto>("加载成功", userDto, OperationResponseType.Success);
        }

        public async Task<OperationResponse> UpdateAsync(UserUpdateInputDto dto)
        {
            dto.NotNull(nameof(dto));
            var user = await _userManager.FindByIdAsync(dto.Id.ToString());
            user = dto.MapTo(user);
            return (await _userManager.UpdateAsync(user)).ToOperationResponse();
            //return await _unitOfWork.UseTranAsync(async () =>
            //{
            //    var result = await _userManager.UpdateAsync(user);
            //    if (!result.Succeeded)
            //    {
            //        return result.ToOperationResponse();
            //    }

            //    if (dto.RoleIds?.Any() == true)
            //    {
            //        return await this.SetUserRoles(user, dto.RoleIds, false);
            //    }
            //    else
            //    {
            //        return await this.DeleteUserRoleAsync(user);
            //    }
            //});
        }

        /// <summary>
        /// 设置用户权限
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="roleIds"></param>
        /// <returns></returns>
        private async Task<OperationResponse> SetUserRoles(User user, Guid?[] roleIds, bool isAdd = true)
        {
            IList<string> existRoleNames = await _userManager.GetRolesAsync(user);
            try
            {
                IdentityResult result = await _userManager.RemoveFromRolesAsync(user, existRoleNames);

                if (!result.Succeeded)
                {
                    return result.ToOperationResponse();
                }
                var roles = await _roleManager.Roles.Where(m => roleIds.Contains(m.Id)).ToListAsync();
                IList<string> roleNames = roles.Select(m => m.Name).ToList();

                result = await _userManager.AddToRolesAsync(user, roleNames);

                if (!result.Succeeded)
                {
                    return result.ToOperationResponse();
                }
                await _userManager.UpdateSecurityStampAsync(user);
                await _bus?.PublishAsync(new UserRoleCacheAddOrUpdateEvent() { User = user, Roles = roles, EventState = isAdd ? Events.EventState.Add : Events.EventState.Update }); ;
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
        public Task<IPagedResult<UserOutputPageListDto>> GetUserPageAsync(PageRequest request)
        {
            request.NotNull(nameof(request));
            OrderCondition<User>[] orderConditions = new OrderCondition<User>[] { new OrderCondition<User>(o => o.CreatedTime, SortDirection.Descending) };
            request.OrderConditions = orderConditions;
            return _userManager.Users.AsNoTracking().ToPageAsync<User, UserOutputPageListDto>(request);
        }

        /// <summary>
        /// 异步得到所有用户
        /// </summary>
        /// <returns></returns>
        public async Task<OperationResponse<List<UserOutputListDto>>> GetUsersAsync()
        {
            var users = await _userManager.Users.AsNoTracking().ToOutput<UserOutputListDto>().ToListAsync();

            return OperationResponse<List<UserOutputListDto>>.Ok("得到用户成功", users);
        }
        /// <summary>
        /// 得到所有用户并转成下拉
        /// </summary>
        /// <returns></returns>
        public async Task<OperationResponse<IEnumerable<SelectListItem>>> GetUsersToSelectListItemAsync()
        {
            var users = await _userManager.Users.AsNoTracking().Select(r => new SelectListItem
            {
                Value = r.Id.ToString().ToLower(),
                Text = r.UserName,
                Selected = false,
            }).ToListAsync();
            return new OperationResponse<IEnumerable<SelectListItem>>("得到数据成功", users, OperationResponseType.Success);
        }
    }
}
