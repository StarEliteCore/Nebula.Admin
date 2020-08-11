using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Audit;

namespace Destiny.Core.Flow.AspNetCore.Mvc.Filters
{
    public class AuditLogFilter : IActionFilter, IResultFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
           
        }

        public void OnResultExecuted(ResultExecutedContext context)
        {
            IServiceProvider provider = context.HttpContext.RequestServices;
             var scope=provider.CreateScope();
             var dic= scope.ServiceProvider.GetService<DictionaryAccessor>();
               dic.TryGetValue("audit",out object auditEntry);
             var ddd= provider.GetService<IAuditStore>()?.Save((auditEntry as AuditEntry)).GetAwaiter().GetResult(); //不用异步，或则用异步IResultFilterAsync
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            
        }
    }
}
