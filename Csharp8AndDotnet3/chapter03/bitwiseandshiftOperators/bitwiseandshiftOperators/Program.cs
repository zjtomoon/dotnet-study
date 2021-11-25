﻿using System;
using static System.Console;

namespace bitwiseandshiftOperators
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10;//0000 1010
            int b = 6;//0000 0110
            
            WriteLine($"a = {a}");
            WriteLine($"b = {b}");
            WriteLine($"a & b = {a & b}");//2-bit column only
            WriteLine($"a | b = {a | b}");//8,4, and 2-bit columns
            WriteLine($"a ^ b = {a ^ b}");//8 and 4-bit columns
            
            WriteLine("=========================");
            WriteLine($"a << 3 = {a << 3}");
            WriteLine($"a * 8 = {a * 8}");
            WriteLine($"b >>1 = {b >> 1}");
            
            //将变量a左移3位相当于乘以8，而将变量右移1位相当于除以2
        }
    }
}