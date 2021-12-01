using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Console;

namespace SynchronizingResourceAccess
{
    class Program
    {
        static Random r = new Random();
        static string Message;
        static object conch = new object();
        
        static void Main(string[] args)
        {
            
            //同步访问共享资源
            WriteLine("Please wait for the tasks to complete.");
            Stopwatch watch = Stopwatch.StartNew();

            Task a = Task.Factory.StartNew(MethodA);
            Task b = Task.Factory.StartNew(MethodB);

            Task.WaitAll(new Task[] {a, b});
            WriteLine();
            WriteLine($"Results: {Message}.");
            WriteLine($"{watch.ElapsedMilliseconds:#,##0} elapsed milliseconds.");
        }

        static void MethodA()
        {
            //添加lock来确保一次只有一个线程能访问共享资源
            /*lock (conch)
            {
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(r.Next(2000));
                    Message += "A";
                    Write(".");
                }
            }*/

            try
            {
                Monitor.TryEnter(conch, TimeSpan.FromSeconds(15));
                    
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(r.Next(2000));
                    Message += "A";
                    Write(".");
                }
            }
            finally
            {
                Monitor.Exit(conch);
            }
        }

        static void MethodB()
        {
            /*lock (conch)
            {
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(r.Next(2000));
                    Message += "B";
                    Write(".");
                }
            }*/
            
            //使用try-finally语句+monitor来避免死锁
            try
            {
                Monitor.TryEnter(conch, TimeSpan.FromSeconds(15));
                
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(r.Next(2000));
                    Message += "B";
                    Write(".");
                }
            }
            finally
            {
                Monitor.Exit(conch);
            }
        }
    }
}