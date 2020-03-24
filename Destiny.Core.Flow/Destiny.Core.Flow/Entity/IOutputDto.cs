using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Entity
{
    /// <summary>
    /// 定义输出DTO
    /// </summary>
   public interface IOutputDto
    {
    }


    public interface IOutputDto<TKey>: IOutputDto
    {

        TKey Id { get; set; }
    }

    public class OutputDtoBase<TKey> : IOutputDto<TKey>
    {
        public TKey Id { get; set; }
    }
}
