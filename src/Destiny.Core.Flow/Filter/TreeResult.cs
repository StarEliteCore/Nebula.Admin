using Destiny.Core.Flow.Ui;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Filter
{
    /// <summary>
    /// 树返回
    /// </summary>
    public class TreeResult<TData> : ResultBase,IListResult<TData>
    {
        public TreeResult() : this(new TData[0], "成功返回数据", true)
        {

        }
        public TreeResult(IReadOnlyList<TData> itemList, string message = "成功返回数据", bool success = true)
        {
            ItemList = itemList;
            Message = message;
            Success = success;
        }

        public IReadOnlyList<TData> ItemList { get; set; }


        //public TreeData<TData> ToTreeData()
        //{
        //    return new TreeData<TData>(Data, Message, Success);
        //}
    }
}
