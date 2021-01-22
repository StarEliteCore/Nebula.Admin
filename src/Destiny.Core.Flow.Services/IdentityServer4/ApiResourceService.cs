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

               MessageBox.ShowIf("Api资源已存在", await this.CheckApiResourceIsExist(dto.Id, dto.Name));
               

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
    }
}