using Destiny.Core.Flow.Dtos.IdentityServer4;
using DestinyCore.Entity;
using DestinyCore.Exceptions;
using DestinyCore.Extensions;
using DestinyCore.Filter;
using DestinyCore.Filter.Abstract;
using Destiny.Core.Flow.IServices.IdentityServer4;
using Destiny.Core.Flow.Model.DestinyIdentityServer4;
using DestinyCore.Ui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DestinyCore;

namespace Destiny.Core.Flow.Services.IdentityServer4
{
    public class ApiScopeService : IApiScopeService
    {

        private readonly IRepository<ApiScope, Guid> _apiScopeRepository;


        public ApiScopeService(IRepository<ApiScope, Guid> apiScopeRepository)
        {
            _apiScopeRepository = apiScopeRepository;
        }


        /// <summary>
        /// 异步创建API范围
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>

        public Task<OperationResponse> CreateApiScopeAsync(ApiScopeDto dto)
        {
            dto.NotNull(nameof(dto));
            return _apiScopeRepository.InsertAsync(dto,async (dto1) =>
            {

                MessageBox.ShowIf($"指定【{dto.Name}】Api范围已存在", await this.CheckApiResourceIsExist(dto1.Id, dto1.Name));
            });
        }


        /// <summary>
        /// 检查是否存在
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        private async Task<bool> CheckApiResourceIsExist(Guid id, string name)
        {
            return (await _apiScopeRepository.GetAsync(m => !m.Id.Equals(id) && m.Name == name)) != null;
        }

        /// <summary>
        /// 异步得到API范围分页
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        public Task<IPagedResult<ApiScopeOutputPageListDto>> GetApiScopePageAsync(PageRequest request)
        {

            return _apiScopeRepository.Entities.ToPageAsync<ApiScope, ApiScopeOutputPageListDto>(request);
        }

        public Task<OperationResponse> DeleteAsync(Guid id)
        {

            return _apiScopeRepository.DeleteAsync(id);
        }
    }
}
