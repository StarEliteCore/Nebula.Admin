


using System;
using System.Collections.Generic;
using System.ComponentModel;
using DestinyCore.Entity;
using DestinyCore.Mapping;
using Destiny.Core.Flow.Entities;
using Destiny.Core.Flow.Model.Entities;

namespace Destiny.Core.Flow.Dtos
{

    /// <summary>
    /// 资源
    /// </summary>
    [AutoMapping(typeof(Asset))]
    public partial class AssetInputDto : InputDto<Guid>
    {
      

    }
}
