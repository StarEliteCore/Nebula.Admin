using Destiny.Core.Flow.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace Destiny.Core.Flow.Events
{
   public abstract class CacheEventDataBase: Notification
    {
     

        public string CacheId { get; set; }
        //应该放在缓存低层下做。。
        public virtual string GetCacheKey()
        {

            CacheId.NotNullOrEmpty("CacheId");
            var cacheKey= GetType().GetCustomAttribute<CacheKeyAttribute>();
            if (cacheKey is null)
            {
                return CacheId;
            }
            var key= cacheKey.Description().IsNullOrEmpty()? GetType().Name: cacheKey.Description();
            key = $"{key}_{CacheId}";
            if (key.IndexOf("_", 0, 0) == -1)
            {
                key = $"_{key}";
            }
            return key;
           
        }

        public EventState EventState { get; set; } = EventState.Add;
    }

    [Description("事件状态")]
    public enum EventState
    {
        [Description("添加")]
        Add =5,
        [Description("更新")]
        Update = 10,
        [Description("移除")]
        Remove = 15,
    }
}
