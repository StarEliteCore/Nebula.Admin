using Destiny.Core.Flow.Dtos.RoleDtos;
using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.Events.EventBus;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.Filter.Abstract;
using Destiny.Core.Flow.IServices.IRoleServices;
using Destiny.Core.Flow.Model.Entities.Identity;
using Destiny.Core.Flow.Model.Entities.Rolemenu;
using Destiny.Core.Flow.Services.RoleServices.Events;
using Destiny.Core.Flow.Ui;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Services.RoleServices
{
    public class RoleManagerServices : IRoleManagerServices
    {
        private readonly RoleManager<Role> _roleManager = null;
        private readonly IRepository<RoleMenuEntity, Guid> _roleMenuRepository;
        private readonly IMediatorHandler _eventBus = null;
        private readonly IUnitOfWork _unitOfWork = null;

        /// <summary>
        /// 构造函数注入
        /// </summary>
        /// <param name="roleManager"></param>
        public RoleManagerServices(RoleManager<Role> roleManager, IRepository<RoleMenuEntity, Guid> roleMenuRepository, IMediatorHandler eventBus, IUnitOfWork unitOfWork)
        {
            _roleManager = roleManager;
            _roleMenuRepository = roleMenuRepository;
            _eventBus = eventBus;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 异步添加角色
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        public async Task<OperationResponse> AddRoleAsync(RoleInputDto dto)
        {
            dto.NotNull(nameof(dto));
            var role = dto.MapTo<Role>();
            return await _roleMenuRepository.UnitOfWork.UseTranAsync(async () =>
            {
                var result = await _roleManager.CreateAsync(role);
                if (!result.Succeeded)
                {
                    return result.ToOperationResponse();
                }
                if (dto.MenuIds?.Any() == true)
                {
                    var list = dto.MenuIds.Select(x => new RoleMenuEntity
                    {
                        MenuId = x.Value,
                        RoleId = role.Id,
                    }).ToArray();
                    int count = await _roleMenuRepository.InsertAsync(list);
                    await _eventBus?.PublishAsync(new RoleMenuCacheAddOrUpdateEvent() { RoleId = role.Id, MenuIds = dto.MenuIds.Select(o=>o.Value), EventState = Flow.Events.EventState.Add });
                    if (count <= 0)
                    {
                        return new OperationResponse("保存失败", OperationResponseType.Error);
                    }
                }
                return new OperationResponse("保存成功", OperationResponseType.Success);
            });
        }

        public async Task<OperationResponse> DeleteAsync(Guid id)
        {
            
            
            return await _unitOfWork.UseTranAsync(async () =>
            {
                id.NotNull(nameof(id));
                var role = await _roleManager.FindByIdAsync(id.ToString());
                var result = await _roleManager.DeleteAsync(role);
                if (!result.Succeeded)
                {
                    return result.ToOperationResponse();
                }

                var count= await _roleMenuRepository.DeleteBatchAsync(o => o.RoleId == id);

                if (count > 0)
                {
                    _eventBus?.PublishAsync(new RoleMenuEventCacehDeleteEvent() { RoleId = id });
                }
              
                return new OperationResponse("删除成功!!", OperationResponseType.Success);
            });
           
        }

        public async Task<OperationResponse> UpdateRoleAsync(RoleInputDto dto)
        {
            dto.NotNull(nameof(dto));
            var role = await _roleManager.FindByIdAsync(dto.Id.ToString());
            role = dto.MapTo(role);//拿到所有角色的权限
            return await _roleMenuRepository.UnitOfWork.UseTranAsync(async () =>
            {
                var result = await _roleManager.UpdateAsync(role);
                if (!result.Succeeded)
                    return result.ToOperationResponse();
                if (dto.MenuIds?.Any() == true)
                {
                    var list = dto.MenuIds.Select(x => new RoleMenuEntity
                    {
                        MenuId = x.Value,
                        RoleId = role.Id,
                    }).ToArray();
                    int count = await _roleMenuRepository.DeleteBatchAsync(x => x.RoleId == role.Id);
                    int insertcount = await _roleMenuRepository.InsertAsync(list);
                    if (count <= 0 && insertcount <= 0)
                        return new OperationResponse("保存失败", OperationResponseType.Error);
                    await _eventBus?.PublishAsync(new RoleMenuCacheAddOrUpdateEvent() { RoleId = role.Id, MenuIds = dto.MenuIds.Select(o=>o.Value), EventState = Flow.Events.EventState.Update });
                }
                return new OperationResponse("保存成功", OperationResponseType.Success);
            });
        }

        /// <summary>
        /// 分页查询角色
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public  Task<IPagedResult<RoleOutputPageListDto>> GetRolePageAsync(PageRequest request)
        {
            request.NotNull(nameof(request));

            request.OrderConditions = new OrderCondition<Role>[] { new OrderCondition<Role>(o => o.CreatedTime, SortDirection.Descending) };
            return  _roleManager.Roles.AsNoTracking().ToPageAsync<Role, RoleOutputPageListDto>(request);
        }

        /// <summary>
        /// 得到角色把角色转成下拉
        /// </summary>
        /// <returns></returns>
        public async Task<OperationResponse<IEnumerable<SelectListItem>>> GetRolesToSelectListItemAsync()
        {
            var roles = await _roleManager.Roles.AsNoTracking().Select(r => new SelectListItem
            {
                Value = r.Id.ToString().ToLower(),
                Text = r.Name,
                Selected = false,
            }).ToListAsync();
            return new OperationResponse<IEnumerable<SelectListItem>>("得到数据成功", roles, OperationResponseType.Success);
        }


        /// <summary>
        /// 设置角色菜单
        /// </summary>
        /// <param name="roleId">角色ID</param>
        /// <param name="menuIds">菜单ID集合</param>
        /// <returns></returns>

        public async Task<OperationResponse> SetRoleMenu(Guid roleId, Guid[] menuIds)
        {

            return await _roleMenuRepository.UnitOfWork.UseTranAsync(async () =>
            {
                roleId.NotEmpty(nameof(roleId));
                if (menuIds?.Length <= 0)
                {
                    return new OperationResponse("没有选择菜单!!!", OperationResponseType.Error);

                }


                await _roleMenuRepository.DeleteBatchAsync(o => o.RoleId == roleId);

                var roleMenuList = menuIds.Select(x => new RoleMenuEntity
                {
                    MenuId = x,
                    RoleId = roleId,
                }).ToArray();

                int count = await _roleMenuRepository.InsertAsync(roleMenuList);
                if (count >= 0)
                {
                    await _eventBus?.PublishAsync(new RoleMenuCacheAddOrUpdateEvent() { RoleId = roleId, MenuIds = menuIds, EventState = Flow.Events.EventState.Update });
                }

                if (count <= 0)
                {
                    return new OperationResponse("设置角色菜单失败!!!", OperationResponseType.Error);
                }
                return new OperationResponse("设置角色菜单成功!!!", OperationResponseType.Success);

            });

        }
    }
}