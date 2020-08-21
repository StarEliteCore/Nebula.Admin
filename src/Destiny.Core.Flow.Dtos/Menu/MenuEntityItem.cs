using Destiny.Core.Flow.Mapping;
using Destiny.Core.Flow.Model.Entities.Menu;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Dtos
{
    [AutoMapping(typeof(MenuEntity))]
    public class MenuEntityItem : MenuEntity
    {

        public MenuEntityItem()
        {

            Children = new List<MenuEntityItem>();
         
        }

        public string Key { get; set; }

        public string Title { get; set; }
        public virtual IList<MenuEntityItem> Children { get; set; }
    }
}
