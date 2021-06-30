using DestinyCore.Enums;
using DestinyCore.Ui;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.AspNetCore
{
    /// <summary>
    /// 返回结果用来统一
    /// </summary>
    public class ApiResult : JsonResult
    {
        public ApiResult() : base(null)
        {


        }

        public ApiResult(OperationResponse operationResponse) : base(null)
        {

            this.Message = operationResponse.Message;
            this.Data = operationResponse.Data;
            this.Success = operationResponse.Success;
            this.Type = ToAjaxResultType(operationResponse.Type);
        }


        public ApiResult(string message, bool success, object data, StatusType type) : base(null)
        {
            this.Message = message;
            this.Success = success;
            this.Data = data;
            this.Type = type;
        }


        public string Message { get; set; }

        public object Data { get; set; }

        public bool Success { get; set; }

        public StatusType Type { get; set; }


        public override Task ExecuteResultAsync(ActionContext context)
        {
            base.Value = new
            {
                this.Message,
                this.Data,
                this.Success,
                this.Type

            };
            return base.ExecuteResultAsync(context);
        }


        private StatusType ToAjaxResultType(OperationResponseType responseType)
        {
            return responseType switch
            {
                OperationResponseType.Success => StatusType.Success,
                OperationResponseType.NoChanged => StatusType.Info,
                _ => StatusType.Error,
            };
        }

    }



}

public enum StatusType
{

    /// <summary>
    /// 消息结果
    /// </summary>
    [Description("消息结果")]

    Info = 203,

    /// <summary>
    /// 成功
    /// </summary>
    [Description("成功")]
    Success = 200,

    /// <summary>
    /// 错误
    /// </summary>
    [Description("错误")]
    Error = 500,

    /// <summary>
    /// 未经授权
    /// </summary>
    [Description("未经授权")]
    Unauthorized = 401,

    /// <summary>
    /// 已登录但权限不足
    /// </summary>
    [Description("当前用户权限不足")]
    Uncertified = 403,

    /// <summary>
    /// 功能资源找不到
    /// </summary>
    [Description("当前功能资源找不到")]
    NoFound = 404
}
