using Destiny.Core.Flow.Events;

namespace Destiny.Core.Flow.Services.Identity.Events
{
    public class IdentityEvent : EventBase
    {
        public string UserName { get; set; }
    }
}