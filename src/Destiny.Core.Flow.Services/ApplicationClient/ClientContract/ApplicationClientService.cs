using Destiny.Core.Flow.Dtos.Application;
using Destiny.Core.Flow.Exceptions;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.IServices;
using Destiny.Core.Flow.Model.DestinyIdentityServer4;
using Destiny.Core.Flow.Ui;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

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

            await _clientRepository.InsertAsync(input.MapTo<Client>(), async dto => MessageBox.ShowIf($"指定的客户端{input.ClientId}已存在", 
                await _clientRepository.Query(c => c.ClientId == input.ClientId || c.ClientName == input.ClientName).AnyAsync()));

            return new OperationResponse();
     
        }
    }
}
