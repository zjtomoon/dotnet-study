using System;

namespace writeTest
{
    class Program
    {
        static void Main(string[] args)
        {
        	int numberOfApples = 12;
        	decimal pricePerApple = 0.35M;
					Console.WriteLine(
							format: "{0} apples costs {1:C}",
							arg0: numberOfApples,
							arg1: pricePerApple * numberOfApples
							);
					Console.WriteLine("====================");
					string formatted = string.Format(
							format: "{0} apples costs {1:C}",
							arg0: numberOfApples,
							arg1: pricePerApple * numberOfApples
							);
					Console.WriteLine(formatted);

					Console.WriteLine("====================");

					Console.WriteLine($"{numberOfApples} apples costs {pricePerApple * numberOfApples:C}");
					/*
					 * C#6.0及后续版本有一个方便的特性叫做内插字符串。以$为前缀的字符串可以在变量或表达式
					 * 的名称两边使用花括号，，从而输出变量或者表达式在字符串中相应位置的当前值。
					 */

					/*
					 *C格式的字符串表示货币、N0格式的字符串表示有千位分隔符且没有小数点的数字。
					 */ 

					Console.WriteLine("====================");
					string applesText = "Apples";
					int applesCount = 1234;
					string bananaText = "Bananas";
					int bananaCount = 56789;
					Console.WriteLine(
							format: "{0,-8} {1,6:N0}",
							arg0: "Name",
							arg1: "Count"
							);
					Console.WriteLine(
							format: "{0,-8} {1,6:N0}",
							arg0: applesText,
							arg1: applesCount
							);

					Console.WriteLine(
							format: "{0,-8} {1,6:N0}",
							arg0: bananaText,
							arg1: bananaCount
							);
        }
    }
}
