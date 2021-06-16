using Destiny.Core.Flow.Dtos;
using Destiny.Core.Flow.Model.Entities;
using Destiny.Core.Flow.Shared.Abstractions;
using DestinyCore.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.IServices.Assets
{
    /// <summary>
    /// 资源服务接口
    /// </summary>
    public interface IAssetService : ICrudServiceAsync<Guid, Asset, AssetInputDto, AssetOutputDto, AssetPageListDto>, IScopedDependency
    {
    }
}
