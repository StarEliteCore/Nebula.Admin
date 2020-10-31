using Destiny.Core.Flow.Dtos.Menu;
using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.Filter.Abstract;
using Destiny.Core.Flow.IServices.IMenu;
using Destiny.Core.Flow.Model.Entities.Identity;
using Destiny.Core.Flow.Model.Entities.Menu;
using Destiny.Core.Flow.Model.Entities.Rolemenu;
using Destiny.Core.Flow.Repository.MenuRepository;
using Destiny.Core.Flow.Ui;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Services.Menu
{
    public class MenuServices : IMenuServices
    {
        private readonly IMenuRepository _menuRepository = null;
        private readonly IEFCoreRepository<RoleMenuEntity, Guid> _roleMenuRepository;
        private readonly IMenuFunctionRepository _menuFunction = null;
        private readonly IUnitOfWork _unitOfWork = null;
        private readonly IIdentity _iIdentity = null;
        private readonly IEFCoreRepository<UserRole, Guid> _repositoryUserRole = null;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public MenuServices(IMenuRepository menuRepository, IUnitOfWork unitOfWork, IEFCoreRepository<RoleMenuEntity, Guid> roleMenuRepository, IMenuFunctionRepository menuFunction, IPrincipal principal, UserManager<User> userManager, RoleManager<Role> roleManager, IEFCoreRepository<UserRole, Guid> repositoryUserRole)
        {
            _menuRepository = menuRepository;
            _roleMenuRepository = roleMenuRepository;
            this._menuFunction = menuFunction;
            _unitOfWork = unitOfWork;
            _iIdentity = principal.Identity;
            _userManager = userManager;
            _roleManager = roleManager;
            _repositoryUserRole = repositoryUserRole;
        }

        public async Task<OperationResponse> CreateAsync(MenuInputDto input)
        {
            input.NotNull(nameof(input));
            return await _unitOfWork.UseTranAsync(async () =>
            {
                var result = await _menuRepository.InsertAsync(input);
                if (input.FunctionId?.Any() == true)
                {
                    int count = await _menuFunction.InsertAsync(input.FunctionId.Select(x => new MenuFunction
                    {
                        MenuId = input.Id,
                        FunctionId = x
                    }).ToArray());
                }
                return new OperationResponse("保存成功", OperationResponseType.Success);
            });
        }

        public async Task<OperationResponse> DeleteAsync(Guid id)
        {
            return await _menuRepository.DeleteAsync(id);
        }

        public async Task<OperationResponse> UpdateAsync(MenuInputDto input)
        {
            input.NotNull(nameof(input));
            return await _unitOfWork.UseTranAsync(async () =>
            {
                var result = await _menuRepository.UpdateAsync(input);
                await _menuFunction.DeleteBatchAsync(x => x.MenuId == input.Id);
                if (input.FunctionId?.Any() == true)
                {
                    int count = await _menuFunction.InsertAsync(input.FunctionId.Select(x => new MenuFunction
                    {
                        MenuId = input.Id,
                        FunctionId = x
                    }).ToArray());
                }
                return new OperationResponse("保存成功", OperationResponseType.Success);
            });
        }

        /// <summary>
        /// </summary>
        /// <param name="roleid">角色Id</param>
        /// <returns></returns>
        public async Task<OperationResponse<SelectedItem<MenuTreeOutDto, Guid>>> GetMenuTreeAsync(Guid? roleId)
        {
            var rolelist = new List<RoleMenuEntity>();
            var list = await _menuRepository.Entities.ToTreeResultAsync<MenuEntity, MenuTreeOutDto>(
                (r, c) =>
                {
                    return c.ParentId == null || c.ParentId == Guid.Empty;
                }, (p, q) =>
                {
                    return p.Id == q.ParentId;
                }, (p, q) =>
                {
                    if (p.children == null)
                    {
                        p.children = new List<MenuTreeOutDto>();
                    }

                    p.children.AddRange(q);
                });
            SelectedItem<MenuTreeOutDto, Guid> selectedItem = new SelectedItem<MenuTreeOutDto, Guid>();
            selectedItem.ItemList = list.ItemList.ToList();
            selectedItem.Selected = new List<Guid>();
            if (roleId.HasValue)
            {
                selectedItem.Selected = await _roleMenuRepository.Entities.Where(o => o.RoleId == roleId.Value).Select(o => o.MenuId).ToListAsync();
            }
            OperationResponse<SelectedItem<MenuTreeOutDto, Guid>> operationResponse = new OperationResponse<SelectedItem<MenuTreeOutDto, Guid>>();
            operationResponse.Type = OperationResponseType.Success;
            operationResponse.Data = selectedItem;

            return operationResponse;
        }

    
        /// <summary>
        /// 根据ID获取一个菜单
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<OperationResponse<MenuOutputLoadDto>> LoadFormMenuAsync(Guid Id)
        {
            var menu = await _menuRepository.GetByIdAsync(Id);
            var menudto = menu.MapTo<MenuOutputLoadDto>();
            menudto.FunctionIds = (await _menuFunction.Entities.Where(x => x.MenuId == Id && x.IsDeleted == false).ToListAsync()).Select(x => x.FunctionId).ToArray();
            return new OperationResponse<MenuOutputLoadDto>(MessageDefinitionType.LoadSucces, menudto, OperationResponseType.Success);
        }

        /// <summary>
        /// 根据ID获取一个菜单
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<OperationResponse<List<MenuOutputLoadDto>>> GetMenuChildrenButton(Guid Id)
        {
            var menulist = new List<MenuPermissionsOutDto>();
            var userId = _iIdentity.GetUesrId<Guid>();
            var usermodel = await _userManager.FindByIdAsync(userId.ToString());
            var roleids = (await _repositoryUserRole.Entities.Where(x => x.UserId == userId).ToListAsync()).Select(x => x.RoleId);
            var menuId = (await _roleMenuRepository.Entities.Where(x => roleids.Contains(x.RoleId)).ToListAsync()).Select(x => x.MenuId);
            if (usermodel.IsSystem && _roleManager.Roles.Where(x => x.IsAdmin == true && roleids.Contains(x.Id)).Any())
            {
                var menus = await _menuRepository.Entities.Where(x => x.ParentId == Id && x.Type == MenuEnum.Button).Select(a => new MenuOutputLoadDto
                {
                    Name = a.Name,
                    Path = a.Path,
                    Icon = a.Icon
                }).ToListAsync();
                return new OperationResponse<List<MenuOutputLoadDto>>(MessageDefinitionType.LoadSucces, menus, OperationResponseType.Success);
            }
            if (!menuId.Contains(Id))
            {
                return new OperationResponse<List<MenuOutputLoadDto>>(MessageDefinitionType.LoadSucces, new List<MenuOutputLoadDto>(), OperationResponseType.Success);
            }
            var menu = await _menuRepository.Entities.Where(x => x.ParentId == Id && x.Type == MenuEnum.Button && menuId.Contains(x.Id)).Select(a => new MenuOutputLoadDto
            {
                Name = a.Name,
                Path = a.Path,
                Icon = a.Icon
            }).ToListAsync();
            return new OperationResponse<List<MenuOutputLoadDto>>(MessageDefinitionType.LoadSucces, menu, OperationResponseType.Success);
        }

        public async Task<TreeResult<MenuTableOutDto>> GetMenuTableAsync()
        {
            return await _menuRepository.Entities.ToTreeResultAsync<MenuEntity, MenuTableOutDto>(
             (p, c) =>
             {
                 return c.ParentId == null || c.ParentId == Guid.Empty;
             },
             (p, c) =>
             {
                 return p.Id == c.ParentId;
             },
             (p, children) =>
             {
                 if (p.children == null)
                     p.children = new List<MenuTableOutDto>();
                 p.children.AddRange(children);
             }
             );
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public async Task<OperationResponse<Dictionary<string, bool>>> GetMenuAsync()
        {
            Dictionary<string, bool> dic = new Dictionary<string, bool>();
            var menulist = new List<MenuPermissionsOutDto>();
            var userId = _iIdentity.GetUesrId<Guid>();
            var usermodel = await _userManager.FindByIdAsync(userId.ToString());
            var roleids = (await _repositoryUserRole.Entities.Where(x => x.UserId == userId).ToListAsync()).Select(x => x.RoleId);
            var menuId = (await _roleMenuRepository.Entities.Where(x => roleids.Contains(x.RoleId)).ToListAsync()).Select(x => x.MenuId);
            if (usermodel.IsSystem && _roleManager.Roles.Where(x => x.IsAdmin == true && roleids.Contains(x.Id)).Any())
            {
                menulist.AddRange(await _menuRepository.Entities.Where(x => x.Type == MenuEnum.Menu).Select(x => new MenuPermissionsOutDto
                {
                    Name = x.Name,
                    RouterPath = x.Path,
                    Id = x.Id,
                    Sort = x.Sort,
                }).ToListAsync());
                foreach (var item in menulist)
                {
                    dic.Add(item.RouterPath, true);
                }
                return new OperationResponse<Dictionary<string, bool>>(MessageDefinitionType.LoadSucces, dic, OperationResponseType.Success);
            }
            menulist.AddRange(await _menuRepository.Entities.Where(x => x.Type == MenuEnum.Menu).Select(x => new MenuPermissionsOutDto
            {
                Name = x.Name,
                RouterPath = x.Path,
                Id = x.Id,
                Sort = x.Sort,
            }).ToListAsync());
            foreach (var item in menulist)
            {
                if (menuId.Contains(item.Id))
                    dic.Add(item.RouterPath, true);
                else
                    dic.Add(item.RouterPath, false);
            }
            return new OperationResponse<Dictionary<string, bool>>(MessageDefinitionType.LoadSucces, dic, OperationResponseType.Success);
        }

        /// <summary>
        /// 获取菜单树形
        /// </summary>
        /// <returns></returns>
        public async Task<OperationResponse> GetUserMenuTreeAsync()
        {
            var menulist = new List<MenuPermissionsTreeOutDto>();
            var userId = _iIdentity.GetUesrId<Guid>();
            var usermodel = await _userManager.FindByIdAsync(userId.ToString());
            var roleids = (await _repositoryUserRole.Entities.Where(x => x.UserId == userId).ToListAsync()).Select(x => x.RoleId);
            var menuId = (await _roleMenuRepository.Entities.Where(x => roleids.Contains(x.RoleId)).ToListAsync()).Select(x => x.MenuId);
            if (usermodel.IsSystem && _roleManager.Roles.Where(x => x.IsAdmin == true && roleids.Contains(x.Id)).Any())
            {
                var list = await _menuRepository.Entities.ToTreeResultAsync<MenuEntity, MenuPermissionsTreeOutDto>((p, c) =>
                {
                    return c.ParentId == null || c.ParentId == Guid.Empty;
                },
                 (p, c) =>
                 {
                     return p.Id == c.ParentId;
                 },
                 (p, children) =>
                 {
                     if (p.routes == null)
                         p.routes = new List<MenuPermissionsTreeOutDto>();
                     p.routes.AddRange(children);
                 });
                menulist.AddRange(list.ItemList);
                return new OperationResponse(MessageDefinitionType.LoadSucces, menulist, OperationResponseType.Success);
                //return new PageResult<MenuPermissionsOutDto>()
                //{
                //    ItemList = menulist,
                //    Total = menulist.Count,
                //};
            }
            var result = await _menuRepository.Entities.ToTreeResultAsync<MenuEntity, MenuPermissionsTreeOutDto>((p, c) =>
            {
                return c.ParentId == null || c.ParentId == Guid.Empty;
            },
                 (p, c) =>
                 {
                     return p.Id == c.ParentId;
                 },
                 (p, children) =>
                 {
                     if (p.routes == null)
                         p.routes = new List<MenuPermissionsTreeOutDto>();
                     p.routes.AddRange(children);
                 });
            menulist.AddRange(result.ItemList);
            return new OperationResponse(MessageDefinitionType.LoadSucces, menulist, OperationResponseType.Success);
        }

        /// <summary>
        /// </summary>
        /// <returns></returns>
        public async Task<OperationResponse> GetMenuListAsync()
        {
            var menulist = new List<MenuPermissionsOutDto>();
            var userId = _iIdentity.GetUesrId<Guid>();
            var usermodel = await _userManager.FindByIdAsync(userId.ToString());
            var roleids = (await _repositoryUserRole.Entities.Where(x => x.UserId == userId).ToListAsync()).Select(x => x.RoleId);
            var menuId = (await _roleMenuRepository.Entities.Where(x => roleids.Contains(x.RoleId)).ToListAsync()).Select(x => x.MenuId);
            if (usermodel.IsSystem && _roleManager.Roles.Where(x => x.IsAdmin == true && roleids.Contains(x.Id)).Any())
            {
                menulist.AddRange(await _menuRepository.Entities.Select(x => new MenuPermissionsOutDto
                {
                    Name = x.Name,
                    RouterPath = x.Path,
                    Id = x.Id,
                    Sort = x.Sort,
                }).ToListAsync());
                return new OperationResponse(MessageDefinitionType.LoadSucces, menulist, OperationResponseType.Success);
            }
            menulist.AddRange(await _menuRepository.Entities.Where(x => menuId.Contains(x.Id)).Select(x => new MenuPermissionsOutDto
            {
                Name = x.Name,
                RouterPath = x.Path,
                Id = x.Id,
                Sort = x.Sort,
            }).ToListAsync());
            return new OperationResponse(MessageDefinitionType.LoadSucces, menulist, OperationResponseType.Success);
        }

        /// <summary>
        /// 异步得到所有菜单
        /// </summary>
        /// <returns></returns>
        public async Task<TreeResult<MenuTreeOutDto>> GetAllMenuTreeAsync(MenuEnum menu= MenuEnum.Menu)
        {
            return await _menuRepository.Entities.Where(o=>o.Type== menu).ToTreeResultAsync<MenuEntity, MenuTreeOutDto>(
              (p, c) =>
              {
                  return c.ParentId == null || c.ParentId == Guid.Empty;
              },
              (p, c) =>
              {
                  return p.Id == c.ParentId;
              },
              (p, children) =>
              {
                  if (p.children == null)
                      p.children = new List<MenuTreeOutDto>();
                  p.children.AddRange(children);
              }
              );
        }

        /// <summary>
        /// 得到菜单分页数据（不是树，只是普通表格）
        /// </summary>
        /// <param name="request">请求参数</param>
        /// <returns></returns>
        public async Task<IPagedResult<MenuOutPageListDto>> GetMenuPageAsync(PageRequest request)
        {
            request.NotNull(nameof(request));
            OrderCondition<MenuEntity>[] orderConditions = new OrderCondition<MenuEntity>[] { new OrderCondition<MenuEntity>(o => o.CreatedTime, SortDirection.Descending) };
            request.OrderConditions = orderConditions;
            return await _menuRepository.Entities.ToPageAsync<MenuEntity, MenuOutPageListDto>(request);
        }
    }
}