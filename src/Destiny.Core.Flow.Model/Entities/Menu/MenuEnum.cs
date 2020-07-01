using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Destiny.Core.Flow.Model.Entities.Menu
{
    /// <summary>
    /// 菜单类型枚举
    /// </summary>
    public enum MenuEnum
    {
        [Description("菜单")]
        Menu=0,
        [Description("按钮")]
        Button=5,
    }
}
