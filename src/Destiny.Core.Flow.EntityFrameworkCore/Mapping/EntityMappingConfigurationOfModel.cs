using Destiny.Core.Flow.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Destiny.Core.Flow
{
    public abstract class EntityMappingConfiguration<TEntity, TKey> : IEntityMappingConfiguration<TEntity, TKey> where TEntity : class, IEntity<TKey>
        where TKey : IEquatable<TKey>
    {
        public virtual Type DbContextType => typeof(DefaultDbContext);

        public Type EntityType => typeof(TEntity);

        public void Map(ModelBuilder b)
        {
            Map(b.Entity<TEntity>());

            if (typeof(ISoftDelete).IsAssignableFrom(typeof(TEntity)))
            {
                b.Entity<TEntity>().HasQueryFilter(m => ((ISoftDelete)m).IsDeleted == false);
            }
        }

        public abstract void Map(EntityTypeBuilder<TEntity> b);
    }
}