using System;
using System.IO;
using System.Xml;

namespace variables
{
    class Program
    {
        static void Main(string[] args)
        {
        	object height = 1.88;
        	object name = "Amir";
        	Console.WriteLine($"{name} is {height} metres tall.");

        	//int length1 = name.Length;//编译错误
        	int length2 = ((string)name).Length;
        	Console.WriteLine($"{name} has {length2} characters");
        	
        	Console.WriteLine("=======================");

        	dynamic anotherName = "Ahmed";
        	int length3 = anotherName.Length;
        	Console.WriteLine($"the length of anotherName is {length3}");
            
            //声明局部变量
            /*
            int population = 66_000_000;
            double weight = 1.88;
            decimal price = 4.99M;
            string fruit = "Apples";
            char letter = 'z';
            bool happy = true;
            */
            
            //var声明变量 var关键字修饰的变量可以由编译器推断类型
            var population = 66_000_000;
            var weight = 1.88;
            var price = 4.99M;
            var fruit = "Apples";
            var letter = 'Z';
            var happy = true;
            Console.WriteLine("==========================");
            var xml1 = new XmlDocument();
            XmlDocument xml2 = new XmlDocument();

            /*var file1 = File.CreateText(@"./something.txt");
            StreamWriter file2 = File.CreateText(@"./someting.txt");*/
            
            Console.WriteLine($"default(int) = {default(int)}");
            Console.WriteLine($"default(bool) = {default(bool)}");
            Console.WriteLine($"default(DataTime) = {default(DateTime)}");
            Console.WriteLine($"default(string) = {default(string)}");
        }
    }
}
