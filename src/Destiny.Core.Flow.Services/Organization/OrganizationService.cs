using Destiny.Core.Flow.Dtos.Organization;
using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.Filter.Abstract;
using Destiny.Core.Flow.IServices.Organization;
using Destiny.Core.Flow.Model.Entities.Organizational;
using Destiny.Core.Flow.Repository.OrganizationRepository;
using Destiny.Core.Flow.Ui;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Services.Organization
{
    public class OrganizationService : IOrganizationService
    {
        private readonly IOrganizatedRepository _organizated;

        public OrganizationService(IOrganizatedRepository organizated)
        {
            _organizated = organizated;
        }

        public async Task<OperationResponse> CreateAsync(OrganizationInputDto input)
        {
            input.NotNull(nameof(input));
            //input.Id = Guid.NewGuid();
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

        public async Task<TreeResult<OrganizationOutDto>> GetOrganization()
        {
            var list = await _organizated.Entities.ToTreeResultAsync<OrganizatedEntity, OrganizationOutDto>((r, c) =>
            {
                return c.ParentId == null || c.ParentId == Guid.Empty;
            }, (r, c) =>
            {
                return r.Id == c.ParentId;
            }, (r, datalist) =>
            {
                if (r.children == null)
                {
                    r.children = new List<OrganizationOutDto>();
                }

                r.children.AddRange(datalist);
            });

            //var list= await _organizated.Query(x => x.IsDeleted == false).ToListAsync();
            //var model = new OrganizationOutDto()
            //{
            //    Id=Guid.Empty,
            //    title="根目录",
            //    expand = true,
            //};

            return list;
        }
        public async Task<IPagedResult<OrganizationOutPageListDto>> GetPageOrganizationAsync(PageRequest request)
        {
            request.NotNull(nameof(request));
            OrderCondition<OrganizatedEntity>[] orderConditions = new OrderCondition<OrganizatedEntity>[] { new OrderCondition<OrganizatedEntity>(o => o.CreatedTime, SortDirection.Descending) };
            request.OrderConditions = orderConditions;
            return await _organizated.Entities.ToPageAsync<OrganizatedEntity, OrganizationOutPageListDto>(request);
        }
        public async Task<OperationResponse<OrganizationOutputLoadDto>> LoadFormOrganizationAsync(Guid id)
        {
            var dto = (await _organizated.GetByIdAsync(id))?.MapTo<OrganizationOutputLoadDto>();
            return new OperationResponse<OrganizationOutputLoadDto>(MessageDefinitionType.LoadSucces, dto, OperationResponseType.Success);
        }
    }
}
