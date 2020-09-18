namespace Destiny.Core.Flow.Entity
{
    /// <summary>
    /// 定义输入DTO底层接口
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    public interface IInputDto<TKey>
    {
        /// <summary>
        /// 获取或设置 主键，唯一标识
        /// </summary>
        TKey Id { get; set; }
    }
}
