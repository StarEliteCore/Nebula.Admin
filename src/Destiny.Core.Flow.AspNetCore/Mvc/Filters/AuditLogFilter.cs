using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Destiny.Core.Flow.Dependency;
using Destiny.Core.Flow.Audit;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore.Internal;
using System.Linq;
using System.ComponentModel;
using Destiny.Core.Flow.Extensions;
using Microsoft.AspNetCore.Authorization;

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
            //var scope = provider.CreateScope();
            //var dic = scope.ServiceProvider.GetService<DictionaryAccessor>();
            var action = context.ActionDescriptor as ControllerActionDescriptor;
            if (action.EndpointMetadata.Any(x => x is AuditLogAttribute))
            {
                var actionname = action.MethodInfo.ToDescription();//获取控制器特性
                var dic = provider.GetService<DictionaryAccessor>();
                dic.TryGetValue("audit", out object auditEntry);
                if (auditEntry != null)
                {
                    AuditLog auditlog = new AuditLog();
                    auditlog.Ip =  "";
                    auditlog.Ip = context.HttpContext.GetClientIP();
                    auditlog.BrowserInformation= context.HttpContext.Request.Headers["User-Agent"].ToString();
                    auditlog.FunctionName =$"{context.Controller.GetType().ToDescription()}-{action.MethodInfo.ToDescription()}";
                    auditlog.Action = context.HttpContext.Request.Path;
                    provider.GetService<IAuditStore>()?.Save(auditlog, (auditEntry as List<AuditEntryInputDto>)).GetAwaiter().GetResult(); //不用异步，或则用异步IResultFilterAsync
                }
            }
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {

        }
    }
}
