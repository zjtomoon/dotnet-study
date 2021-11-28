using System;
using System.Security.Cryptography;
using Packt.Shared;
using static System.Console;

namespace EncryptionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("Enter a message that you want to encrypt: ");
            string message = ReadLine();
            Write("Enter a password: ");
            string password = ReadLine();

            string cryptoText = Protector.Encrypt(message, password);
            WriteLine($"Encrypted text: {cryptoText}");
            Write("Enter the password: ");
            string password2 = ReadLine();

            try
            {
                string clearText = Protector.Decrypt(cryptoText, password2);
                WriteLine($"Decrypted text : {clearText}");
            }
            catch (CryptographicException ex)
            {
                WriteLine("{0}\nMore details: {1}",
                    arg0: "You entered the wrong password",
                    arg1: ex.Message);
            }
            catch (Exception ex)
            {
                WriteLine("Non-cryptographic exception: {0} , {1}",
                    arg0: ex.GetType().Name,
                    arg1: ex.Message);
            }
            
            WriteLine("Registering Alice with Pa$$0rd.");
            var alice = Protector.Register("Alice", "Pa$$w0rd");
            WriteLine($"Name : {alice.Name}");
            WriteLine($"Salt: {alice.Salt}");
            WriteLine("Password (salted and hashed): {0}",arg0: alice.SaltedHashedPassword);
            WriteLine();
            
            Write("Enter a new user to register:");
            string username = ReadLine();
            Write($"Enter a password for {username}:");
            string password3 = ReadLine();
            var user = Protector.Register(username, password3);
            WriteLine($"Name : {user.Name}");
            WriteLine($"Salt: {user.Salt}");
            WriteLine("Password (salted and hasherd): {0}",
                arg0: user.SaltedHashedPassword);
            WriteLine();

            bool correctPassword = false;
            while (!correctPassword)
            {
                Write("Enter a username to login: ");
                string loginUsername = ReadLine();
                Write("Enter a password to login: ");
                string loginPassword = ReadLine();
                correctPassword = Protector.CheckPassword(loginUsername, loginPassword);

                if (correctPassword)
                {
                    WriteLine($"Correct! {loginUsername} has been logged in.");
                }
                else
                {
                    WriteLine("Invalid username or password.Try again.");
                }
            }
        }
    }
}