using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Filter
{
    /// <summary>
    /// 树返回
    /// </summary>
    public class TreeResult<TData> : ResultBase<TData>
    {
        public TreeResult() : this(new TData[0], "成功返回数据", true)
        {

        }
        public TreeResult(IEnumerable<TData> data, string message = "成功返回数据", bool success = true)
        {
            Data = data;
            Message = message;
            Success = success;
        }


        //public TreeData<TData> ToTreeData()
        //{
        //    return new TreeData<TData>(Data, Message, Success);
        //}
    }
}
