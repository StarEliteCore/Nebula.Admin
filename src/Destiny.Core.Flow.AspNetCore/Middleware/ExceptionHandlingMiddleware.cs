using Destiny.Core.Flow.AspNetCore.Extensions;
using Destiny.Core.Flow.AspNetCore.Ui;
using Destiny.Core.Flow.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

using System;
using System.Net;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.AspNetCore
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<ExceptionHandlingMiddleware>();
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(new EventId(), ex, ex.Message);
                if (context.Request.IsAjaxRequest() || context.Request.IsJsonContextType())
                {
                    if (context.Response.HasStarted)
                    {
                        return;
                    }
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError; context.Response.Clear();
                    context.Response.ContentType = "application/json; charset=utf-8";
                    await context.Response.WriteAsync(new AjaxResult(ex.Message, AjaxResultType.Error).ToJson());
                    return;
                }
                throw;
            }
        }
    }

    public static class ErrorHandlingExtensions
    {
        /// <summary>
        /// 异常中间件
        /// </summary>
        /// <param name="builder"></param>
        /// <returns></returns>

        public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}