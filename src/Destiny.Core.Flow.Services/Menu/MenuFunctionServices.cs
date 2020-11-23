using Destiny.Core.Flow.Dtos.Menu;
using Destiny.Core.Flow.Dtos.MenuFunction;
using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.ExpressionUtil;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.Filter.Abstract;
using Destiny.Core.Flow.IServices.IMenu;
using Destiny.Core.Flow.Model.Entities.Function;
using Destiny.Core.Flow.Model.Entities.Menu;
using Destiny.Core.Flow.Repository.MenuRepository;
using Destiny.Core.Flow.Ui;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Services.Menu
{
    public class MenuFunctionServices : IMenuFunctionServices
    {
        private readonly IMenuFunctionRepository _menuFunctionRepository = null;
        private readonly IEFCoreRepository<Function, Guid> _functionRepository;
        private readonly IMenuRepository _menuRepository = null;
        private readonly IUnitOfWork _unitOfWork = null;


        public MenuFunctionServices(IMenuFunctionRepository menuFunctionRepository, IEFCoreRepository<Function, Guid> functionRepository, IMenuRepository menuRepository, IUnitOfWork unitOfWork)
        {
            _menuFunctionRepository = menuFunctionRepository;
            _functionRepository = functionRepository;
            _menuRepository = menuRepository;
            _unitOfWork = unitOfWork;
        }

        /// <summary>
        /// 根据菜单ID得到菜单功能分页
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>

        public  Task<IPagedResult<MenuFunctionOutPageListDto>> GetMenuFunctionByMenuIdPageAsync(MenuFunctionPageRequestDto request)
        {
            request.NotNull(nameof(request));

            var functionIds = _menuFunctionRepository.Entities.Where(o => o.MenuId == request.MenuId).Select(o => o.FunctionId);
      
            var exprrssion = FilterBuilder.GetExpression<Function>(request.Filter);
            exprrssion = exprrssion.And(o => functionIds.Contains(o.Id));
            return  _functionRepository.Entities.ToPageAsync(exprrssion, request, f => new MenuFunctionOutPageListDto()
            {

                FunctionId = f.Id,
                Name = f.Name,
                Description = f.Description,
                LinkUrl = f.LinkUrl,
                IsEnabled = f.IsEnabled,

            });
        }



        /// <summary>
        /// 批量添加功能菜单
        /// </summary>
        /// <param name="menuFunctionInputDto">输入DTO</param>
        /// <returns></returns>

        public async Task<OperationResponse> BatchAddMenuFunctionAsync(BatchAddMenuFunctionInputDto menuFunctionInputDto)
        {


       

           return await _unitOfWork.UseTranAsync(async () =>
            {
                List<MenuFunction> menuFunctions = new List<MenuFunction>();
                foreach (var menuId in menuFunctionInputDto.MenuIds)
                {
                    foreach (var functionId in menuFunctionInputDto.FunctionIds)
                    {
                        menuFunctions.Add(new MenuFunction() { MenuId = menuId, FunctionId = functionId });
                    }
                }

                var count = await _menuFunctionRepository.InsertAsync(menuFunctions.ToArray());
                if (count <= 0)
                {

                    return new OperationResponse(OperationResponseType.NoChanged.ToDescription(), OperationResponseType.NoChanged);
                }
                return OperationResponse.Ok($"{count}个菜单功能添加成功");
                
            });
         

        }

        //private MenuFunction[] ToMenuFunctions(MenuFunctionInputDto menuFunctionInputDto)
        //{
        //    menuFunctionInputDto.NotNull(nameof(menuFunctionInputDto));
        //    menuFunctionInputDto.FunctionIds.NotNull("FunctionIds");
        //    return menuFunctionInputDto.FunctionIds.Select(f => new MenuFunction
        //    {

        //        FunctionId = f,
        //        MenuId = menuFunctionInputDto.MenuId
        //    }).ToArray();
        //}

        /// <summary>
        /// 批量删除功能菜单
        /// </summary>
        /// <param name="menuFunctionInputDto">输入DTO</param>
        /// <returns></returns>
        public async Task<OperationResponse> BatchDeleteMenuFunctionAsync(MenuFunctionInputDto menuFunctionInputDto) {

            menuFunctionInputDto.NotNull(nameof(menuFunctionInputDto));

            menuFunctionInputDto.FunctionIds.NotNull("FunctionIds");
            var functionIds = menuFunctionInputDto.FunctionIds;
            var menuId= menuFunctionInputDto.MenuId;
            return await _unitOfWork.UseTranAsync(async () =>
            {
                var count = await _menuFunctionRepository.DeleteBatchAsync(o=>o.MenuId==menuId&& functionIds.Contains(o.FunctionId));
                if (count <= 0)
                {

                    return new OperationResponse(OperationResponseType.NoChanged.ToDescription(), OperationResponseType.NoChanged);
                }
                return OperationResponse.Ok($"{count}个菜单功能删除成功!!!!");

            });
        }
    }
}