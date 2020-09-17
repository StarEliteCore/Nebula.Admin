using Dapper;
using Destiny.Core.Flow.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.EntityFrameworkCore.Repositorys
{
    public class DapperRepository : IDapperRepository
    {
        private readonly IUnitOfWork _unitOfWork = null;

        public DapperRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            DbConnection = _unitOfWork.GetDbContext().Database.GetDbConnection();
        }

        public IDbConnection DbConnection { get; set; }

        public Task<IEnumerable<T>> QueryAsync<T>(string sql, object param)
        {
            return DbConnection.QueryAsync<T>(sql, param);
        }
    }
}