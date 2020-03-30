using Destiny.Core.Flow.Ui;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.AspNetCore.Ui
{
    public class PageListDto<T> : ResultBase
    {

        public PageListDto() : this(new T[0], 0, "请求成功", true)
        {

        }
        public PageListDto(IEnumerable<T> data, int total, string message = "请求成功", bool success = true)
        {
            Data = data;
            Total = total;
            Success = success;
            this.Message = message;
        }


        public IEnumerable<T> Data { get; set; }

        public int Total { get; set; }


    }

    public class PageListDto : PageListDto<dynamic>
    {

    }
}
