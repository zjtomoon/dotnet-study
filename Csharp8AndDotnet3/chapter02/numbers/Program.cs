using System;

namespace numbers
{
    class Program
    {
        static void Main(string[] args)
        {
        	/*
            uint naturalNumber = 23;
            int integerNumber = -23;
            float realNumber = 2.3F;
            double anotherRealNumber = 2.3;
          */
          int decimalNotation = 2_000_000;
          int binaryNotation = 0b_0001_1110_1000_0100_1000_0000;
          int hexadecimalNotion = 0x_001E_8480;
          Console.WriteLine($"{decimalNotation == binaryNotation}");
          Console.WriteLine($"{decimalNotation == hexadecimalNotion}");


          //Console.WriteLine($"int uses {sizeof(int)} bytes and can store numbers in the range {int.MinValue:N0} to {int.MaxValue:N0}.");

          //Console.WriteLine($"double uses {sizeof(double)} bytes and can store numbers in the range {double.MinValue:N0} to {double.MaxValue:N0}.");

          //Console.WriteLine($"int uses {sizeof(decimal)} bytes and can store numbers in the range {decimal.MinValue:N0} to {decimal.MaxValue:N0}.");


          Console.WriteLine("=========================================================================");
          Console.WriteLine("use double:");
          double a = 0.1;
          double b = 0.2;
          if(a + b == 0.3)
					{
						Console.WriteLine($"{a} + {b} equals 0.3");
					}
					else
					{
						Console.WriteLine($"{a} + {b} does not equals 0.3");
					}
					//结论：double类型不能保证值是精确的，，因为有些数字不能表示为浮点值。
					//double 类型有一些有用的特殊值：double.NaN表示不是数字，double.Epsilon是可以存储在double里的最小正数，double.Infinity意味着无限大的值。
					Console.WriteLine("use decimal:");
					decimal c = 0.1M;
					decimal d = 0.2M;

					if( c + d == 0.3M )
					{
						Console.WriteLine($"{c} + {d} equals 0.3");
					}
					else
					{
						Console.WriteLine($"{c} + {d} does not equals 0.3");
					}
					//decimal类型是精确的，因为这种类型可以将数字存储为大的整数并移动小数点。
					//decimal类型适合于货币、CAD绘图、一般工程学以及任何对实数的准确性要求较高的场合。

					Console.WriteLine("==========================================================================");
					dynamic anotherName = "Ahmed";
					int length = anotherName.Length;
					Console.WriteLine($"the length of anotherName is {length}");

		}
	}
}
