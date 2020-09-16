using Destiny.Core.Flow.AspNetCore.Extensions;
using Destiny.Core.Flow.AspNetCore.Ui;
using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.Extensions;
using Destiny.Core.Flow.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;

namespace Destiny.Core.Flow.AspNetCore.Mvc.Filters
{
    public class HandleException : IExceptionFilter
    {
        private readonly ILogger<HandleException> _logger;

        public HandleException(ILogger<HandleException> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public void OnException(ExceptionContext context)
        {
            if (context.HttpContext.Request.IsAjaxRequest() || context.HttpContext.Request.IsJsonContextType())
            {
                context.ExceptionHandled = true;
                AjaxResult result = new AjaxResult();

                if (context.Exception is ValidationException validationException)
                {
                    var message = string.Join(",", validationException.Failures.Select(o => o.Message));
                    context.Result = new JsonResult(new AjaxResult(validationException.Message.IsNullOrWhiteSpace() ? message : validationException.Message, AjaxResultType.Error));
                }
            }
        }
    }
}