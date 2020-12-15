using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.EntityFrameworkCore;
using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Ui;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
namespace Destiny.Core.Flow.Entity
{
    /// <summary>
    /// 工作单元扩展
    /// </summary>
   public static  class UnitOfWorkExtensions
    {
        /// <summary>
        /// 添加工作单元
        /// </summary>
        /// <typeparam name="TIUnitOfWork"></typeparam>
        /// <typeparam name="UnitOfWork"></typeparam>
        /// <param name="services"></param>
        /// <param name="lifetime"></param>
        /// <returns></returns>
        public static IServiceCollection AddUnitOfWork<TDbContext>(this IServiceCollection services, ServiceLifetime lifetime= ServiceLifetime.Scoped) 
              where TDbContext : DbContextBase
        {

            ServiceDescriptor serviceDescriptor = new ServiceDescriptor(typeof(IUnitOfWork), typeof(UnitOfWork<TDbContext>),lifetime);
            services.Add(serviceDescriptor);
            return services;
        }



        /// <summary>
        /// 开启事务 如果成功提交事务，失败回滚事务
        /// </summary>
        /// <param name="action">要执行的操作</param>
        /// <returns></returns>
        public static void UseTran(this IUnitOfWork unitOfWork, Action action)
        {
            action.NotNull(nameof(action));
            if (unitOfWork.HasCommit())
            {
                return;
            }

            unitOfWork.BeginTransaction();
            try
            {
                action?.Invoke();
                unitOfWork.Commit();
            }
            catch (Exception ex)
            {

                unitOfWork.Rollback();
                LogError(ex);
            }
        }

        public static async Task UseTranAsync(this IUnitOfWork unitOfWork, Func<Task> func)
        {
            func.NotNull(nameof(func));
            if (unitOfWork.HasCommit())
            {
                return;
            }

            unitOfWork.BeginTransaction();
            await func?.Invoke();
            unitOfWork.Commit();
        }

        /// <summary>
        /// 开启事务 如果成功提交事务，失败回滚事务
        /// </summary>
        /// <param name="func"></param>
        /// <returns>返回操作结果</returns>
        public static async Task<OperationResponse> UseTranAsync(this IUnitOfWork unitOfWork, Func<Task<OperationResponse>> func)
        {
            func.NotNull(nameof(func));
            OperationResponse result = new OperationResponse();
            if (unitOfWork.HasCommit())
            {
                result.Type = OperationResponseType.NoChanged;
                result.Message = "事务已提交!!";
                return result;
            }

            try
            {
                await unitOfWork.BeginTransactionAsync();
                result = await func.Invoke();
                if (!result.Success)
                {
                    await unitOfWork.RollbackAsync();
                    return result;
                }
                await unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
         
                await unitOfWork.RollbackAsync();
                LogError(ex);
                return new OperationResponse()
                {
                    Type = OperationResponseType.Error,
                    Message = ex.Message,
                };
            }
            return result;
        }

        private static void LogError(Exception exception)
        {
            IocManage.Instance.GetLogger<IUnitOfWork>()?.LogError(exception.Message, exception);
        }

        /// <summary>
        /// 开启事务 如果成功提交事务，失败回滚事务
        /// </summary>
        /// <param name="func"></param>
        /// <returns>返回操作结果</returns>
        public static OperationResponse UseTran(this IUnitOfWork unitOfWork, Func<OperationResponse> func)
        {
            func.NotNull(nameof(func));
            OperationResponse result = new OperationResponse();
            if (unitOfWork.HasCommit())
            {
                result.Type = OperationResponseType.NoChanged;
                result.Message = "事务已提交!!";
                return result;
            }
            try
            {
                unitOfWork.BeginTransaction();
                result = func.Invoke();
                unitOfWork.Commit();
                return result;
            }
            catch (Exception ex)
            {
         
                unitOfWork.Rollback();
                LogError(ex);
                return new OperationResponse()
                {
                    Type = OperationResponseType.Error,
                    Message = ex.Message,
                };
            }
        }
    }
}
