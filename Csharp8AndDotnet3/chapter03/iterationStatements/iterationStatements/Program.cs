using System;
using static System.Console;

namespace iterationStatements
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            while (x < 10)
            {
                Write($"{x} ");
                x++;
            }
            WriteLine();
            WriteLine("==================");
            string password = string.Empty;
            int errno = 0;
            do
            {
                Write("Enter your password: ");
                password = ReadLine();
                errno++;
                if (errno >= 3)
                {
                    WriteLine("too many times failed .");
                    break;
                }
            } while (password != "pa$$w0rd");
            //WriteLine(errno);
            if (errno < 3)
            {
                WriteLine("correct!");   
            }
            WriteLine("=================");
            string[] names = {"Adam", "Barry", "Charlie"};
            foreach (string name in names)
            {
                WriteLine($"{name} has {name.Length} characters.");
            }
        }
    }
}