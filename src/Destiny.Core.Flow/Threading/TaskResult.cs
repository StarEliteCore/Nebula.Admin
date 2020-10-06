using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Threading
{
  
    public struct TaskResult<T>
    {
        public T Ok { get; } 
        public Exception Error { get; } 

        public bool IsFailed => Error != null;
        public bool IsOk => !IsFailed;

        public TaskResult(T ok)
        {
            Ok = ok;
            Error = default;
        }

        public TaskResult(Exception error) 
        {
            Error = error;
            Ok = default;
        }

        public R Match<R>(Func<T, R> okMap, Func<Exception, R> failureMap)
        {
            return IsOk ? okMap(Ok) : failureMap(Error); 
        }

        public void Match(Action<T> okAction, Action<Exception> errorAction)
        {
            if (IsOk) okAction(Ok);
            else errorAction(Error); 
        }

        public static implicit operator TaskResult<T>(T ok)
        {
            return new TaskResult<T>(ok); 
        }

        public static implicit operator TaskResult<T>(Exception error)
        {
            return new TaskResult<T>(error);
        }

        public static implicit operator TaskResult<T>(TaskResult.Ok<T> ok)
        {
            return new TaskResult<T>(ok.Value); 
        }

        public static implicit operator TaskResult<T>(TaskResult.Failure error)
        {
            return new TaskResult<T>(error.Error); 
        }
    }

    public static class TaskResult
    {
        public struct Ok<L>
        {
            internal L Value { get; }

            internal Ok(L value)
            {
                Value = value;
            }
        }

        public struct Failure
        {
            internal Exception Error { get; }

            internal Failure(Exception error)
            {
                Error = error;
            }
        }
    }

  
    public static class ResultExtensions
    {
        public static TaskResult.Ok<T> Ok<T>(T value)
        {
            return new TaskResult.Ok<T>(value);
        }

        public static TaskResult.Failure Failure(Exception error)
        {
            return new TaskResult.Failure(error);
        }

        public static async Task<TaskResult<T>> TryCatch<T>(Func<Task<T>> func)
        {
            try
            {
                return await func();
            }
            catch (Exception ex)
            {
                return ex;
            }
        }

        public static Task<TaskResult<T>> TryCatch<T>(Func<T> func)
        {
            return TryCatch(() => Task.FromResult(func()));
        }

        public static async Task<TaskResult<R>> SelectMany<T, R>(this Task<TaskResult<T>> resultTask,
            Func<T, Task<TaskResult<R>>> func)
        {
            var result = await resultTask.ConfigureAwait(false);
            if (result.IsFailed)
                return result.Error;
            return await func(result.Ok);
        }

        public static async Task<TaskResult<R>> Select<T, R>(this Task<TaskResult<T>> resultTask, Func<T, Task<R>> func)
        {
            var result = await resultTask.ConfigureAwait(false);
            if (result.IsFailed)
                return result.Error;
            return await func(result.Ok).ConfigureAwait(false);
        }

        public static async Task<TaskResult<R>> Match<T, R>(this Task<TaskResult<T>> resultTask, Func<T, Task<R>> actionOk,
            Func<Exception, Task<R>> actionError)
        {
            var result = await resultTask.ConfigureAwait(false);
            if (result.IsFailed)
                return await actionError(result.Error);
            return await actionOk(result.Ok);
        }

      

        public static async Task<TaskResult<R>> OnSuccess<T, R>(this Task<TaskResult<T>> resultTask, Func<T, Task<R>> func)
        {
            var result = await resultTask.ConfigureAwait(false);

            if (result.IsFailed)
                return result.Error;
            return await func(result.Ok).ConfigureAwait(false);
        }

        public static async Task<TaskResult<T>> OnFailure<T>(this Task<TaskResult<T>> resultTask, Func<Task> func)
        {
            var result = await resultTask.ConfigureAwait(false);

            if (result.IsFailed)
                await func().ConfigureAwait(false);
            return result;
        }

        public static async Task<TaskResult<R>> Bind<T, R>(this Task<TaskResult<T>> resultTask, Func<T, Task<TaskResult<R>>> func)
        {
            var result = await resultTask.ConfigureAwait(false);

            if (result.IsFailed)
                return result.Error;
            return await func(result.Ok).ConfigureAwait(false);
        }

        public static async Task<TaskResult<R>> Map<T, R>(this Task<TaskResult<T>> resultTask, Func<T, Task<R>> func)
        {
            var result = await resultTask.ConfigureAwait(false);

            if (result.IsFailed)
                return result.Error;

            return await TryCatch(() => func(result.Ok));
        }

        public static async Task<TaskResult<R>> Match<T, R>(this Task<TaskResult<T>> resultTask, Func<T, R> actionOk,
            Func<Exception, R> actionError)
        {
            var result = await resultTask.ConfigureAwait(false);

            if (result.IsFailed)
                return actionError(result.Error);
            return actionOk(result.Ok);
        }

        public static async Task<TaskResult<T>> Ensure<T>(this Task<TaskResult<T>> resultTask, Func<T, Task<bool>> predicate,
            string errorMessage)
        {
            var result = await resultTask.ConfigureAwait(false);

            if (result.IsFailed || !await predicate(result.Ok).ConfigureAwait(false)) return result.Error;
            return result.Ok;
        }

        public static async Task<TaskResult<T>> Tap<T>(this Task<TaskResult<T>> resultTask, Func<T, Task> action)
        {
            var result = await resultTask.ConfigureAwait(false);

            if (result.IsOk)
                await action(result.Ok).ConfigureAwait(false);
            return result;
        }
    }
}
