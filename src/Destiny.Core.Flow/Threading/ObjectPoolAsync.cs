using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Destiny.Core.Flow.Threading
{
    /// <summary>
    /// 使用TDF实现异步对象池
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public sealed class ObjectPoolAsync<T> : IDisposable
    {
        //缓冲块
        private readonly BufferBlock<T> buffer;
        //工厂
        private readonly Func<T> factory;
        //超时
        private readonly int msecTimeout;
        //当前大小
        private int currentSize;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="initialCount">初始计数</param>
        /// <param name="factory">工厂</param>
        /// <param name="cts">传播应取消操作的通知</param>
        /// <param name="msecTimeout">超时</param>
        public ObjectPoolAsync(int initialCount, Func<T> factory, CancellationToken? cts = null, int msecTimeout = 0)
        {
            this.msecTimeout = msecTimeout;

            var ctsToken = cts ?? new CancellationToken();
            ctsToken.Register(Dispose);

            //创建缓冲块
            buffer = new BufferBlock<T>(
                new DataflowBlockOptions { CancellationToken = ctsToken } //使用BufferBlock异步协调类型T的底层集合
            );
            this.factory = () =>
            {
                Interlocked.Increment(ref currentSize);
                return factory(); //使用工厂委托生成类型为T的新实例
            };
            for (var i = 0; i < initialCount; i++)
            {
                buffer.Post(this.factory()); //在对象池的初始化过种中，往缓冲区中镇充类型T的实例，以便从一开始就有对象可以使用
            }
        }


        /// <summary>
        /// 大小
        /// </summary>
        public int Size => currentSize;

        /// <summary>
        /// 释放
        /// </summary>
        public void Dispose() => buffer.Complete();


        /// <summary>
        /// 可以将一个条目异步放入池中
        /// </summary>
        /// <param name="item"></param>
        /// <returns>当消费者完成后，会将对象类型T发送回对象池以进行循环利用</returns>
        public Task<bool> PutAsync(T item) => buffer.SendAsync(item);

        /// <summary>
        /// 可以从池中异步获取一个条目
        /// </summary>
        /// <param name="timeout"></param>
        /// <returns>消费者发送出请求时，对象池将发送类型T对象</returns>
        public Task<T> GetAsync(int timeout = 0)
        {
            var tcs = new TaskCompletionSource<T>();
            buffer.ReceiveAsync(TimeSpan.FromMilliseconds(msecTimeout)) //异步接收
                .ContinueWith(task =>
                {
                    if (task.IsFaulted)
                    {
                        if (task.Exception.InnerException is TimeoutException)
                        {
                            tcs.SetResult(factory());
                        }
                        else
                        {
                            tcs.SetException(task.Exception);
                        }
                    }
                    else if (task.IsCanceled)
                    {
                        tcs.SetCanceled();
                    }
                    else
                    {
                        tcs.SetResult(task.Result);
                    }
                });
            return tcs.Task;
        }
    }
}
