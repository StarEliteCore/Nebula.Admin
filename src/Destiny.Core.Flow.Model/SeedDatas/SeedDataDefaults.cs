using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Extensions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Destiny.Core.Flow.Model.SeedDatas
{
    /// <summary>
    /// 没有什么包一层解决不了的，有的话，就再一包层
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    /// <typeparam name="TKey"></typeparam>

    public abstract class SeedDataDefaults<TEntity, TKey> : SeedDataBase<TEntity, TKey>
             where TEntity : IEntity<TKey>
           where TKey : IEquatable<TKey>

    {
        protected SeedDataDefaults(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        protected override void SaveDatabase(TEntity[] entities)
        {
            if (entities == null || entities.Length == 0)
            {
                return;
            }
            _serviceProvider.CreateScoped(provider =>
            {
                var repository = provider.GetService<IEFCoreRepository<TEntity, TKey>>();
                var unitOfWork = provider.GetService<IUnitOfWork>();
                unitOfWork.BeginTransaction();
                foreach (var entitie in entities)
                {
                    if (repository.TrackEntities.Where(Expression(entitie)).Any())
                    {
                        continue;
                    }
                    repository.Insert(entities);
                }
                unitOfWork.Commit();
            });
        }
    }
}