using System;
using System.Text.RegularExpressions;
using static System.Console;

namespace WorkingWithRegularExpression
{
    class Program
    {
        //模式匹配与正则表达式
        static void Main(string[] args)
        {
            WriteLine("Enter your age: ");
            string input = ReadLine();

            var ageCheck = new Regex(@"\d");
            if (ageCheck.IsMatch(input))
            {
                WriteLine("Thank you!");
            }
            else
            {
                WriteLine($"This is not a valid age: {input}");
            }
        }
    }
}