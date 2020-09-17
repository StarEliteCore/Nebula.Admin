using System.Collections.Generic;

namespace Destiny.Core.Flow.Dtos.Menu
{
    public class SelectedItem<TData, TSelectedType>
    {
        public SelectedItem()
        {
            ItemList = new List<TData>();
        }

        public List<TData> ItemList { get; set; }
        public IEnumerable<TSelectedType> Selected { get; set; }
    }
}