using System;
using System.Threading;
using System.Threading.Tasks;

namespace async_example01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"ThreadID:{Thread.CurrentThread.ManagedThreadId} Hello,I am a caller");
            DoAsync();
            Console.WriteLine($"ThreadID:{Thread.CurrentThread.ManagedThreadId} Hello, I am a caller too!");
            Console.Read();
        }

        // 注意，我们无法等待(await)一个async void方法
        public static async void DoAsync()
        {
            Console.WriteLine($"ThreadID:{Thread.CurrentThread.ManagedThreadId} In DoAsync(),before SunAsync");
            await SunAsunc();
            Console.WriteLine($"ThreadID:{Thread.CurrentThread.ManagedThreadId} After SunAsync(),DoSync() End.");
        }

        public static async Task SunAsunc()
        {
            var t = Task.Run(() =>
            {
                Console.WriteLine($"ThreadID:{Thread.CurrentThread.ManagedThreadId} New Task~");
                for (int i = 0; i < 10; i++)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine($"ThreadID:{Thread.CurrentThread.ManagedThreadId} I am playing game...");
                }
            });
            
            Console.WriteLine($"ThreadID:{Thread.CurrentThread.ManagedThreadId} After Task,before await.");
            await t;
            Console.WriteLine($"ThreadID:{Thread.CurrentThread.ManagedThreadId} After await,before SunAsync() exit.");
        }
    }
}


/**

ThreadID:1 Hello,I am a caller
ThreadID:1 In DoAsync(),before SunAsync
ThreadID:1 After Task,before await.
ThreadID:4 New Task~
ThreadID:1 Hello, I am a caller too!
ThreadID:4 I am playing game...
ThreadID:4 I am playing game...
ThreadID:4 I am playing game...
ThreadID:4 I am playing game...
ThreadID:4 I am playing game...
ThreadID:4 I am playing game...
ThreadID:4 I am playing game...
ThreadID:4 I am playing game...
ThreadID:4 I am playing game...
ThreadID:4 I am playing game...
ThreadID:4 After await,before SunAsync() exit.
ThreadID:4 After SunAsync(),DoSync() End.

*/