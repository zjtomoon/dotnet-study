﻿using System;
using Packt.Shared;
using System.Linq;
using static System.Console;

namespace MonitoringApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /*WriteLine("Processing. Please wait...");
            Recorder.Start();
            int[] largeArrayOfInts = Enumerable.Range(1, 10_000).ToArray();
            
            System.Threading.Thread.Sleep(
                new Random().Next(5,10) * 1000);
            Recorder.Stop();
            */
            int[] numbers = Enumerable.Range(1, 50_000).ToArray();
            
            Recorder.Start();
            WriteLine("Using start with +");
            string s = "";
            for (int i = 0; i < numbers.Length; i++)
            {
                s += numbers[i] + ", ";
            }
            Recorder.Stop();
            
            Recorder.Start();
            WriteLine("Using StringBuilder");
            var builder = new System.Text.StringBuilder();
            /*
             * 应避免在循环内部使用String.Concat方法或+运算符。
             * 应该使用StringBuilder类代替
             */
            for (int i = 0; i < numbers.Length; i++)
            {
                builder.Append(numbers[i]);
                builder.Append(", ");
            }
            Recorder.Stop();
        }
    }
}