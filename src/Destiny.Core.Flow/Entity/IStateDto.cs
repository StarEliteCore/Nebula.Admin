using Destiny.Core.Flow.Enums;
using Destiny.Core.Flow.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

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
            if (typeof(TKey) == typeof(Guid))
            {
                DtoState = GetState(key => key.AsTo<Guid>() == Guid.Empty);
            }
            else if (typeof(TKey) == typeof(int))
            {
                DtoState = GetState(key => key.AsTo<int>() == 0);
            }
            else if (typeof(TKey) == typeof(Int32))
            {
                DtoState = GetState(key => key.AsTo<Int32>() == 0);
            }
            else if (typeof(TKey) == typeof(Int64))
            {
                DtoState = GetState(key => key.AsTo<Int64>() == 0);
            }
        }

        private DtoState GetState(Func<object, bool> func)
        {

            return func(Id) ? DtoState.Add : DtoState.Update;
        }

        public virtual DtoState DtoState { get; set; }
    }
}
