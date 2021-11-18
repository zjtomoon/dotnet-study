using System;
using static System.Console;

namespace operators
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 3;
            int b = a++;
            WriteLine($"a is {a}, b is {b}");

            int c = 3;
            int d = ++c;//先自增1再对c赋值
            WriteLine($"c is {c}, d is {d}");
            WriteLine("=======================");

            int e = 11;
            int f = 3;
            WriteLine($"e is {e}, f is {f}");
            WriteLine($"e + f = { e + f}");
            WriteLine($"e - f = { e - f}");
            WriteLine($"e * f = { e * f}");
            WriteLine($"e / f = { e / f}");
            WriteLine($"e % f = { e % f}");
            WriteLine("=======================");
            double g = 11.0;
            WriteLine($"g is {g:N1},f is {f}");
            WriteLine($"g / f = {g / f}");
            
            //赋值运算
            WriteLine("========================");
            int p = 6;
            p += 3;
            p -= 3;
            p *= 3;
            p /= 3;
        }
    }
}