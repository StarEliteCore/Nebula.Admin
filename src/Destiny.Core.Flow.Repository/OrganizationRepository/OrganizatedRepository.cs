using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Model.Entities.Organizational;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Destiny.Core.Flow.Repository.OrganizationRepository
{
    [Dependency(ServiceLifetime.Scoped)]
    public class OrganizatedRepository : Repository<OrganizatedEntity, Guid>, IOrganizatedRepository
    {
        public OrganizatedRepository(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }

    public interface IOrganizatedRepository : IEFCoreRepository<OrganizatedEntity, Guid>
    {
    }
}