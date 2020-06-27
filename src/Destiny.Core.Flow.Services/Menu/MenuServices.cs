using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Dtos;
using Destiny.Core.Flow.Dtos.Menu;
using Destiny.Core.Flow.EntityFrameworkCore;
using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.ExpressionUtil;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.IServices.IMenu;
using Destiny.Core.Flow.Model.Entities.Menu;
using Destiny.Core.Flow.Model.Entities.Rolemenu;
using Destiny.Core.Flow.Repository.MenuRepository;
using Destiny.Core.Flow.Ui;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Services.Menu
{
    [Dependency(ServiceLifetime.Scoped)]
    public class MenuServices : IMenuServices
    {
        private readonly IMenuRepository _menuRepository = null;
        private readonly IEFCoreRepository<RoleMenuEntity, Guid> _roleMenuRepository;
        private readonly IMenuFunctionRepository _menuFunction=null;
        private readonly IUnitOfWork _unitOfWork = null;
        public MenuServices(IMenuRepository menuRepository, IUnitOfWork unitOfWork, IEFCoreRepository<RoleMenuEntity, Guid> roleMenuRepository, IMenuFunctionRepository menuFunction)
        {
            _menuRepository = menuRepository;
            _roleMenuRepository = roleMenuRepository;
            this._menuFunction = menuFunction;
            _unitOfWork = unitOfWork;
        }

        public async Task<OperationResponse> CreateAsync(MenuInputDto input)
        {
            input.NotNull(nameof(input));
            return await _unitOfWork.UseTranAsync(async () =>
            {
                var result = await _menuRepository.InsertAsync(input);
                if(input.FunctionId?.Any()==true)
                {
                    int count= await _menuFunction.InsertAsync(input.FunctionId.Select(x => new MenuFunction
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
        /// 
        /// </summary>
        /// <param name="roleid">角色Id</param>
        /// <returns></returns>
        public async Task<TreeResult<MenuTreeOutDto>> GetMenuTreeAsync()
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
            return list;
        }

        //public async Task<OperationResponse> GetTreeSelectTreeDataAsync()
        //{
        //    OperationResponse response = new OperationResponse();
        //    var list=  await _menuRepository.Entities.ToListAsync();
        //    var permissionTreeItems = await GetMenuTreeAsync();


        //    response.IsSuccess("查询成功", new
        //    {
        //        TreeItemData = list,
        //        SelectTreeItems = permissionTreeItems
        //    });
        //    return response;
        //}
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
            return new OperationResponse<MenuOutputLoadDto>(MessageDefinitionType.LoadSucces, menudto,OperationResponseType.Success);
        }
        //public Task<TreeResult<MenuEntityItem>> GetMenuTreeAsync()
        //{
        //    return _menuRepository.Entities.ToTreeResultAsync<MenuEntity, MenuEntityItem>((r, c) =>
        //    {
        //        c.Key = c.Id.ToString();
        //        c.Title = c.Name;
        //        return c.ParentId == null || c.ParentId == Guid.Empty;
        //    }, (p, q) =>
        //    {
        //        p.Key = p.Id.ToString();
        //        p.Title = p.Name;
        //        return p.Id == q.ParentId;
        //    }, (p, q) =>
        //    {
        //        p.Children.AddRange(q);
        //    });
        //}

        ///// <summary>
        ///// 处理角色权限数据
        ///// </summary>
        ///// <param name="rolelist"></param>
        ///// <param name="list"></param>
        //private void IscheckTree(List<RoleMenuEntity> rolelist, IEnumerable<MenuTreeOutDto> list)
        //{
        //    foreach (var item in list)
        //    {
        //        var model = rolelist.Where(s => s.MenuId == item.Id).FirstOrDefault();
        //        if (model != null)
        //            item.@checked = true;
        //        IscheckTree( rolelist, item.children);
        //    }
        //}
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
    }


}