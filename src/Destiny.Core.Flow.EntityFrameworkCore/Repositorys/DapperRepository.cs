using Dapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.EntityFrameworkCore.Repositorys
{
    public class DapperRepository:IDapperRepository
    {

        private readonly IUnitOfWork _unitOfWork = null;
        private readonly IDbConnection _dbConnection = null;

        public DapperRepository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _dbConnection = _unitOfWork.GetDbContext().Database.GetDbConnection();
        }

        public Task<IEnumerable<T>> QueryAsync<T>(string sql, object param)
        {
            return _dbConnection.QueryAsync<T>(sql, param);
        }


    }
}