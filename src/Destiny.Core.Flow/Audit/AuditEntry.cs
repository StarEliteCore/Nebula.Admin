using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Audit
{
    public class AuditEntry
    {
        public string TableName { get; set; }
        /// <summary>
        /// 修改前数据
        /// </summary>
        public Dictionary<string, object> OriginalValues { get; set; }
        /// <summary>
        /// 修改后数据
        /// </summary>
        public Dictionary<string, object> NewValues { get; set; }
        /// <summary>
        /// 主键
        /// </summary>
        public Dictionary<string, object> KeyValues { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        public DataOperationType OperationType { get; set; }

        public Dictionary<string, object> Properties { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public string UpdatedBy { get; set; }
    }
    public sealed class InternalAuditEntry : AuditEntry
    {
        private object _entityEntry;

        public List<PropertyEntry> TemporaryProperties { get; set; } = new List<PropertyEntry>();

        public InternalAuditEntry(EntityEntry entityEntry)
        {
            TableName = entityEntry.Metadata.GetTableName();
            KeyValues = new Dictionary<string, object>(4);
            Properties = new Dictionary<string, object>(16);

            //if (entityEntry.Properties.Any(x => x.IsTemporary))
            //{
            //    TemporaryProperties = new List<PropertyEntry>(4);
            //}

            if (entityEntry.State == EntityState.Added)
            {
                OperationType = DataOperationType.Add;
                NewValues = new Dictionary<string, object>();
            }
            else if (entityEntry.State == EntityState.Deleted)
            {
                OperationType = DataOperationType.Delete;
                OriginalValues = new Dictionary<string, object>();
            }
            else if (entityEntry.State == EntityState.Modified)
            {
                OperationType = DataOperationType.Update;
                OriginalValues = new Dictionary<string, object>();
                NewValues = new Dictionary<string, object>();
            }
            foreach (var propertyEntry in entityEntry.Properties)
            {
                //if (AuditConfig.AuditConfigOptions.PropertyFilters.Any(f => f.Invoke(entityEntry, propertyEntry) == false))
                //{
                //    continue;
                //}
                //if (propertyEntry.IsTemporary)
                //{
                TemporaryProperties.Add(propertyEntry);
                //continue;
                //}

                var columnName = propertyEntry.Metadata.GetColumnName();
                if (propertyEntry.Metadata.IsPrimaryKey())
                {
                    KeyValues[columnName] = propertyEntry.CurrentValue;
                }
                switch (entityEntry.State)
                {
                    case EntityState.Added:
                        NewValues[columnName] = propertyEntry.CurrentValue;
                        break;

                    case EntityState.Deleted:
                        OriginalValues[columnName] = propertyEntry.OriginalValue;
                        break;

                    case EntityState.Modified:
                        //if (propertyEntry.IsModified || AuditConfig.AuditConfigOptions.SaveUnModifiedProperties)
                        //if (propertyEntry.IsModified)
                        //{
                        OriginalValues[columnName] = propertyEntry.OriginalValue;
                        //NewValues[columnName] = propertyEntry.CurrentValue;//修改后数据
                        //}
                        break;
                }
            }
        }
    }
}
