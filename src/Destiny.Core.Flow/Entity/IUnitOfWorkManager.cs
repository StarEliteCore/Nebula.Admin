namespace Destiny.Core.Flow.Entity
{
    public interface IUnitOfWorkManager
    {

        IUnitOfWork Current { get; }

    }
}
