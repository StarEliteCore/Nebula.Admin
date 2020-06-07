using Destiny.Core.Flow.Ui;
using Destiny.Core.Flow.Ui.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Ui
{
    /// <summary>
    /// 树返回
    /// </summary>
    public class TreeResult<TData> : ResultBase, ITreeResult<TData>
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
