using System;
using System.Linq;
using System.Threading.Tasks;
using Destiny.Core.Flow.Dtos.IdentityServer4;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.IServices.IdentityServer4;
using Destiny.Core.Flow.Model.DestinyIdentityServer4;
using Destiny.Core.Flow.Ui;
using Microsoft.EntityFrameworkCore;
using Destiny.Core.Flow.Exceptions;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Destiny.Core.Flow.Dtos.Menu;
using Destiny.Core.Flow.IdentityServer.Entities;
using Destiny.Core.Flow.Filter.Abstract;
using Destiny.Core.Flow.Filter;

namespace Destiny.Core.Flow.Services.IdentityServer4
{
    /// <summary>
    /// API资源服务
    /// </summary>
    public class ApiResourceService : IApiResourceService
    {

        private readonly IRepository<ApiResource, Guid> _apiResourceRepository;


        public ApiResourceService(IRepository<ApiResource, Guid> apiResourceRepository)
        {

            this._apiResourceRepository = apiResourceRepository;
        }

        /// <summary>
        /// 异步创建Api资源
        /// </summary>
        /// <param name="dto">要传入DTO</param>
        /// <returns></returns>

        public async Task<OperationResponse> CreateApiResourceAsync(ApiResourceInputDto dto)
        {

            dto.NotNull(nameof(dto));
            //dto.ApiSecrets = new List<ApiResourceSecretDto>();
            //dto.ApiSecrets.Add(new ApiResourceSecretDto(dto.ApiSecretValue));
            return await _apiResourceRepository.InsertAsync(dto, async (dto1) =>
            {

                MessageBox.ShowIf($"指定【{dto.Name}】Api资源已存在", await this.CheckApiResourceIsExist(dto1.Id, dto1.Name));
            });
        }

        /// <summary>
        /// 检查是否存在
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private async Task<bool> CheckApiResourceIsExist(Guid Id, string name)
        {
            return (await _apiResourceRepository.GetAsync(m => !m.Id.Equals(Id) && m.Name == name)) != null;
        }

        /// <summary>
        /// 得到JwtClaimType类型集合
        /// </summary>
        /// <returns></returns>
        public OperationResponse GetJwtClaimTypeSelectItem()
        {

            Dictionary<string, object> dic = new Dictionary<string, object>();
            var type = typeof(JwtClaimTypes);
            var items = type.GetFields().Select(o => new SelectListItem { Text = o.Name, Value = o.GetValue(type)?.ToString() });


            SelectedItem<SelectListItem, string> selectedItem = new SelectedItem<SelectListItem, string>();
            selectedItem.ItemList = items.ToList();
            return OperationResponse.Ok("得到数据", selectedItem);

        }

        /// <summary>
        /// 异步加载Api资源数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public async Task<OperationResponse> LoadApiResourceDataAsync(Guid Id)
        {

            var apiResource = await _apiResourceRepository.Entities.Where(o => o.Id == Id).Include(O => O.Scopes).Include(O => O.UserClaims).FirstOrDefaultAsync();
            return OperationResponse.Ok("查询成功", MapTo(apiResource));

        }





        /// <summary>
        /// 异步得到Api资源分页
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public async Task<IPagedResult<ApiResourceOutputPageListDto>> GetApiResourcePageAsync(PageRequest request)
        {

            var pagedResult = await _apiResourceRepository.Entities.Include(s => s.Scopes).Include(u => u.UserClaims).ToPageAsync(request);
            var itemList = pagedResult.ItemList.Select(o => new ApiResourceOutputPageListDto
            {


                Id = o.Id,
                Name = o.Name,
                DisplayName = o.DisplayName,
                Description = o.Description,
                Enabled = o.Enabled,
                Scope = o.Scopes.Select(s => s.Scope).ToJoin(),
                UserClaim = o.UserClaims.Select(u => u.Type).ToJoin()
                //Scopes = o.Scopes.Select(s => s.Scope).ToList(),
                //UserClaims = o.UserClaims.Select(u => u.Type).ToList(),

            });
            return new PageResult<ApiResourceOutputPageListDto>
            {
                Total = pagedResult.Total,
                ItemList = itemList.ToList(),
                Message = pagedResult.Message,
                Success = pagedResult.Success,
                Type = pagedResult.Type
            };
        }


        private ApiResourceOutputDto MapTo(ApiResource apiResource)
        {

            var dto = new ApiResourceOutputDto();
            if (apiResource == null)
            {
                return dto;
            }
            dto.Id = apiResource.Id;
            dto.Name = apiResource.Name;
            dto.DisplayName = apiResource.DisplayName;
            dto.Description = apiResource.Description;
            dto.Enabled = apiResource.Enabled;
            dto.Scopes = apiResource.Scopes.Select(o => o.Scope).ToList();
            dto.UserClaims = apiResource.UserClaims.Select(o => o.Type).ToList();
            return dto;
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<OperationResponse> DeleteAsync(Guid id)
        {

            return _apiResourceRepository.DeleteAsync(id);
        }
    }
}