using System;

namespace GenerateRandomPasswd
{
    class Program
    {
        static void Main(string[] args)
        {
            int length = 24;

            string password1 = GenerateRandomPasswd.GenerateRandomCryptPasswd(length);
            Console.WriteLine(password1);

            string password2 = GenerateRandomPasswd.GetRandomPassword(length);
            Console.WriteLine(password2);
        }
    }
}

