namespace Destiny.Core.Flow.Entity
{
    /// <summary>
    /// 设置种子数据
    /// </summary>
    public interface ISeedData
    {

        /// <summary>
        ///种子数据初始化
        /// </summary>
        void Initialize();

        int Order { get; }

        bool Disable { get; }
    }
}
