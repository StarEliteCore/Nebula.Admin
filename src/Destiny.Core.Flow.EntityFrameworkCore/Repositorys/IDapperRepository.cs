using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.EntityFrameworkCore.Repositorys
{
    public interface IDapperRepository
    {
        IDbConnection DbConnection { get; }

        Task<IEnumerable<T>> QueryAsync<T>(string sql, object param);
    }
}