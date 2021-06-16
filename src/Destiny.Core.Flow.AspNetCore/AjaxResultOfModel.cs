using DestinyCore.AspNetCore;
using DestinyCore.Enums;
using DestinyCore.Extensions;
using DestinyCore.Filter;
using DestinyCore.Helpers;
using DestinyCore.Ui;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.AspNetCore
{
    public class AjaxResult<TData> : ResultBase<TData>, IHasResultType<AjaxResultType>
    {
        public AjaxResultType Type
        {
            get;
            set;
        }

        public AjaxResult()
        {
        }

        public AjaxResult(AjaxResultType type = AjaxResultType.Success)
            : this("", default(TData), type)
        {
        }

        public AjaxResult(string message, AjaxResultType type = AjaxResultType.Success,TData data= default(TData))
            : this(message, data, type)
        {
        }

        public AjaxResult(AjaxResultType type = AjaxResultType.Success, TData data= default(TData))
            : this("", data, type)
        {
        }

        public AjaxResult(string message, TData data, AjaxResultType type)
        {
            Message = message;
            Data = data;
            Type = type;
            Success = Succeeded();
        }

        public AjaxResult(string message, bool success, TData data, AjaxResultType type)
        {
            Message = message;
            Data = data;
            Type = type;
            Success = success;
        }

        public bool Succeeded()
        {
            return Type == AjaxResultType.Success;
        }

        public bool Error()
        {
            return Type == AjaxResultType.Error;
        }

        public object ToObject()
        {
            return new
            {
                Data,
                Message,
                Success,
                Type
            };
        }

        /// <summary>
        /// 只得到数据
        /// </summary>
        /// <returns></returns>
        public TData GetData()
        {
            return this.Data;
        }

        public string ToJson()
        {
            return ToObject().ToJson();
        }
    }


}
