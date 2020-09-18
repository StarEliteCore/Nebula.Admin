namespace Destiny.Core.Flow.Entity
{
    public interface IDto<TKey>
    {
        TKey Id { get; set; }
    }


    public abstract class DtoBase<TKey> : IDto<TKey>
    {
        public virtual TKey Id { get; set; }


    }
}
