using System.ComponentModel;

namespace Destiny.Core.Flow.Events
{
    public abstract class CacheEventDataBase : Notification
    {

        public EventState EventState { get; set; } = EventState.Add;
    }

    [Description("事件状态")]
    public enum EventState
    {
        [Description("添加")]
        Add = 5,
        [Description("更新")]
        Update = 10,
        [Description("移除")]
        Remove = 15,
    }
}
