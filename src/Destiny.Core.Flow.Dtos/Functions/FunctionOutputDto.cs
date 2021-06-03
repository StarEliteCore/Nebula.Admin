using DestinyCore.Entity;
using DestinyCore.Mapping;
using Destiny.Core.Flow.Model.Entities.Function;
using System;

namespace Destiny.Core.Flow.Dtos.Functions
{
    [AutoMapping(typeof(Function))]
    public class FunctionOutputDto : FunctionDtoBase<Guid>, IOutputDto<Guid>
    {
    }
}