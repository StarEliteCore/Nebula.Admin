using Destiny.Core.Flow.Dtos.IdentityServer4.ClientApplication;
using Destiny.Core.Flow.Dtos.Menu;
using DestinyCore.Exceptions;
using DestinyCore.Extensions;
using DestinyCore.Filter;
using DestinyCore.Filter.Abstract;
using Destiny.Core.Flow.IServices;
using Destiny.Core.Flow.Model.DestinyIdentityServer4;
using DestinyCore.Ui;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using DestinyCore;

namespace Destiny.Core.Flow.Services
{
    public class ApplicationClientService : IApplicationClientService
    {
        private readonly IRepository<Client, Guid> _clientRepository;

        public ApplicationClientService(IRepository<Client, Guid> clientRepository)
        {
            _clientRepository = clientRepository;
        }

        public async Task<OperationResponse> CreateAsync(ClientAddInputDto input)
        {
            input.NotNull(nameof(input));
            if (input.ClientSecrets != null)
            {
                input.ClientSecrets.ForEach(x =>
                {
                    x.Value = x.Value.Sha256();
                });
            }
            return await _clientRepository.InsertAsync(input.MapTo<Client>(), async f =>
            {

                bool isExist = await _clientRepository.Query(c => c.ClientId == input.ClientId || c.ClientName == input.ClientName).AnyAsync();
                if (isExist)
                {
                    throw new AppException($"指定的客户端{input.ClientId}已存在");
                }
            });
        }
        public async Task<IPagedResult<ClientOutputPageListDto>> GetPageAsync(PageRequest request)
        {
            var pagedResult = await _clientRepository.Entities.Include(x => x.AllowedCorsOrigins)
                .Include(x => x.AllowedGrantTypes)
                .Include(x => x.AllowedScopes)//退出登录回调的url
                .Include(x => x.Claims)
                .Include(x => x.ClientSecrets)
                .Include(x => x.IdentityProviderRestrictions)
                .Include(x => x.PostLogoutRedirectUris)
                .Include(x => x.Properties)
                .Include(x => x.RedirectUris).ToPageAsync(request);
            var itemList = pagedResult.ItemList.Select(o => new ClientOutputPageListDto
            {
                Id = o.Id,
                ClientId = o.ClientId,
                ClientName = o.ClientName,
                Enabled = o.Enabled,
                ProtocolType = o.ProtocolType,
                AllowAccessTokensViaBrowser = o.AllowAccessTokensViaBrowser,
                AllowedGrantTypes = o.AllowedGrantTypes.Select(x => x.GrantType).ToList(),
                ClientSecrets = o.ClientSecrets.Select(u => new Secret() { Type = u.Type, Value = u.Value }).ToList(),
                RedirectUris = o.RedirectUris.Select(x => x.RedirectUri).ToList(),
                PostLogoutRedirectUris = o.PostLogoutRedirectUris.Select(x => x.PostLogoutRedirectUri).ToList(),
                AllowedCorsOrigins = o.AllowedCorsOrigins.Select(x => x.Origin).ToList(),
                AllowedScopes = o.AllowedScopes.Select(x => x.Scope).ToList(),
            });
            return new PageResult<ClientOutputPageListDto>
            {
                Total = pagedResult.Total,
                ItemList = itemList.ToList(),
                Message = pagedResult.Message,
                Success = pagedResult.Success,
                Type = pagedResult.Type
            };
        }
        public async Task<OperationResponse> DeleteAsync(Guid id)
        {
            return await _clientRepository.DeleteAsync(id);
        }
        /// <summary>
        /// 获取授权类型
        /// </summary>
        /// <returns></returns>
        public OperationResponse GetGrantTypeSelectItem()
        {
            var type = typeof(GrantType);
            var items = type.GetFields().Select(o => new SelectListItem { Text = o.Name, Value = o.GetValue(type)?.ToString() });
            SelectedItem<SelectListItem, string> selectedItem = new SelectedItem<SelectListItem, string>();
            selectedItem.ItemList = items.ToList();
            return OperationResponse.Ok("得到数据", selectedItem);
        }
    }
}
