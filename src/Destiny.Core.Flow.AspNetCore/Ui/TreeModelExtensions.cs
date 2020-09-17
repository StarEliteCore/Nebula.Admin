using Destiny.Core.Flow.Ui.Abstracts;

namespace Destiny.Core.Flow.AspNetCore.Ui
{
    public static class TreeModelExtensions
    {
        public static TreeModel<TData> ToTreeModel<TData>(this ITreeResult<TData> result)
        {
            return new TreeModel<TData>(result.ItemList, result.Message, result.Success);
        }

        /// <summary>
        /// 待优化
        /// </summary>
        /// <typeparam name="TData"></typeparam>
        /// <typeparam name="TSelectedType"></typeparam>
        /// <param name="result"></param>
        /// <returns></returns>
        public static TreeModel<TData, TSelectedType> ToTreeModel<TData, TSelectedType>(this ITreeResult<TData, TSelectedType> result)
        {
            return new TreeModel<TData, TSelectedType>(result.ItemList, result.SelectedList, result.Message, result.Success);
        }
    }
}