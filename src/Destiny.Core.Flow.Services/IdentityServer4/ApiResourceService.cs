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
            return await _apiResourceRepository.InsertAsync(dto, async (dto) =>
            {
                MessageBox.ShowIf($"指定【{dto.Name}】Api资源已存在", await this.CheckApiResourceIsExist(dto.Id, dto.Name));
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
            return (await _apiResourceRepository.GetAsync(m => m.Id.Equals(Id) && m.Name == name)) != null;
        }

        /// <summary>
        /// 得到JwtClaimType类型集合
        /// </summary>
        /// <returns></returns>
        public OperationResponse GetJwtClaimTypeSelectItem()
        {

            Dictionary<string, object> dic = new Dictionary<string, object>();
            var type = typeof(JwtClaimTypes);
            var items = type.GetFields().Select(o=>new SelectListItem { Text=o.Name,Value=o.GetValue(type)?.ToString() });


            SelectedItem<SelectListItem, string> selectedItem = new SelectedItem<SelectListItem, string>();
            selectedItem.ItemList = items.ToList();
            return OperationResponse.Ok("得到数据", selectedItem);
            //for (int i = 0; i < fields.Length; i++)
            //{
            //    var field = fields[i];
            //    dic.Add(field.Name, field.GetValue(type));
            //}

        }

        /// <summary>
        /// 异步加载Api资源数据
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public  OperationResponse LoadApiResourceDataAsync(Guid Id)
        {

            return OperationResponse.Ok();
            
        }
    }
}