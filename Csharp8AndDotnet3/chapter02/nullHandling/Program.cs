#nullable enable
using System;
namespace nullHandling
{
    class Program
    {
        static void Main(string[] args)
        {
            int thisCannotBeNull = 4;
            //thisCannotBeNull = null; //编译错误
            int? thisCouldBeNull = null;
            System.Console.WriteLine(thisCouldBeNull);
            System.Console.WriteLine(thisCouldBeNull.GetValueOrDefault());

            thisCouldBeNull = 7;
            System.Console.WriteLine(thisCouldBeNull);
            Console.WriteLine(thisCouldBeNull.GetValueOrDefault());
            

            Console.WriteLine("===============");
            var address = new Address();
            address.Building = null;
            address.Street = null;
            address.City = null;
            address.Region = null;
            Console.WriteLine("===============");
        }
    }
    class Address
		{
			public string ? Building;
			public string Street = string.Empty;
			public string City = string.Empty;
			public string Region = string.Empty;
		}
}
/*
 *从C#8.0开始，未修饰的引用类型可以变为不可空，并且使用与值类型相同的语法，从而使引用类型变为空。
 */
