using System;
using System.Threading;

namespace Destiny.Core.Flow
{
    /// <summary>
    /// 释放接口
    /// </summary>
    public interface IDisposable2 : IDisposable
    {
        /// <summary>
        /// 已释放
        /// </summary>
        bool Disposed { get; }

        /// <summary>
        /// 被销毁时触发事件
        /// </summary>
        event EventHandler OnDisposed;
    }

    public class DisposeBase : IDisposable2
    {
        public bool Disposed => _disposed > 0;

        public event EventHandler OnDisposed;

        private Int32 _disposed = 0;

        public void Dispose()
        {
            Dispose(true);
            ///告诉GC，不要调用析构函数
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (Interlocked.CompareExchange(ref _disposed, 1, 0) != 0)
            {
                return;
            }
            if (disposing)
            {
                ///告诉GC，不要调用析构函数
                GC.SuppressFinalize(this);
            }

            OnDisposed?.Invoke(this, EventArgs.Empty);
        }

        ~DisposeBase()
        {
            Dispose(false);
        }
    }
}