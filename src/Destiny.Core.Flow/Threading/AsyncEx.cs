using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Extensions
{
    /// <summary>
    /// Task扩展
    /// </summary>
    public static partial class Extensions
    {

        /// <summary>
        /// 处理Task异常（这种设计可能违反了非局部性原则）
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TError"></typeparam>
        /// <param name="task"></param>
        /// <param name="onError"></param>
        /// <returns></returns>
        public static Task<T> Catch<T, TError>(this Task<T> task, Func<TError, T> onError) where TError : Exception
        {
            var tcs = new TaskCompletionSource<T>(); //TaskCompletionSource的实例返回一个Task类型以保持异步模型中的一致性
            task.ContinueWith(innerTask =>
            {
                if (innerTask.IsFaulted && innerTask?.Exception?.InnerException is TError)
                {
                    tcs.SetResult(onError((TError)innerTask.Exception.InnerException));
                }
                else if (innerTask.IsCanceled)
                {
                    tcs.SetCanceled();
                }
                else if (innerTask.IsFaulted)
                {
                    tcs.SetException(innerTask?.Exception?.InnerException ?? throw new InvalidOperationException());
                }
                else
                {
                    tcs.SetResult(innerTask.Result);
                }
            });
            return tcs.Task;
        }

        /// <summary>
        /// 异步循环
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">源</param>
        /// <param name="maxDegreeOfParallelism">最大并行度值</param>
        /// <param name="body">主体</param>
        /// <returns></returns>
        public static Task ForEachAsync<T>(this IEnumerable<T> source, int maxDegreeOfParallelism, Func<T, Task> body)
        {
            return Task.WhenAll(
                from partition in Partitioner.Create(source).GetPartitions(maxDegreeOfParallelism)
                select Task.Run(async () =>
                {
                    using (partition)
                    {
                        while (partition.MoveNext())
                            await body(partition.Current);
                    }
                }));
        }

        /// <summary>
        /// 异步循环
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static Task ForEachAsync<T>(this IEnumerable<T> source, Func<T, Task> body)
        {
            return source.ForEachAsync(Environment.ProcessorCount, body);
        }

        public static Task<TOut> Select<TIn, TOut>(this Task<TIn> task, Func<TIn, TOut> projection)
        {
            var r = new TaskCompletionSource<TOut>();
            task.ContinueWith(self =>
            {
                if (self.IsFaulted)
                {
                    r.SetException(self.Exception.InnerExceptions);
                }
                else if (self.IsCanceled)
                {
                    r.SetCanceled();
                }
                else
                {
                    r.SetResult(projection(self.Result));
                }
            });
            return r.Task;
        }

        public static Task<TOut> SelectMany<TIn, TOut>(this Task<TIn> first, Func<TIn, Task<TOut>> next)
        {
            var tcs = new TaskCompletionSource<TOut>();
            first.ContinueWith(delegate
            {
                if (first.IsFaulted)
                {
                    tcs.TrySetException(first.Exception.InnerExceptions);
                }
                else if (first.IsCanceled)
                {
                    tcs.TrySetCanceled();
                }
                else
                {
                    try
                    {
                        var t = next(first.Result);
                        if (t == null) {
                            tcs.TrySetCanceled();
                        }
                        else
                            t.ContinueWith(delegate
                            {
                                if (t.IsFaulted)
                                {
                                    tcs.TrySetException(t.Exception.InnerExceptions);
                                }
                                else if (t.IsCanceled)
                                {
                                    tcs.TrySetCanceled();
                                }
                                else
                                {
                                    tcs.TrySetResult(t.Result);
                                }
                            }, TaskContinuationOptions.ExecuteSynchronously);
                    }
                    catch (Exception exc)
                    {
                        tcs.TrySetException(exc);
                    }
                }
            }, TaskContinuationOptions.ExecuteSynchronously);
            return tcs.Task;
        }

        /// <summary>
        /// 完成时处理
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="inputTasks"></param>
        /// <returns></returns>
        public static IEnumerable<Task<T>> ProcessAsComplete<T>(this IEnumerable<Task<T>> inputTasks)
        {
            // Copy the input so we know it’ll be stable, and we don’t evaluate it twice
            var inputTaskList = inputTasks.ToList();
            // Could use Enumerable.Range here, if we wanted…
            var completionSourceList = new List<TaskCompletionSource<T>>(inputTaskList.Count);
            for (var i = 0; i < inputTaskList.Count; i++) completionSourceList.Add(new TaskCompletionSource<T>());

            // At any one time, this is "the index of the box we’ve just filled".
            // It would be nice to make it nextIndex and start with 0, but Interlocked.Increment
            // returns the incremented value…
            var prevIndex = -1;

            // We don’t have to create this outside the loop, but it makes it clearer
            // that the continuation is the same for all tasks.
            Action<Task<T>> continuation = completedTask =>
            {
                var index = Interlocked.Increment(ref prevIndex);
                var source = completionSourceList[index];
                switch (completedTask.Status)
                {
                    case TaskStatus.Canceled:
                        source.TrySetCanceled();
                        break;
                    case TaskStatus.Faulted:
                        source.TrySetException(completedTask.Exception.InnerExceptions);
                        break;
                    case TaskStatus.RanToCompletion:
                        source.TrySetResult(completedTask.Result);
                        break;
                    default:
                        throw new ArgumentException("Task was not completed");
                }
            };

            foreach (var inputTask in inputTaskList)
                inputTask.ContinueWith(continuation,
                    CancellationToken.None,
                    TaskContinuationOptions.ExecuteSynchronously,
                    TaskScheduler.Default);

            return completionSourceList.Select(source => source.Task);
        }
    }
}
