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
            
            //var ageCheck = new Regex(@"\d");
            //var ageCheck = new Regex(@"^\d$");//拒绝除个位数以外的任何数
            var ageCheck = new Regex(@"^\d+$");
            /*
             * @字符关闭了字符串中使用转义字符的功能。
             * 在使用@禁用转义字符后，就可以用正则表达式解释它们。\d表示数字
             */
            if (ageCheck.IsMatch(input))
            {
                WriteLine("Thank you!");
            }
            else
            {
                WriteLine($"This is not a valid age: {input}");
            }

            string films = "\"Monsters, Inc.\",\",\"I,Tonya\",\"Lock,Stock and Two Smoking Barrels\"";
            string[] filmsDumb = films.Split(',');
            foreach (string film in filmsDumb)
            {
                WriteLine(film);
            }
            //添加语句以定义要分割的正则表达式
            var csv = new Regex("(?:^|,)(?=[^\"]|(\")?)\"?((?(1)[^\"]*|[^,\"]*))\"?(?=,|$)");
            MatchCollection filmSmart = csv.Matches(films);
            WriteLine("Smart attempt at splitting:");
            foreach (Match film in filmSmart)
            {
                WriteLine(film.Groups[2].Value);
            }
        }
    }
}