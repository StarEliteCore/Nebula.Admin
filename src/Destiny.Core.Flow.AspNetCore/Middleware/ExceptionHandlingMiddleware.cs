using Destiny.Core.Flow.AspNetCore;
using Destiny.Core.Flow.AspNetCore.Extensions;
using Destiny.Core.Flow.AspNetCore.Ui;
using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.Exceptions;
using Destiny.Core.Flow.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
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
            catch (SecurityTokenExpiredException ex)
            {
                _logger.LogError(new EventId(), ex, ex.Message);
                await catchFunc(context, AjaxResultType.Unauthorized, ex, "未经授权", (int)HttpStatusCode.Unauthorized);
                //if (context.Request.IsAjaxRequest() || context.Request.IsJsonContextType())
                //{
                //    if (context.Response.HasStarted)
                //    {
                //        return;
                //    }
                //    context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                //    context.Response.Clear();
                //    context.Response.ContentType = "application/json; charset=utf-8";
                //    await context.Response.WriteAsync(new AjaxResult("未经授权", AjaxResultType.Unauthorized).ToJson());
                //    return;
                //}
                throw;
            }
            catch (AppException ex)
            {
                _logger.LogError(new EventId(), ex, ex.Message);
                await catchFunc(context, AjaxResultType.Error, ex, string.Empty, (int)HttpStatusCode.OK);
                //_logger.LogError(new EventId(), ex, ex.Message);
                //if (context.Request.IsAjaxRequest() || context.Request.IsJsonContextType())
                //{
                //    context.Response.StatusCode = (int)HttpStatusCode.OK;
                //    context.Response.Clear();
                //    context.Response.ContentType = "application/json; charset=utf-8";
                //    await context.Response.WriteAsync(new AjaxResult(ex.Message, AjaxResultType.Error).ToJson());
                //    return;
                //}
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(new EventId(), ex, ex.Message);
                await catchFunc(context, AjaxResultType.Error, ex, "服务器出现异常，请联系管理员!!", (int)HttpStatusCode.InternalServerError);
                throw;
            }
        }


        private Func<HttpContext, AjaxResultType, Exception, string, int, Task> catchFunc = async (context, ajax, ex, msg, code) =>
        {
       
            if (context.Request.IsAjaxRequest() || context.Request.IsJsonContextType())
            {
                if (context.Response.HasStarted)
                {
                    return;
                }
                context.Response.StatusCode = code;
                context.Response.Clear();
                context.Response.ContentType = "application/json; charset=utf-8";
                await context.Response.WriteAsync(new AjaxResult(msg.IsNullOrEmpty() ? ex.Message : msg, ajax).ToJson());
                return;
            }

        };
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
