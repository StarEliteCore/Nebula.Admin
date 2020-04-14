using Destiny.Core.Flow.Filter;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.AspNetCore.Ui
{
   public class TreeData<TData> : ResultBase<TData>  //这里到时候要统一
    {

        public TreeData() : this(new TData[0], "成功返回数据", true)
        {

        }
        public TreeData(IEnumerable<TData> data, string message = "成功返回数据", bool success = true)
        {
            Data = data;
            Message = message;
            Success = success;
        }
    }
}
