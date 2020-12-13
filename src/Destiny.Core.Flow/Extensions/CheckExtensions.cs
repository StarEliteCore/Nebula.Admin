using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace Destiny.Core.Flow.Extensions
{
    /// <summary>
    /// 检查扩展
    /// </summary>
    public static partial class Extensions
    {
        /// <summary>
        /// 验证指定值的断言<paramref name="assertion"/>是否为真，如果不为真，抛出指定消息<paramref name="message"/>的指定类型<typeparamref name="TException"/>异常
        /// </summary>
        /// <typeparam name="TException">异常类型</typeparam>
        /// <param name="assertion">要验证的断言。</param>
        /// <param name="message">异常消息。</param>
        private static void Require<TException>(bool assertion, string message)
            where TException : Exception
        {
            if (assertion)
            {
                return;
            }
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException(nameof(message));
            }
            TException exception = (TException)Activator.CreateInstance(typeof(TException), message);
            throw exception;
        }

        /// <summary>
        /// 验证指定值的断言表达式是否为真，不为值抛出<see cref="Exception"/>异常
        /// </summary>
        /// <param name="value"></param>
        /// <param name="assertionFunc">要验证的断言表达式</param>
        /// <param name="message">异常消息</param>
        public static void Required<T>(this T value, Func<T, bool> assertionFunc, string message)
        {
            if (assertionFunc == null)
            {
                throw new ArgumentNullException(nameof(assertionFunc));
            }
            Require<Exception>(assertionFunc(value), message);
        }

        /// <summary>
        /// 验证指定值的断言表达式是否为真，不为真抛出<typeparamref name="TException"/>异常
        /// </summary>
        /// <typeparam name="T">要判断的值的类型</typeparam>
        /// <typeparam name="TException">抛出的异常类型</typeparam>
        /// <param name="value">要判断的值</param>
        /// <param name="assertionFunc">要验证的断言表达式</param>
        /// <param name="message">异常消息</param>
        public static void Required<T, TException>(this T value, Func<T, bool> assertionFunc, string message) where TException : Exception
        {
            if (assertionFunc == null)
            {
                throw new ArgumentNullException(nameof(assertionFunc));
            }
            Require<TException>(assertionFunc(value), message);
        }

        /// <summary>
        /// 检查参数不能为空引用，否则抛出<see cref="ArgumentNullException"/>异常。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="paramName">参数名称</param>
        /// <exception cref="ArgumentNullException"></exception>
        public static void NotNull<T>(this T value, string paramName)
        {
            Require<ArgumentNullException>(value != null, $"参数“{paramName}”不能为空引用。");
        }
        /// <summary>
        /// 检查字符串不能为空引用或空字符串，否则抛出<see cref="ArgumentNullException"/>异常或<see cref="ArgumentException"/>异常。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="paramName">参数名称。</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static void NotNullOrEmpty(this string value, string paramName)
        {
            Require<ArgumentException>(!string.IsNullOrEmpty(value), $"参数“{paramName}”不能为空引用或空字符串。");
        }

        /// <summary>
        /// 检查Guid值不能为Guid.Empty，否则抛出<see cref="ArgumentException"/>异常。
        /// </summary>
        /// <param name="value"></param>
        /// <param name="paramName">参数名称。</param>
        /// <exception cref="ArgumentException"></exception>
        public static void NotEmpty(this Guid value, string paramName)
        {
            Require<ArgumentException>(value != Guid.Empty, $"参数“{paramName}”的值不能为Guid.Empty");
        }

        /// <summary>
        /// 检查集合不能为空引用或空集合，否则抛出<see cref="ArgumentNullException"/>异常或<see cref="ArgumentException"/>异常。
        /// </summary>
        /// <typeparam name="T">集合项的类型。</typeparam>
        /// <param name="collection"></param>
        /// <param name="paramName">参数名称。</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static void NotNullOrEmpty<T>(this IEnumerable<T> collection, string paramName)
        {
            NotNull(collection, paramName);
            Require<ArgumentException>(collection.Any(), $"参数“{paramName}”不能为空引用或空集合。");
        }
        /// <summary>
        ///  检查集合不能为空委托，否则抛出<see cref="ArgumentNullException"/>异常或<see cref="ArgumentException"/>异常。
        /// </summary>
        /// <typeparam name="TSource">委托类型</typeparam>
        /// <typeparam name="TResult">委托类型</typeparam>
        /// <param name="func">委托</param>
        /// <param name="paramName">参数名称。</param>
        public static void NotNull<TSource, TResult>(this Func<TSource, TResult> func, string paramName)
        {
            NotNull(func, paramName);
            Require<ArgumentException>(func.IsNotNull(), $"参数“{paramName}”不能为空委托。");
        }
        /// <summary>
        /// 检查指定路径的文件夹必须存在，否则抛出<see cref="DirectoryNotFoundException"/>异常。
        /// </summary>
        /// <param name="directory"></param>
        /// <param name="paramName">参数名称。</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="DirectoryNotFoundException"></exception>
        public static void DirectoryExists(this string directory, string paramName = null)
        {
            NotNull(directory, paramName);
            Require<DirectoryNotFoundException>(Directory.Exists(directory), $"指定的目录路径“{directory}”不存在。");
        }
        /// <summary>
        /// 检查指定路径的文件必须存在，否则抛出<see cref="FileNotFoundException"/>异常。
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="paramName">参数名称。</param>
        /// <exception cref="ArgumentNullException">当文件路径为null时</exception>
        /// <exception cref="FileNotFoundException">当文件路径不存在时</exception>
        public static void FileExists(this string filename, string paramName = null)
        {
            NotNull(filename, paramName);
            Require<FileNotFoundException>(File.Exists(filename), $"指定的文件路径“{filename}”不存在");
        }

        /// <summary>
        /// 检查指定路径的文件必须存在，否则抛出<see cref="FileNotFoundException"/>异常。
        /// </summary>
        /// <param name="filename"></param>
        /// <param name="fileNotExistsMsg">文件不存在消息。</param>
        /// <param name="paramName">参数名称。</param>
        /// <exception cref="ArgumentNullException">当文件路径为null时</exception>
        /// <exception cref="FileNotFoundException">当文件路径不存在时</exception>
        public static void FileExists(this string filename,string fileNotExistsMsg, string paramName = null)
        {
            NotNull(filename, paramName);
            Require<FileNotFoundException>(File.Exists(filename), fileNotExistsMsg);
        }
    }
}
