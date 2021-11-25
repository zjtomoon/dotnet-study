using System;
using static System.Console;

namespace mathFunction
{
    class Program
    {
				static string CardinalToOrdinal(int number)
				{
					switch (number)
					{
						case 11:
						case 12:
						case 13:
							return $"{number}th";
						default:
							string numberAsText = number.ToString();
							char lastDigit = numberAsText[numberAsText.Length - 1];
							string suffix = string.Empty;

							switch (lastDigit)
							{
								case '1':
									suffix = "st";
									break;
								case '2':
									suffix = "nd";
									break;
								case '3':
									suffix = "rd";
									break;
								default:
									suffix = "th";
									break;
							}
							return $"{number} {suffix}";
					}
				}
				static void RunCardinalToOridinal()
				{
					for (int number = 1; number <= 40; number++)
					{
						Write($"{CardinalToOrdinal(number)} ");
					}
					WriteLine();
				}
				static int Factorial(int number)
				{
					if (number < 1)
					{
						return 0;
					}
					else if ( number == 1 )
					{
						return 1;
					}
					else
					{
						return number * Factorial(number - 1);
					}
				}
				static void RunFactorial()
				{
					bool isNumber;
					do
					{
						Write("Enter a number:");

						isNumber = int.TryParse(
								ReadLine(),out int number
								);
						if (isNumber)
						{
							WriteLine(
									$"{number:N0} != {Factorial(number):N0}"
									);
						}
						else
						{
							WriteLine("You did not enter a valid number!");
						}
					}
					while (isNumber);
				}
        static void Main(string[] args)
        {
        	//RunCardinalToOridinal();
        	RunFactorial();
        }
    }
}
