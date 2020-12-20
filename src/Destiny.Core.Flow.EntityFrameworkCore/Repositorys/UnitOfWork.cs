using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Ui;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.EntityFrameworkCore
{
    ///https://docs.microsoft.com/zh-cn/ef/core/saving/transactions 共享连接和事务
    /// <summary>
    /// 工作单元
    /// </summary>
    public class UnitOfWork<TDbContext> : IUnitOfWork where TDbContext : DbContextBase
    {
        /// <summary>
        /// 释放时触发
        /// </summary>
        public Action OnDispose { get; set; }


        private readonly DbContextBase _dbContext = null;

        /// <summary>
        /// 是否提交
        /// </summary>
        /// <returns></returns>
        public bool HasCommit()
        {
            return HasCommitted;
        }

        /// <summary>
        /// 是否提交
        /// </summary>
        private bool HasCommitted { get;  set; }

        /// <summary>
        /// 事务
        /// </summary>
        private DbTransaction _transaction;

        private bool _disposed;

        //private readonly ILogger _logger = null;

        private DbConnection _connection = null;

        public UnitOfWork(TDbContext dbContext)
        {
            _dbContext = dbContext as DbContextBase;
        }


        private Stack<bool> _callStack = new Stack<bool>();

        /// <summary>
        /// 为了解决多接口使用事务问题
        /// </summary>

        public void Push()
        {
            _callStack.Push(true);
        }

        public void Pop()
        {
            if (_callStack.Any())
            {
                _callStack.Pop();
            }
        }




        public bool Enabled => _callStack.Count <= 0;

        /// <summary>
        /// 开启事务
        /// </summary>
        public virtual void BeginTransaction()
        {

            if (!Enabled)
            {
                return;
            }
  
            if (_transaction?.Connection == null)
            {
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }
                _transaction = _connection.BeginTransaction();
            }

            if (_dbContext.IsRelationalTransaction())
            {
                _dbContext.Database.UseTransaction(_transaction);
            }
            else
            {

                _dbContext.Database.BeginTransaction();
            }
          

            HasCommitted = false;
        }



        /// <summary>
        /// 开启事务异步
        /// </summary>
        public virtual async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {


            if (!Enabled)
            {
                return;
            }

            if (_transaction?.Connection == null)
            {
                if (_connection.State != ConnectionState.Open)
                {
                    await _connection.OpenAsync();
                }
                _transaction = _connection.BeginTransaction();
            }


            if (_dbContext.IsRelationalTransaction())
            {

                _dbContext.Database.UseTransaction(_transaction);
            }
            else {
                _dbContext.Database.BeginTransaction();


            }


            HasCommitted = false;
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        public void Commit()
        {
            if (!Enabled)
            {
                return;
            }

            if (HasCommitted || _transaction == null)
            {
                return;
            }
            _transaction.Commit();
            if (_dbContext.IsRelationalTransaction())
            {
                _dbContext.Database.CurrentTransaction.Dispose();
            }
            else {
                _dbContext.Database.CommitTransaction();
            }
       
            HasCommitted = true;
        }

        /// <summary>
        /// 异步提交事务
        /// </summary>
        /// <returns></returns>
        public async Task CommitAsync()
        {
            if (!Enabled)
            {
                return;
            }

            if (HasCommitted || _transaction == null)
            {
                return;
            }
            await _transaction.CommitAsync();

            if (_dbContext.IsRelationalTransaction())
            {
                await _dbContext.Database.CurrentTransaction.DisposeAsync();
            }
            else
            {
                _dbContext.Database.CommitTransaction();
            }
           
            HasCommitted = true;
        }

        /// <summary>
        /// 得到上下文
        /// </summary>
        /// <returns></returns>
        public DbContext GetDbContext()
        {
            _connection = _dbContext.Database.GetDbConnection();
            _dbContext.UnitOfWork = this;
            return _dbContext as DbContext;
        }

        /// <summary>
        /// 释放对象.
        /// </summary>
        public void Dispose()
        {
            if (_disposed)
            {
                return;
            }
            _transaction?.Dispose();
            _dbContext.Dispose();
            OnDispose?.Invoke();
            _callStack?.Clear();
            _disposed = true;
  
        }

        /// <summary>
        /// 回滚
        /// </summary>
        public void Rollback()
        {
            if (!Enabled)
            {
                return;
            }

            if (_transaction?.Connection != null)
            {
                _transaction.Rollback();
            }

            if (_dbContext.IsRelationalTransaction())
            {
                if (_dbContext.Database.CurrentTransaction != null)
                {
                    _dbContext.Database.CurrentTransaction.Dispose();
                }
            }
            else {
                _dbContext.Database.RollbackTransaction();
            }
            HasCommitted = true;
        }

        /// <summary>
        /// 异步回滚
        /// </summary>
        /// <returns></returns>
        public async Task RollbackAsync()
        {
            if (!Enabled)
            {
                return;
            }

            if (_transaction?.Connection != null)
            {
                await _transaction.RollbackAsync();
            }

            if (_dbContext.IsRelationalTransaction())
            {
                if (_dbContext.Database.CurrentTransaction != null)
                {
                    await _dbContext.Database.CurrentTransaction.DisposeAsync();
                }
            }
            else {
                _dbContext.Database.RollbackTransaction();
            }
        
            HasCommitted = true;
        }
    }
}