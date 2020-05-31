using Destiny.Core.Flow.Dependency;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.EventBus.Abstractions
{
    [IgnoreDependency]
    /// <summary>
    /// 泛型事件处理器接口
    /// </summary>
    public interface IEventHandler<in TEventData> where TEventData : IEventData
    {

        Task HandleAsync(TEventData eventData);

    }

    //public interface IEventHandler
    //{ 
    
    //}
}
