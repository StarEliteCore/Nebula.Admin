using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Destiny.Core.Flow.Threading
{
    /// <summary>
    /// 线程安全随机数生成器
    /// </summary>
    public class ThreadSafeRandom : Random
    {
        /// <summary>
        /// 使用ThreadLocal<T>类来创建一个线程安全的随机数生成器
        /// </summary>
        private readonly ThreadLocal<Random> random =
            new ThreadLocal<Random>(() => new Random(MakeRandomSeed()));

        public override int Next()
        {
            return random.Value.Next();
        }

        public override int Next(int maxValue)
        {
            return random.Value.Next(maxValue);
        }

        public override int Next(int minValue, int maxValue)
        {
            return random.Value.Next(minValue, maxValue);
        }

        public override double NextDouble()
        {
            return random.Value.NextDouble();
        }

        public override void NextBytes(byte[] buffer)
        {
            random.Value.NextBytes(buffer);
        }

        //创建不依赖于系统时钟的种子。
        //每次调用都会创建一个唯一的值

        private static int MakeRandomSeed()
        {
            return Guid.NewGuid().ToString().GetHashCode();
        }
    }
}
