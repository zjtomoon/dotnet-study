using System;

namespace readlineTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type your first name and press Enter");
            string firstName = Console.ReadLine();

						Console.WriteLine("Type your age and press Enter");
						string age = Console.ReadLine();

						Console.WriteLine($"Hello {firstName},you look good for {age}");
        }
    }
}
