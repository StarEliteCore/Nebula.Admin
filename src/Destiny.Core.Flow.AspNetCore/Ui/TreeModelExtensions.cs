using Destiny.Core.Flow.Ui.Abstracts;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.AspNetCore.Ui
{
  public static class TreeModelExtensions
    {

        public static TreeModel<TData> ToTreeModel<TData>(this ITreeResult<TData> result)
        {
            return new TreeModel<TData>(result.ItemList,result.Message,result.Success);
        }

    }
}
