﻿using System;
using static System.Console;

namespace Debugging
{
    class Program
    {
        static double Add(double a,double b) 
        {
            //return a * b;
            return a + b;
        }
        static void Main(string[] args)
        {
            double a = 4.5;
            double b =2.5;
            double answer = Add(a,b);
            WriteLine($"{a} + {b} = {answer}");
            ReadLine();
        }
    }
}