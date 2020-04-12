using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Dtos.Organization;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.IServices.Organization;
using Destiny.Core.Flow.Repository.OrganizationRepository;
using Destiny.Core.Flow.Ui;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Services.Organization
{
    [Dependency(ServiceLifetime.Scoped)]
    public class OrganizationService: IOrganizationService
    {
        private readonly IOrganizatedRepository _organizated;

        public OrganizationService(IOrganizatedRepository organizated)
        {
            _organizated = organizated;
        }
        public async Task<OperationResponse> CreateAsync(OrganizationInputDto input)
        {
            input.NotNull(nameof(input));
            return await _organizated.InsertAsync(input);
        }
        public async Task<OperationResponse> UpdateAsync(OrganizationInputDto input)
        {
            input.NotNull(nameof(input));
            return await _organizated.UpdateAsync(input);
        }
        public async Task<OperationResponse> DeleteAsync(Guid id)
        {
            return await _organizated.DeleteAsync(id);
        }
    }
}
