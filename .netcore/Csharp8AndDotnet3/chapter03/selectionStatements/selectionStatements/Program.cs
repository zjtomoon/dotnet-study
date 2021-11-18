using System;
using static System.Console;
using System.IO;

namespace selectionStatements
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                WriteLine("There are no arguments.");
            }
            else
            {
                WriteLine("There is at least one auguments.");
            }
            
            WriteLine("===================");

            object o = "3";
            int j = 4;
            if (o is int i)
            {
                WriteLine($"{i} + {j} = {i * j}");
            }
            else
            {
                WriteLine("o is not an int so it cannot multiply");
            }
            WriteLine("=====================");
            A_label:
            var number = (new Random()).Next(1, 7);
            WriteLine($"My random number is {number}");
            switch (number)
            {
                case 1:
                    WriteLine("one");
                    break;
                case 2:
                    WriteLine("two");
                    goto case 1;
                case 3:
                case 4:
                    WriteLine("Three of four");
                    goto case 1;
                case 5:
                    System.Threading.Thread.Sleep(500);
                    goto A_label;
                default:
                    WriteLine("Default");
                    break;
            }
            WriteLine("==================");
            string path = @".\";
            Stream s = File.Open(Path.Combine(path, "1.txt"), FileMode.OpenOrCreate);
            string message = string.Empty;
            switch (s)
            {
                case FileStream writeableFile when s.CanWrite:
                    message = "The stream is a file stream that I can write to";
                    break;
                case FileStream readOnlyFile:
                    message = "The stream is a read-only file.";
                    break;
                case MemoryStream ms:
                    message = "The stream is a memory address";
                    break;
                default:
                    message = "The stream is some other type.";
                    break;
                case null:
                    message = "The stream is null.";
                    break;
            }
            WriteLine(message);
            
            WriteLine("=======================");
            message = s switch
            {
                FileStream writeableFile when s.CanWrite
                    => "The stream is a file stream that I can write to",
                FileStream readOnlyFile 
                    => "The stream is a read-only file.",
                MemoryStream ms 
                    => "The stream is a memory address",
                null
                    => "The stream is null",
                _ 
                    => "The stream is some other type."
            };
            WriteLine(message);
        }
    }
}