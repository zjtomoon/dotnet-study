using System;
using static System.Console;

namespace booleanOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            //逻辑运算符
            bool a = true;
            bool b = false;
            
            WriteLine($"AND  | a | b");
            WriteLine($"a    | {a & a,-5} | {a & b,-5}");
            WriteLine($"b    | {b & a,-5} | {b & b,-5}");
            WriteLine();
            
            WriteLine($"OR  | a | b");
            WriteLine($"a    | {a | a,-5} | {a | b,-5}");
            WriteLine($"b    | {b | a,-5} | {b | b,-5}");
            WriteLine();
            
            WriteLine($"XOR  | a | b");
            WriteLine($"a    | {a ^ a,-5} | {a ^ b,-5}");
            WriteLine($"b    | {b ^ a,-5} | {b ^ b,-5}");
            /*
             * &运算符：如果结果为true,那么两个操作数都必须为true
             * |运算符:如果结果为true,那么操作数至少有一个为true
             * ^运算符：如果结果为true,那么任何一个操作数都可以为true(但不能同时为true)
             */
            
            WriteLine("========================");
            WriteLine($"a & DoStuff = {a & DoStuff()}");
            WriteLine($"b & DoStuff = {b & DoStuff()}");
            WriteLine();
            
            WriteLine($"a && DoStuff = {a && DoStuff()}");
            WriteLine($"b && DoStuff = {b && DoStuff()}");//DoStuff函数没有执行
        }

        private static bool DoStuff()
        {
            WriteLine("I am doing some stuff");
            return true;
        }
    }
}
