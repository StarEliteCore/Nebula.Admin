using System;
using System.Collections.Generic;
using System.ComponentModel;
using DestinyCore.Entity;
using Destiny.Core.Flow.Entities;
using DestinyCore.Mapping;
using Destiny.Core.Flow.Model.Entities;

namespace Destiny.Core.Flow.Dtos
{

    [AutoMapping(typeof(Asset))]
    public partial class AssetOutputDto : OutputDto<Guid>
    {
       

    }

}
