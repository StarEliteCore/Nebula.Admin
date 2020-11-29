namespace Destiny.Core.Flow.Ui
{
    /// <summary>
    /// 所有结果返回基类
    /// </summary>
    public abstract class ResultBase : IResultBase
    {

        /// <summary>
        /// 是否成功
        /// </summary>


        public virtual bool Success { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public virtual string Message { get; set; }


    }


    public interface IResultBase
    {
        bool Success { get; set; }


        string Message { get; set; }
    }
}
