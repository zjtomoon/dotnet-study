using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace LinqInParallel
{
    class Program
    {
        static void Main(string[] args)
        {
           //使用带有并行Linq的多个线程
           var watch = Stopwatch.StartNew();
           Write("Press ENTER to start");
           ReadLine();

           IEnumerable<int> numbers = Enumerable.Range(1, 200_000_000);

           //var squares = numbers.Select(number => number * number).ToArray();
           var squares = numbers.AsParallel().Select(number => number * number).ToArray();//调用AsParallel
           
           watch.Stop();
           WriteLine("{0:#,##0} elapsed milliseconds.",
               watch.ElapsedMilliseconds);

        }
    }
}