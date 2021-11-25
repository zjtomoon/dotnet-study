using System;
using static System.Console;

namespace WorkingWithText
{
    class Program
    {
        static void Main(string[] args)
        {
            //获取字符串长度
            string city = "London";
            WriteLine($"{city} is {city.Length} characters long");
            
            //获取字符串中的字符
            //string类在内部使用char数组来存储文本
            WriteLine($"First char is {city[0]} and third is {city[2]}");
            
            //拆分字符串
            string cities = "Paris,Berlin,Marid,New York";
            string[] citiesArray = cities.Split(",");
            foreach (string item in citiesArray)
            {
                WriteLine(item);
            }
            
            //获取字符串的一部分
            string fullName = "Alan Jones";
            int indexOfSpace = fullName.IndexOf(' ');

            string firstName = fullName.Substring(startIndex: 0, length: indexOfSpace);

            string lastName = fullName.Substring(startIndex: indexOfSpace + 1);
            WriteLine($"{lastName}, {firstName}");
            
            //检查字符串的内容
            string company = "Microsoft";
            bool startWithM = company.StartsWith("M");
            bool containsN = company.Contains("N");
            WriteLine($"Starts with M: {startWithM},contains an N: {containsN}");
            
            //连接、格式化和其他的字符串成员方法
            string recombined = string.Join(" => ", citiesArray);
            WriteLine(recombined);

            string fruit = "Apples";
            decimal price = 0.39M;
            DateTime when = DateTime.Today;
            WriteLine($"{fruit} cost {price:C} on {when :dddd}s.");
            WriteLine(string.Format("{0} cost {1:C} on {2:dddd}s.",fruit,price,when));
        }
    }
}