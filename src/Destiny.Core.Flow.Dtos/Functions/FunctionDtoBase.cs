using Destiny.Core.Flow.Entity;

namespace Destiny.Core.Flow.Dtos.Functions
{
    public abstract class FunctionDtoBase<TKey> : DtoBase<TKey>
    {  /// <summary>
       /// 功能名字 </summary>
        public string Name { get; set; }

        /// <summary>
        /// 是否可用
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 链接Url
        /// </summary>
        public string LinkUrl { get; set; }
    }
}