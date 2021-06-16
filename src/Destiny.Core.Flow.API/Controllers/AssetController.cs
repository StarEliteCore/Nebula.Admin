using Destiny.Core.Flow.AspNetCore;
using Destiny.Core.Flow.Dtos;
using Destiny.Core.Flow.IServices.Assets;
using Destiny.Core.Flow.Model.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.API.Controllers
{
    [Description("资产控制器")]

    public class AssetController : CrudAdminControllerBase<IAssetService, Guid, Asset, AssetInputDto, AssetOutputDto, AssetPageListDto>
    {
        public AssetController(IAssetService crudServiceAsync) : base(crudServiceAsync)
        {
           
        }

        
    }
}
