using Destiny.Core.Flow.Filter;
using Destiny.Core.Flow.Ui;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.AspNetCore.Ui
{
   public class TreeModel<TData> : ResultBase,IListResult<TData>  //这里到时候要统一
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
    }


    public class TreeModel : TreeModel<object> { 
    
     
    }
}
