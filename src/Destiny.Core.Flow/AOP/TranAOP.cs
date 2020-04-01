using AspectCore.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.AOP
{
    /// <summary>
    /// AOP事务
    /// </summary>
    public class TranAOP : AbstractInterceptor
    {
        /// <summary>
        /// 实现
        /// </summary>
        /// <param name="context"></param>
        /// <param name="next"></param>
        /// <returns></returns>
        public override Task Invoke(AspectContext context, AspectDelegate next)
        {
            Console.WriteLine("23215121");
            return next(context);
        }
    }
}
