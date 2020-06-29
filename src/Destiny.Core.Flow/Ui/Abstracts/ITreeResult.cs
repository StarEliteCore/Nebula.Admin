using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Ui.Abstracts
{
    /// <summary>
    /// 接口树型结果
    /// </summary>
    /// <typeparam name="TData"></typeparam>
    public interface ITreeResult<TData>:IResultBase,IListResult<TData>
    {


       
    }


    public interface ITreeResult<TData, TSelectedType> : IResultBase, IListResult<TData>
    {
        IReadOnlyList<TSelectedType> SelectedList { get; set; }

    }



}
