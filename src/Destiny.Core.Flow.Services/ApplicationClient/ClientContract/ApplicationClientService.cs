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

        public async Task<OperationResponse> CreatAsync(ClientAddInputDto input)
        {
            input.NotNull(nameof(input));
            var entity = input.MapTo<Client>();
            return await _clientRepository.InsertAsync(entity, async f =>
            {
                bool isExist = await _clientRepository.Entities.Where(x => x.ClientId == input.ClientId).AnyAsync();
                if (isExist)
                    throw new AppException("此功能已存在!!!");
            });
        }
    }
}
