using AspectCore.DependencyInjection;
using AspectCore.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Aop.Aop
{
    public class AopTran : AbstractInterceptor
    {
        //[FromServiceContext]
        //private IUnitOfWork _unitOfWork { get; set; }
        public async override Task Invoke(AspectContext context, AspectDelegate next)
        {
            //_unitOfWork = context.ServiceProvider.GetService(typeof(IUnitOfWork)) as IUnitOfWork;
            //_unitOfWork.BeginTransaction();
            Console.WriteLine("方法执行前");
            await next(context);
            Console.WriteLine("方法执行后");
            //_unitOfWork.Commit();
        }
    }
}
