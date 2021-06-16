using Destiny.Core.Flow.AspNetCore.TestBase;
using DestinyCore.Enums;
using DestinyCore.Filter;
using DestinyCore.Helpers;
using DestinyCore.Ui;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Destiny.Core.AspNetMvc.Test
{


    public class AspNetMvcTestBase: AspNetMvcTestBase<Startup>
    {
        protected virtual async Task<TestResult<T>> GetResponseAsTestResultAsync<T>(string url, HttpStatusCode expectedStatusCode = HttpStatusCode.OK)
        {
            var strResponse = await GetResponseAsStringAsync(url, expectedStatusCode);
            return strResponse.FromJson<TestResult<T>>();
        }

    }




    public class TestResult<TRsult>: ResultBase<TRsult>, IHasResultType<AjaxResultType>
    {
        public TestResult() : this(null)
        {
        }

        public TestResult(AjaxResultType type = AjaxResultType.Success) : this("", default(TRsult), type)
        {
        }

        public TestResult(string message, AjaxResultType type = AjaxResultType.Success, TRsult data = default(TRsult)) : this(message, data, type)
        {
        }

        public TestResult(AjaxResultType type = AjaxResultType.Success, TRsult data = default(TRsult)) : this("", data, type)
        {
        }


        public TestResult(string message, TRsult data, AjaxResultType type)
        {
            this.Message = message;
            this.Data = data;
            this.Type = type;
            this.Success = Succeeded();
        }

        public TestResult(string message, bool success, TRsult data, AjaxResultType type)
        {
            this.Message = message;
            this.Data = data;
            this.Type = type;
            this.Success = success;

        }



        /// <summary>
        /// 返回类型
        /// </summary>

        public AjaxResultType Type { get; set; }

        /// <summary>
        /// 是否成功
        /// </summary>
        public bool Succeeded()
        {
            return Type == AjaxResultType.Success;
        }

        /// <summary>
        /// 是否错误
        /// </summary>
        public bool Error()
        {
            return Type == AjaxResultType.Error;
        }

        /// <summary>
        /// 转成对象
        /// </summary>
        /// <returns></returns>
        public object ToObject()
        {
            return new { Data, Message, Success, Type };
        }

        /// <summary>
        /// 转成JSON
        /// </summary>
        /// <returns></returns>
        public string ToJson()
        {
            return this.ToObject().ToJson();
        }


        public TRsult ToData()
        {
            return this.Data;
        }
    }
}
