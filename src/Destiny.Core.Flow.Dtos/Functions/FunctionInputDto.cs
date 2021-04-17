using Destiny.Core.Flow.Entity;
using Destiny.Core.Flow.Mapping;
using Destiny.Core.Flow.Model.Entities.Function;
using System;

namespace Destiny.Core.Flow.Dtos.Functions
{
    [AutoMapping(typeof(Function))]
    public class FunctionInputDto : FunctionDtoBase<Guid>, IInputDto<Guid>
    {
    }
}