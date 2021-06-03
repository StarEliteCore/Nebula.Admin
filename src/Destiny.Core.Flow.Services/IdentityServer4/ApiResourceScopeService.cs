using DestinyCore.Data.Dto;
using DestinyCore.Extensions;
using Destiny.Core.Flow.IServices.IdentityServer4;
using Destiny.Core.Flow.Model.DestinyIdentityServer4;
using DestinyCore.Ui;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DestinyCore;

namespace Destiny.Core.Flow.Services.IdentityServer4
{
    public class ApiResourceScopeService : IApiResourceScopeService
    {

        private readonly IRepository<ApiResourceScope, Guid> _apiResourceScopeRepository;

        public ApiResourceScopeService(IRepository<ApiResourceScope, Guid> apiResourceScopeRepository)
        {
            _apiResourceScopeRepository = apiResourceScopeRepository;
        }


        /// <summary>
        /// 异步得到API资源范围集合数据
        /// </summary>
        /// <returns></returns>
        public async Task<OperationResponse> GetApiResourceScopeListAsync()
        {

            var list = await _apiResourceScopeRepository.Entities.Select(o => new SelectItem { Value = o.Scope, Text = o.Scope, Key = o.Id.ToString() }).ToListAsync();
            return OperationResponse.Ok(list.DistinctBy(o=>o.Value));
        }
    }
}
