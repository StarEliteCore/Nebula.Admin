using JetBrains.Annotations;

namespace Destiny.Core.Flow.Dependency
{
    public interface IObjectAccessor<TType>
    {
        TType Value { get; set; }
    }

    public class ObjectAccessor<TType> : IObjectAccessor<TType>
    {
        public ObjectAccessor([CanBeNull] TType obj)
        {
            Value = obj;
        }

        public ObjectAccessor()
        {
        }

        public TType Value { get; set; }
    }
}