using Destiny.Core.Flow.AspNetCore;
using Destiny.Core.Flow.AspNetCore.Extensions;
using Destiny.Core.Flow.AspNetCore.Ui;
using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.Exceptions;
using Destiny.Core.Flow.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Net;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.AspNetCore
{
    /// <summary>
    /// 
    /// </summary>
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
            //todo 实现方式不够好，待重写，2021-1-26 大黄瓜
            try
            {
                var ex = context.Features.Get<Microsoft.AspNetCore.Diagnostics.IExceptionHandlerFeature>()?.Error;

                await _next(context);
            }
            catch (SecurityTokenExpiredException ex)
            {
                _logger.LogError(new EventId(), ex, ex.Message);
                await catchFunc(context, AjaxResultType.Unauthorized, ex, "未经授权", (int)HttpStatusCode.Unauthorized);
            }
            catch (AppException ex)
            {
                _logger.LogError(new EventId(), ex, ex.Message);
                await catchFunc(context, AjaxResultType.Error, ex, string.Empty, (int)HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                _logger.LogError(new EventId(), ex, ex.Message);

                await catchFunc(context, AjaxResultType.Error, ex, "服务器出现异常，请联系管理员!!", (int)HttpStatusCode.InternalServerError);
            }
        }

        //todo 实现方式不够好，待重写，2021-1-26 大黄瓜
        private Func<HttpContext, AjaxResultType, Exception, string, int, Task> catchFunc = async (context, ajax, ex, msg, code) =>
        {
       
            if (context.Request.IsAjaxRequest() || context.Request.IsJsonContextType())
            {
                if (context.Response.HasStarted)
                {
                    return;
                }
                context.Response.StatusCode = code;
              
                context.Response.ContentType = "application/json; charset=utf-8";
                await context.Response.WriteAsync(new AjaxResult(msg.IsNullOrEmpty() ? ex.Message : msg, ajax).ToJson());
       
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
