using Destiny.Core.Flow.Entity;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace Destiny.Core.Flow.Extensions
{
    public static class EntityEntryExtensions
    {
        public static IEnumerable<EntityEntry> CheckInsert(this IEnumerable<EntityEntry> entitys, IPrincipal principal)
        {

            foreach (var item in entitys)
            {

            }
            return entitys;
        }
        public static EntityEntry CheckInsert(this EntityEntry entity, IPrincipal principal)
        {

            var entityPropertys = typeof(ICreationAudited<>).GetProperties();
            foreach (var item in entityPropertys)
            {
                var entityProperty = entity.GetType().GetProperties().Where(x => x.Name == item.Name).FirstOrDefault();
                if (entityProperty != null)
                {
                    //entityProperty.SetValue(entityProperty.Name,principal.Identity.GetUesrId<>)
                }
            }


            var creationAudited = entity.GetType().GetInterface(/*$"ICreationAudited`1"*/typeof(ICreationAudited<>).Name);
            if (creationAudited == null)
            {
                return entity;
            }
            entity.CheckICreatedTime(principal);
            return entity;
        }
        public static EntityEntry CheckICreatedTime(this EntityEntry entity, IPrincipal principal)
        {
            if (!(entity is ICreatedTime))
            {
                return entity;
            }
            ICreatedTime entity1 = (ICreatedTime)entity;
            entity1.CreatedTime = DateTime.Now;
            return (EntityEntry)entity1;
        }
    }
}
