using Destiny.Core.Flow.Enums;
using System.Collections.Generic;

namespace Destiny.Core.Flow.Entity
{
    public interface IStateDto<TKey> : IDto<TKey>
    {
        DtoState DtoState { get; set; }
    }


    public abstract class StateDto<TKey> : DtoBase<TKey>, IStateDto<TKey>
    {
        protected StateDto()
        {


            DtoState = IsNew() == true ? DtoState.Add : DtoState.Update;
        }

        public bool IsNew() =>
                      EqualityComparer<TKey>.Default.Equals(Id, default);
        public virtual DtoState DtoState { get; set; }
    }
}
