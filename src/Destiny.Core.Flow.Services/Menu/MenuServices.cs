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
using Destiny.Core.Flow.Security.Identity;
using Destiny.Core.Flow.Ui;
using DnsClient.Internal;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Internal;
using Destiny.Core.Flow.Caching;

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
        private readonly Microsoft.Extensions.Logging.ILogger _logger = null;
        private readonly ICache _cache = null;
        private readonly AsyncLock _mutex = new AsyncLock();
        public MenuServices(IMenuRepository menuRepository, IUnitOfWork unitOfWork, IEFCoreRepository<RoleMenuEntity, Guid> roleMenuRepository, IMenuFunctionRepository menuFunction, IPrincipal principal, UserManager<User> userManager, RoleManager<Role> roleManager, IEFCoreRepository<UserRole, Guid> repositoryUserRole, Microsoft.Extensions.Logging.ILoggerFactory loggerFactory, ICache cache)
        {
            _menuRepository = menuRepository;
            _roleMenuRepository = roleMenuRepository;
            this._menuFunction = menuFunction;
            _unitOfWork = unitOfWork;
            _iIdentity = principal.Identity;
            _userManager = userManager;
            _roleManager = roleManager;
            _repositoryUserRole = repositoryUserRole;
            _logger = loggerFactory.CreateLogger<MenuServices>();
            _cache = cache;
        }

        public async Task<OperationResponse> CreateAsync(MenuInputDto input)
        {
            input.NotNull(nameof(input));


            return await _menuRepository.InsertAsync(input, null, async (dto, e) =>
            {

                
                return await SetDepthWithParentNumberWithSort(dto, e);

            });
        }

        private async Task<MenuEntity> SetDepthWithParentNumberWithSort(MenuInputDto dto, MenuEntity menuEntity)
        {
            if (menuEntity.ParentId == Guid.Empty) //最顶层
            {
                menuEntity.ParentNumber = string.Empty;
                menuEntity.Depth = 1;

            }
            else {
                var parentNumber = await
                   _menuRepository.Entities.Where(o => o.Id == dto.ParentId)
                   .Select(o => o.ParentNumber.IsNullOrEmpty() ? o.Id.ToString() : $"{o.ParentNumber.ToString()}.{o.Id.ToString()}").FirstOrDefaultAsync();
                menuEntity.ParentNumber = parentNumber;
                menuEntity.Depth = parentNumber.Split(".").Length + 1;
            }
            if (!dto.Sort.HasValue)
            {
                var maxSort = (await _menuRepository.Entities.Where(o => o.Depth == menuEntity.Depth).MaxAsync(o => (int?)o.Sort)) ?? 0;
                menuEntity.Sort = maxSort + 1;
            }

           
            return menuEntity;
        }



        public async Task<OperationResponse> DeleteAsync(Guid id)
        {
            return await _menuRepository.DeleteAsync(id);
        }

        public async Task<OperationResponse> UpdateAsync(MenuInputDto input)
        {
            input.NotNull(nameof(input));
            return await _menuRepository.UpdateAsync(input,null, async (dto, e) =>
            {


                return await SetDepthWithParentNumberWithSort(dto, e);

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

        private string vueRouterTreeKey = "vueDynamicRouter";
        /// <summary>
        /// 获取Vue动态路由菜单(应该返回Tree)
        /// </summary>
        /// <returns></returns>
        public async Task<OperationResponse> GetVueDynamicRouterTreeAsync()
        {

            using (await _mutex.LockAsync())
            {
                _logger.LogInformation("进入动态路由方法");
                var userId = _iIdentity.GetUesrId<Guid>();
                if (userId == Guid.Empty)
                {
                    return OperationResponse.Error("userId不存在");
                }

                var key = $"{vueRouterTreeKey}_{userId}";
                var treeList =  await _cache.GetAsync<IReadOnlyList<VueDynamicRouterTreeOutDto>>(key); //得到缓存

                if (treeList == null) //不在缓存
                {
                    int isAdmin = _iIdentity.FindFirst<int>(DestinyCoreFlowClaimTypes.IsAdmin);
                    var roleids = _repositoryUserRole.Entities.Where(x => x.UserId == userId).Select(x => x.RoleId);
                    var menuIds = _roleMenuRepository.Entities.Where(x => roleids.Contains(x.RoleId)).Select(o => o.MenuId);
                    Expression<Func<MenuEntity, bool>> expression = o => true;
                    if (isAdmin != 1) //不是系统，不是管理员
                    {
                        expression = o => menuIds.Contains(o.Id);
                    }
                    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
                    sw.Start();
                    var result = await _menuRepository.Entities.Where(expression).OrderBy(o => o.Sort).ToTreeResultAsync<MenuEntity, VueDynamicRouterTreeOutDto>((p, c) =>
                    {
                        return c.ParentId == null || c.ParentId == Guid.Empty;
                    },
                     (p, c) =>
                     {
                         return p.Id == c.ParentId;
                     },
                     (p, children) =>
                     {

                         if (p.Children == null)
                             p.Children = new List<VueDynamicRouterTreeOutDto>();
                         p.Children.AddRange(children.Where(x => x.Type == MenuEnum.Menu));
                         if (p.ButtonChildren == null)
                             p.ButtonChildren = new List<VueDynamicRouterTreeOutDto>();
                         p.ButtonChildren.AddRange(children.Where(x => x.Type != MenuEnum.Menu));
                     });
                    sw.Stop();

                    TimeSpan ts2 = sw.Elapsed;
                    _logger.LogInformation($"得到动态路由所有多少{ts2.TotalMilliseconds}毫秒");
                     await _cache.SetAsync<IReadOnlyList<VueDynamicRouterTreeOutDto>>(key, result.ItemList);
                    return OperationResponse.Ok(MessageDefinitionType.LoadSucces, result.ItemList);

                }
                else
                {
                    return OperationResponse.Ok(MessageDefinitionType.LoadSucces, treeList);
                
                }
           
            }
         
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
        public  Task<TreeResult<MenuTreeOutDto>> GetAllMenuTreeAsync(MenuEnum menu = MenuEnum.Menu)
        {
            return  _menuRepository.Entities.OrderBy(o => o.Sort).Where(o => o.Type == menu).ToTreeResultAsync<MenuEntity, MenuTreeOutDto>(
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
        public  Task<IPagedResult<MenuOutPageListDto>> GetMenuPageAsync(PageRequest request)
        {
            request.NotNull(nameof(request));
            OrderCondition<MenuEntity>[] orderConditions = new OrderCondition<MenuEntity>[] { new OrderCondition<MenuEntity>(o => o.Depth, SortDirection.Ascending), new OrderCondition<MenuEntity>(o => o.Sort, SortDirection.Ascending) };
            request.OrderConditions = orderConditions;
            return _menuRepository.Entities.ToPageAsync<MenuEntity, MenuOutPageListDto>(request);
        }
    }
}
