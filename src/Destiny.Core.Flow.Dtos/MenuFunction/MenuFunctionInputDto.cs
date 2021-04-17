using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Mapping;
using Destiny.Core.Flow.Model.Entities.Menu;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Destiny.Core.Flow.Dtos.Menu
{

    /// <summary>
    /// 功能菜单输入DTO
    /// </summary>
    [DisplayName("功能菜单输入DTO")]
    public class MenuFunctionInputDto 
    {

        [DisplayName("菜单ID")]
        /// <summary>
        /// 菜单ID
        /// </summary>
        public Guid MenuId { get; set; }

        [DisplayName("功能ID集合")]
        /// <summary>
        /// 功能ID集合
        /// </summary>
        public Guid[] FunctionIds { get; set; }
    }
}