using Destiny.Core.Flow.Ui.Abstracts;
using System.Collections.Generic;

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

    }


    public class TreeResult<TData, TSelectedType> : TreeResult<TData>, ITreeResult<TData, TSelectedType>
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

        public TreeResult(IReadOnlyList<TData> itemList, IReadOnlyList<TSelectedType> selectedList, string message = "成功返回数据", bool success = true)
        {
            ItemList = itemList;
            Message = message;
            Success = success;
            SelectedList = selectedList;
        }

        public IReadOnlyList<TSelectedType> SelectedList { get; set; }

    }
}
