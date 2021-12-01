using System;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using static System.Console;

namespace WorkingWithTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            var timer = Stopwatch.StartNew();
            // WriteLine("Running methods synchronously on one thread.");
            //
            // MethodA();
            // MethodB();
            // MethodC();
            
            //使用任务异步执行多个操作
            /*WriteLine("Running methods asynchronously on multiple threads.");
            Task taskA = new Task(MethodA);
            taskA.Start();
            Task taskB = Task.Factory.StartNew(MethodB);
            Task taskC = Task.Run(new Action(MethodC));

            Task[] tasks = { taskA,taskB,taskC};
            Task.WaitAll();

            WriteLine($"{timer.ElapsedMilliseconds:#,##0}ms elapsed.");*/
            
            
            //继续执行另一项任务
            /*WriteLine("Passing the result of one task as an input into another.");

            var taskCallWebServiceAndThenStoredProcedure =
                Task.Factory.StartNew(CallWebService)
                    .ContinueWith(previousTask => CallStoredProcedure(previousTask.Result));
            WriteLine($"Result : {taskCallWebServiceAndThenStoredProcedure.Result}");*/

            //嵌套任务和子任务
            var inner = Task.Factory.StartNew(InnerMethod, TaskCreationOptions.AttachedToParent);
            var outer = Task.Factory.StartNew(OuterMethod);
            outer.Wait();
            WriteLine("Console app is stopping.");
        }

        static void MethodA()
        {
            WriteLine("Starting Method A ...");
            Thread.Sleep(3000);
            WriteLine("Finished Method A.");
        }

        static void MethodB()
        {
            WriteLine("Starting Method B ...");
            Thread.Sleep(2000);
            WriteLine("Finished Method B");
        }

        static void MethodC()
        {
            WriteLine("Starting Method C ...");
            Thread.Sleep(1000);
            WriteLine("Finished Method C .");
        }

        static decimal CallWebService()
        {
            WriteLine("Starting call to web service...");
            Thread.Sleep((new Random()).Next(2000,4000));
            WriteLine("Finished call to web service.");
            return 89.99M;
        }

        static string CallStoredProcedure(decimal amount)
        {
            WriteLine("Starting call to stored procedure...");
            Thread.Sleep((new Random()).Next(2000,4000));
            WriteLine("Finished call to stored procedure.");
            return $"12 products cost more than {amount:C}";
        }

        static void OuterMethod()
        {
            WriteLine("Outer method starting ...");
            var inner = Task.Factory.StartNew(InnerMethod);
            WriteLine("Outer method finished.");
        }

        static void InnerMethod()
        {
            WriteLine("Inner method string ...");
            Thread.Sleep(2000);
            WriteLine("Inner method finished.");
        }
    }
}