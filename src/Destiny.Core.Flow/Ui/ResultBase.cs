namespace Destiny.Core.Flow.Ui
{
    public abstract class ResultBase : IResultBase
    {



        public virtual bool Success { get; set; }


        public virtual string Message { get; set; }


    }


    public interface IResultBase
    {
        bool Success { get; set; }


        string Message { get; set; }
    }
}
