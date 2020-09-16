using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Ui;
using System;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Application
{
    public interface ICrudServiceAsync<TEntity, TPrimaryKey>
            where TEntity : IEntity<TPrimaryKey>, IEquatable<TPrimaryKey>
    {
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="primaryKey"></param>
        /// <returns></returns>
        Task<OperationResponse> DeleteAsync(TPrimaryKey primaryKey);
    }
}