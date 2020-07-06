using Destiny.Core.Flow.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Destiny.Core.Flow.Services.Identity.Events
{
    public  class IdentityEvent : EventBase
    {

        public string UserName { get; set; }
    }
}
