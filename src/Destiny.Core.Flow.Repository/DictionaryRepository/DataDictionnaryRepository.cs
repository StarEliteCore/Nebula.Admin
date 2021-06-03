using DestinyCore.Dependency;
using Destiny.Core.Flow.Model.Entities.Dictionary;
using Microsoft.Extensions.DependencyInjection;
using System;
using DestinyCore.EntityFrameworkCore;
using DestinyCore;

namespace Destiny.Core.Flow.Repository.DictionaryRepository
{
    [Dependency(ServiceLifetime.Scoped)]
    public class DataDictionnaryRepository : Repository<DataDictionaryEntity, Guid>, IDataDictionnaryRepository
    {
        public DataDictionnaryRepository(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }
    }

    public interface IDataDictionnaryRepository : IRepository<DataDictionaryEntity, Guid>
    {
    }
}