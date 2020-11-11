using Destiny.Core.Flow.Extensions;
using System;
using System.Security.Principal;

namespace Destiny.Core.Flow.Entity
{

    public static class IEntityExtensions
    {

        public static TEntity[] CheckInsert<TEntity, TPrimaryKey>(this TEntity[] entitys, IPrincipal principal)
            where TEntity : class, IEntity<TPrimaryKey>
            where TPrimaryKey : IEquatable<TPrimaryKey>
        {

            for (int i = 0; i < entitys.Length; i++)
            {
                var entity = entitys[i];
                entitys[i] = entity.CheckInsert<TEntity, TPrimaryKey>(principal);
            }
            return entitys;
        }


        public static TEntity CheckInsert<TEntity, TPrimaryKey>(this TEntity entity, IPrincipal principal)
           where TEntity : class, IEntity<TPrimaryKey>
            where TPrimaryKey : IEquatable<TPrimaryKey>
        {

            entity = entity.CheckICreatedTime<TEntity, TPrimaryKey>();

            var creationAudited = entity.GetType().GetInterface(/*$"ICreationAudited`1"*/typeof(ICreationAudited<>).Name);
            if (creationAudited == null)
            {
                return entity;
            }

            var typeArguments = creationAudited?.GenericTypeArguments[0];
            var fullName = typeArguments?.FullName;
            if (fullName == typeof(Guid).FullName)
            {
                entity = entity.CheckICreationAudited<TEntity, Guid>(principal);

            }

            return entity;

        }


        public static TEntity CheckICreatedTime<TEntity, TPrimaryKey>(this TEntity entity)
                 where TEntity : class, IEntity<TPrimaryKey>
                  where TPrimaryKey : IEquatable<TPrimaryKey>
        {
            if (!(entity is ICreatedTime))
            {
                return entity;
            }
            ICreatedTime entity1 = (ICreatedTime)entity;

            entity1.CreatedTime = DateTime.Now;
            return (TEntity)entity1;
        }


        public static TEntity CheckICreationAudited<TEntity, TUserKey>(this TEntity entity, IPrincipal principal)

         where TUserKey : struct, IEquatable<TUserKey>
        {
            if (!entity.GetType().IsBaseOn(typeof(ICreationAudited<>)))
            {
                return entity;
            }

            ICreationAudited<TUserKey> entity1 = (ICreationAudited<TUserKey>)entity;
            entity1.CreatorUserId = principal?.Identity.GetUesrId<TUserKey>();
            entity1.CreatedTime = DateTime.Now;
            return (TEntity)entity1;
        }

        public static TEntity CheckIModificationAudited<TEntity, TUserKey>(this TEntity entity, IPrincipal principal)

         where TUserKey : struct, IEquatable<TUserKey>
        {
            if (!entity.GetType().IsBaseOn(typeof(IModificationAudited<>)))
            {
                return entity;
            }

            IModificationAudited<TUserKey> entity1 = (IModificationAudited<TUserKey>)entity;
            entity1.LastModifierUserId = principal?.Identity?.GetUesrId<TUserKey>();
            entity1.LastModifionTime = DateTime.Now;
            return (TEntity)entity1;
        }
    }
}
