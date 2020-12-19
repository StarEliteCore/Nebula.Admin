using Destiny.Core.Flow.Audit.Dto;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Destiny.Core.Flow.Audit.EntityHistory
{
    public class AuditHelper : IAuditHelper
    {
        public IEnumerable<AuditEntryDto> GetAuditEntity(IEnumerable<EntityEntry> entityEntries)
        {
            List<AuditEntryDto> auditEntries = new List<AuditEntryDto>();
            EntityState[] states = { EntityState.Added, EntityState.Modified, EntityState.Deleted };
             return entityEntries.Where(m => m.Entity != null && states.Contains(m.State) && m.GetType().IsDefined(typeof(DisableAuditingAttribute)) == false).ToArray().Select(o => this.CreateAuditEntity(o)).ToList();
            //foreach (var item in )
            //{
            //    auditEntries.Add(this.CreateAuditEntity(item));
            //}
            //return auditEntries;
        }

       /// <summary>
       /// 创建审计
       /// </summary>
       /// <param name="entityEntry"></param>
       /// <returns></returns>
        private AuditEntryDto CreateAuditEntity(EntityEntry entityEntry)
        {
            var entity = entityEntry.Entity;
            var type = entity.GetType();
            var displayName = type.ToDescription(); //得到实体上特性
            DataOperationType changeType= DataOperationType.Add;

            switch (entityEntry.State)
            {
                //case EntityState.Detached:
                //    changeType = DataOperationType.None;
                //    break;

                //case EntityState.Unchanged:
                //    changeType = DataOperationType.None;
                //    break;

                case EntityState.Deleted:
                    changeType = DataOperationType.Delete;
                    break;

                case EntityState.Modified:
                    changeType = DataOperationType.Update;
                    break;

                case EntityState.Added:
                    changeType = DataOperationType.Add;
                    break;

            }
            AuditEntryDto audit = new AuditEntryDto();
            audit.KeyValues = new Dictionary<string, object>();
            audit.EntityName = type.FullName;
            audit.DisplayName = displayName;
            audit.TypeName = type.FullName;
            audit.OperationType = changeType;
            audit.AuditPropertys = GetAuditPropertys(entityEntry);
            audit.KeyValues = new Dictionary<string, object>() {
                { "Id",GetEntityKey(entity)}
            };
            return audit;
        }

        /// <summary>
        /// 得到实体主键 
        /// </summary>
        /// <param name="entityAsObj"></param>
        /// <returns></returns>
        private string GetEntityKey(object entityAsObj)
        {
            return entityAsObj
                .GetType().GetProperty("Id")?
                .GetValue(entityAsObj)?
                .ToJson();
        }

        /// <summary>
        /// 得到审计属性
        /// </summary>
        /// <param name="entityEntry"></param>
        /// <returns></returns>
        private List<AuditPropertyDto> GetAuditPropertys(EntityEntry entityEntry)
        {
            List<AuditPropertyDto> propertyDtos = new List<AuditPropertyDto>();

            foreach (var propertie in entityEntry.CurrentValues.Properties.Where(p => !p.IsConcurrencyToken && p.PropertyInfo.GetCustomAttribute<DisableAuditingAttribute>() == null))
            {
                var propertyEntry = entityEntry.Property(propertie.Name);//获取字段名
                AuditPropertyDto propertyDto = new AuditPropertyDto();
                propertyDto.PropertyName = propertie.Name;
                propertyDto.PropertyDisplayName = propertyEntry.Metadata.PropertyInfo.ToDescription();
                propertyDto.PropertyType = propertie.ClrType.FullName;
                if (propertie.IsPrimaryKey())
                {
                    continue;
                }
                if (entityEntry.State == EntityState.Added)
                {
                    var currentValue = propertyEntry.CurrentValue?.ToString();
                    propertyDto.NewValues = currentValue;
                    propertyDtos.Add(propertyDto);
                }
                else if (entityEntry.State == EntityState.Modified)
                {
                    var originalValue = propertyEntry.OriginalValue?.ToString();
                    var currentValue = propertyEntry.CurrentValue?.ToString();
                    if (currentValue != originalValue)
                    {
                        propertyDto.NewValues = currentValue;

                        propertyDto.OriginalValues = originalValue;
                        propertyDtos.Add(propertyDto);
                    }


                }
                else if (entityEntry.State == EntityState.Deleted)
                {

                    var originalValue = propertyEntry.OriginalValue?.ToString();
                    propertyDto.OriginalValues = originalValue;
                    propertyDtos.Add(propertyDto);
                }
       
              
            }

            return propertyDtos;
            //return entityEntry.Metadata.GetProperties().Where(p => !p.IsConcurrencyToken && p.PropertyInfo.GetCustomAttribute<DisableAuditingAttribute>() == null).Select(p =>
            //{
            //    var propertyEntry = entityEntry.Property(p.Name);//获取字段名
            //    AuditPropertyDto propertyDto = new AuditPropertyDto();
            //    propertyDto.PropertyName = p.Name;
            //    propertyDto.PropertyDisplayName = propertyEntry.Metadata.PropertyInfo.ToDescription();
            //    propertyDto.PropertyType = p.ClrType.FullName;
            //    var currentValue = propertyEntry.CurrentValue?.ToString();
            //    var originalValue = propertyEntry.OriginalValue?.ToString();
            //    propertyDto.NewValues = currentValue;
            //    propertyDto.OriginalValues = originalValue;
            //    return propertyDto;

            //}).ToList();


        }

    }
}
