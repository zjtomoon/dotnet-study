using System;
using System.Linq;
using static System.Console;

namespace LingWithObjects
{
    class Program
    {
        static void Main(string[] args)
        {
            //LinqWithArrayOfStrings();
            LinqWithArrayOfExceptions();
        }

        static void LinqWithArrayOfStrings()
        {
            var names = new string[]
            {
                "Michael","Pam","Jim","Dwight",
                "Angela","Kevin","Toby","Creed"
            };

            //var query = names.Where(new Func<string, bool>(NameLongerThanFour));
            //var query = names.Where(NameLongerThanFour);
            //var query = names.Where(name => name.Length > 4); //lambda表达式
            var query = names
                .Where(name => name.Length > 4)
                .OrderBy(name => name.Length) //按照字符长度排序
                .ThenBy(name => name); //使用ThenBy扩展方法按后续属性排序
            
            
            foreach (string item in query)
            {
                WriteLine(item);
            }
        }

        static bool NameLongerThanFour(string name)
        {
            return name.Length > 4;
        }

        static void LinqWithArrayOfExceptions()
        {
            var errors = new Exception[]
            {
                new ArgumentException(),
                new SystemException(),
                new IndexOutOfRangeException(),
                new InvalidOperationException(),
                new NullReferenceException(),
                new NullReferenceException(),
                new InvalidCastException(),
                new OverflowException(),
                new OverflowException(),
                new DivideByZeroException(),
                new ApplicationException()
            };
            var numberErrors = errors.OfType<ArithmeticException>();
            foreach (var error in numberErrors)
            {
                WriteLine(error);
            }
        }
    }
}