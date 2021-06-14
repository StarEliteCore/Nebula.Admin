using Destiny.Core.Flow.Dtos;
using Destiny.Core.Flow.IServices.Assets;
using Destiny.Core.Flow.Model.Entities;
using Destiny.Core.Flow.Shared.Application;
using DestinyCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Services
{

    public class AssetService : CrudServiceAsync<Guid, Asset, AssetInputDto, AssetOutputDto, AssetPageListDto>, IAssetService
    {
        public AssetService(IServiceProvider serviceProvider, IRepository<Asset, Guid> repository, ILoggerFactory loggerFactory) 
            : base(serviceProvider, repository, loggerFactory)
        {
        }
    }
}
