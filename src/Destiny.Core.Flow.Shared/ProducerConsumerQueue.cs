using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Destiny.Core.Flow.Shared
{


    /// <summary>
    /// 生产者消费者
    /// </summary>
    public  class ProducerConsumerQueue : IDisposable
    {

        public EventHandler EventHandler = null;
        EventWaitHandle wh = new AutoResetEvent(false);
        Thread worker;
        Queue<string> tasks = new Queue<string>();

        readonly object _locker = new object();

        public ProducerConsumerQueue()
        {

            worker = new Thread(Work);
            worker.Start();
        }

        public void EnqueueTask(string task)
        {
            lock (_locker)
            {

                tasks.Enqueue(task);
            }
            wh.Set();
        }


        public void Work()
        {
            while (true)
            {
                string task =null;
                lock (_locker)
                {
                    if (tasks.Count > 0)
                    {
                        task = tasks.Dequeue();
                        if (task == null)
                        {
                            return;
                        }
                    }

                }


                if (task != null)
                {

                    if (EventHandler != null)
                    {
                        EventHandler.Invoke(task, EventArgs.Empty);
                        Thread.Sleep(1000);

                    }
            
                }
                else
                {
                    wh.WaitOne();
                }

            }

     
        }

        public void Dispose()
        {
            // 消费者退出信号
            EnqueueTask(null);

            // 等待消费者线程结束
            worker.Join();

            wh.Close();
        }
    }
}
