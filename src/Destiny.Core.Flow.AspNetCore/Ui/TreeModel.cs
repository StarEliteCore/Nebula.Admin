using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.Ui;
using System.Collections.Generic;

namespace Destiny.Core.Flow.AspNetCore.Ui
{
    public class TreeModel<TData> : ResultBase, IListResult<TData>, IHasResultType<AjaxResultType>  //这里到时候要统一
    {
        public TreeModel() : this(new TData[0], "成功返回数据", true)
        {
        }

        public TreeModel(IReadOnlyList<TData> itemList, string message = "成功返回数据", bool success = true)
        {
            ItemList = itemList;
            Message = message;
            Success = success;
        }

        public IReadOnlyList<TData> ItemList { get; set; }
        public AjaxResultType Type { get; set; }
    }

    public class TreeModel<TData, TSelectedType> : ResultBase, IListResult<TData>, IHasResultType<AjaxResultType>  //这里到时候要统一
    {
        public TreeModel() : this(new TData[0], new TSelectedType[0], "成功返回数据", true)
        {
        }

        public TreeModel(IReadOnlyList<TData> itemList, IReadOnlyList<TSelectedType> selectedList, string message = "成功返回数据", bool success = true)
        {
            ItemList = itemList;
            Message = message;
            Success = success;
            SelectedList = selectedList;
        }

        public IReadOnlyList<TData> ItemList { get; set; }

        public IReadOnlyList<TSelectedType> SelectedList { get; set; }
        public AjaxResultType Type { get; set; }
    }

    public class TreeModel : TreeModel<object>
    {
    }
}