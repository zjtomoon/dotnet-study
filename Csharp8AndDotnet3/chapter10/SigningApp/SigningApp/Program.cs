﻿using System;
using Packt.Shared;
using static System.Console;

namespace SigningApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("Enter some text to sign :");
            string data = ReadLine();
            var signature = Protector.GenerateSignature(data);
            WriteLine($"Signature: {signature}");
            WriteLine("Public key used to check signature: ");
            WriteLine(Protector.PublicKey);
            if (Protector.ValidateSignature(data,signature))
            {
                WriteLine("Correct! Signature is valid.");
            }
            else
            {
                WriteLine("Invalid signature.");
            }

            var fakeSignature = signature.Replace(signature[0], 'X');
            
            if (Protector.ValidateSignature(data,fakeSignature))
            {
                WriteLine("Correct! Signature is valid. ");
            }
            else
            {
                WriteLine($"Invalid signature : {fakeSignature}");
            }
        }
    }
}