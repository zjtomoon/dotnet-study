using System;
using static System.Console;
using static System.Convert;

namespace castingConverting
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            double b = a;//an int can safely cast into a double
            WriteLine(b);

            double c = 9.8;
            // int d = c;
            int d = (int) c;
            WriteLine(d);//9

            long e = 10;
            int f = (int) e;
            WriteLine($"e is {e:N0} and f is {f:N0}");
            e = long.MaxValue;
            f = (int) e; 
            WriteLine($"e is {e:N0} and f is {f:N0}");
            
            WriteLine("======================");
            double g = 9.8;
            int h = ToInt32(g);
            WriteLine($"g is {g} and h is {h}");//可以看出，double9.8被转换并圆整为10，而不是去掉小数点后的部分。
            
            //默认圆整规则：小数部分大于等于0.5,向上圆整;小数部分小于0.5,则向下圆整。
            double[] doubles = new[]{9.49,9.5,9.51,10.49,10.5,10.51};
            foreach(double n in doubles)
            	{
            		WriteLine($"ToInt ({n}) is {ToInt32(n)}");
            	}
            WriteLine("===================");
            //控制圆整规则
            foreach (double n in doubles)
						{
							WriteLine(format:
									"Math.Round({0},0,MidpointRounding.AwayFromZero) is {1}",
									arg0: n,
									arg1: Math.Round(value:n,
										digits: 0,
										mode: MidpointRounding.AwayFromZero
										)
									);
						}
						//从任何类型转换为字符串ToString()
						WriteLine("====================");
						int number = 12;
						WriteLine(number.ToString());
						bool boolean = true;
						WriteLine(boolean.ToString());
						DateTime now = DateTime.Now;
						WriteLine(now.ToString());
						object me = new object();
						WriteLine(me.ToString());
						WriteLine("==================");
						//从二进制对象转换为字符串ToBase64String、FromBase64String
						byte[] binaryObject = new byte[128];
						(new Random()).NextBytes(binaryObject);
						WriteLine("Binary object as bytes");
						for(int index = 0 ; index < binaryObject.Length; index++)
						{
							Write($"{binaryObject[index]:x} ");
						}
						WriteLine();
						string encoded = Convert.ToBase64String(binaryObject);
						WriteLine($"Binary object as Base64: {encoded}");
						WriteLine("=====================");
						//将字符串转换为数字或日期和时间
						int age = int.Parse("27");
						DateTime birthday = DateTime.Parse("4 July 1980");
						WriteLine($"I was born {age} years ago.");
						WriteLine($"My birthday is birthday.");
						WriteLine($"My birthday is {birthday:D}.");
						//默认情况下，，日期和时间输出为短日期格式。可以使用诸如D的格式代码，
						//仅输出使用了长日期格式的日期部分。

						//使用TyrParse方法避免异常
						Write("How many eggs are there?");
						int count;
						string input = ReadLine();
						if (int.TryParse(input,out count))
						{
							WriteLine($"There are {count} eggs");//12
						}
						else
						{
							WriteLine("I could not parse the input.");//twelve
						}
				}
		}
}
