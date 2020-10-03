using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Ui;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Data;
using System.Data.Common;
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
        public bool HasCommitted { get; private set; }

        /// <summary>
        /// 事务
        /// </summary>
        private DbTransaction _transaction;

        private bool _disposed;

        private readonly ILogger _logger = null;

        private DbConnection _connection = null;

        public UnitOfWork(TDbContext dbContext)
        {
            _dbContext = dbContext as DbContextBase;
        }

        /// <summary>
        /// 开启事务
        /// </summary>
        public virtual void BeginTransaction()
        {
            if (_transaction?.Connection == null)
            {
                if (_connection.State != ConnectionState.Open)
                {
                    _connection.Open();
                }
                _transaction = _connection.BeginTransaction();
            }

            _dbContext.Database.UseTransaction(_transaction);

            HasCommitted = false;
        }


        /// <summary>
        /// 开启事务 如果成功提交事务，失败回滚事务
        /// </summary>
        /// <param name="action">要执行的操作</param>
        /// <returns></returns>
        public void UseTran(Action action)
        {
            action.NotNull(nameof(action));
            if (HasCommitted)
            {
                return;
            }

            BeginTransaction();
            try
            {
                action?.Invoke();
                Commit();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                this.Rollback();
            }
        }

        public async Task UseTranAsync(Func<Task> func)
        {
            func.NotNull(nameof(func));
            if (HasCommitted)
            {
                return;
            }

            BeginTransaction();
            await func?.Invoke();
            Commit();
        }

        /// <summary>
        /// 开启事务 如果成功提交事务，失败回滚事务
        /// </summary>
        /// <param name="func"></param>
        /// <returns>返回操作结果</returns>
        public async Task<OperationResponse> UseTranAsync(Func<Task<OperationResponse>> func)
        {
            func.NotNull(nameof(func));
            OperationResponse result = new OperationResponse();
            if (HasCommitted)
            {
                result.Type = OperationResponseType.NoChanged;
                result.Message = "事务已提交!!";
                return result;
            }

            try
            {
                await this.BeginTransactionAsync();
                result = await func.Invoke();
                if (!result.Success)
                {
                    await this.RollbackAsync();
                    return result;
                }
                await this.CommitAsync();
            }
            catch (Exception ex)
            {
                await this.RollbackAsync();
                //_logger.LogError(ex.Message, ex);
                return new OperationResponse()
                {
                    Type = OperationResponseType.Error,
                    Message = ex.Message,
                };
            }
            return result;
        }

        /// <summary>
        /// 开启事务 如果成功提交事务，失败回滚事务
        /// </summary>
        /// <param name="func"></param>
        /// <returns>返回操作结果</returns>
        public OperationResponse UseTran(Func<OperationResponse> func)
        {
            func.NotNull(nameof(func));
            OperationResponse result = new OperationResponse();
            if (HasCommitted)
            {
                result.Type = OperationResponseType.NoChanged;
                result.Message = "事务已提交!!";
                return result;
            }
            try
            {
                this.BeginTransaction();
                result = func.Invoke();
                this.Commit();
                return result;
            }
            catch (Exception ex)
            {
                this.Rollback();
                _logger.LogError(ex.Message, ex);
                return new OperationResponse()
                {
                    Type = OperationResponseType.Error,
                    Message = ex.Message,
                };
            }
        }

        /// <summary>
        /// 开启事务异步
        /// </summary>
        public virtual async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (_transaction?.Connection == null)
            {
                if (_connection.State != ConnectionState.Open)
                {
                    await _connection.OpenAsync();
                }
                _transaction = _connection.BeginTransaction();
            }

            _dbContext.Database.UseTransaction(_transaction);

            HasCommitted = false;
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        public void Commit()
        {
            if (HasCommitted || _transaction == null)
            {
                return;
            }
            _transaction.Commit();
            _dbContext.Database.CurrentTransaction.Dispose();
            HasCommitted = true;
        }

        /// <summary>
        /// 异步提交事务
        /// </summary>
        /// <returns></returns>
        public async Task CommitAsync()
        {
            if (HasCommitted || _transaction == null)
            {
                return;
            }
            await _transaction.CommitAsync();
            await _dbContext.Database.CurrentTransaction.DisposeAsync();
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
            _disposed = true;
  
        }

        /// <summary>
        /// 回滚
        /// </summary>
        public void Rollback()
        {
            if (_transaction?.Connection != null)
            {
                _transaction.Rollback();
            }

            if (_dbContext.Database.CurrentTransaction != null)
            {
                _dbContext.Database.CurrentTransaction.Dispose();
            }
            HasCommitted = true;
        }

        /// <summary>
        /// 异步回滚
        /// </summary>
        /// <returns></returns>
        public async Task RollbackAsync()
        {
            if (_transaction?.Connection != null)
            {
                await _transaction.RollbackAsync();
            }

            if (_dbContext.Database.CurrentTransaction != null)
            {
                await _dbContext.Database.CurrentTransaction.DisposeAsync();
            }
            HasCommitted = true;
        }
    }
}