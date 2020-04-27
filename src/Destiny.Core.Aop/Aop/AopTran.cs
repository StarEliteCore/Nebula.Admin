using AspectCore.DependencyInjection;
using AspectCore.DynamicProxy;
using Destiny.Core.Flow.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Aop.Aop
{
    public class AopTran : AbstractInterceptor
    {
        //[FromServiceContext]
        private IUnitOfWork _unitOfWork { get; set; }
        public async override Task Invoke(AspectContext context, AspectDelegate next)
        {
            _unitOfWork = context.ServiceProvider.GetService(typeof(IUnitOfWork)) as IUnitOfWork;
            _unitOfWork.BeginTransaction();
            await next(context);
            _unitOfWork.Commit();
        }
    }
}
