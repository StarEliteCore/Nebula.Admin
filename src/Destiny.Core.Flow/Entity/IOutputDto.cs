using Destiny.Core.Flow.Enums;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Destiny.Core.Flow.Extensions;

namespace Destiny.Core.Flow.Entity
{
    /// <summary>
    /// 定义输出DTO
    /// </summary>
   public interface IOutputDto
    {
     
    }

    /// <summary>
    /// 继承第一层DTO接口
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface IOutputDto<TKey>: IOutputDto
    {
   
        TKey Id { get; set; }

    }
    /// <summary>
    /// 实现DTO接口
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public class OutputDtoBase<TKey> : IOutputDto<TKey>
    {
        public OutputDtoBase()
        {
            if (typeof(TKey) == typeof(Guid))
            {
                DtoState = GetState(key=>key.AsTo<Guid>()==Guid.Empty);
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

        private DtoState GetState(Func<object,bool> func)
        {

            return func(Id) ? DtoState.Add : DtoState.Update;
        }
        public TKey Id { get; set; }
        public DtoState DtoState { get; set; }
    }
}
