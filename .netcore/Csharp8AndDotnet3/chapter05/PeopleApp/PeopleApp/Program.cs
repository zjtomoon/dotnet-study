using System;
using static System.Console;
using Packet.Shared;


namespace PeopleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
/*
            var bob = new Person();
            WriteLine(bob.ToString());
*/
            var bob = new Person();
            bob.Name = "Bob Smith";
            bob.DateOfBirth = new DateTime(1965, 12, 22);
            bob.FavouriteAncientWonder = WondersOfTheAcientWorld.StatueOfZeusAtOlympia;
            bob.BucketList = WondersOfTheAcientWorld.HangingGardensOfBabylon | WondersOfTheAcientWorld.MausoleumAtHalicarnassus;

            WriteLine($"{bob.Name}'s bucket list is {bob.BucketList}");

            WriteLine(
                //format: "{0}  was born on {1:dddd, d MMMM yyyy}",
                format: "{0} 's favourite is {1}. It's integer is {2}.",
                arg0:bob.Name,
                //arg1:bob.DateOfBirth
                arg1:bob.FavouriteAncientWonder,
                arg2:(int)bob.FavouriteAncientWonder);

            var alice = new Person
            {
                Name = "Alice Jones",
                DateOfBirth = new DateTime(1998, 3, 7)
            };


            WriteLine(
                format: "{0} was born on {1:dd MMM yy}",
                arg0: alice.Name,
                arg1: alice.DateOfBirth);

            WriteLine("==========================");

            BankAccount.InterestRate = 0.012M;

            var jonesAccount = new BankAccount();
            jonesAccount.AccountName = "Mrs. Jones";
            jonesAccount.Balance = 2400;

            WriteLine(format: "{0} earned {1:C}  interest.",
                arg0:jonesAccount.AccountName,
                arg1:jonesAccount.Balance * BankAccount.InterestRate);
            
            var gerrierAccount = new BankAccount();
            gerrierAccount.AccountName = "Ms. Gerrier";
            gerrierAccount.Balance = 98;

            WriteLine(format: "{0} earned {1:C} interest.",
                arg0: gerrierAccount.AccountName,
                arg1: gerrierAccount.Balance * BankAccount.InterestRate);

            WriteLine($"{bob.Name} is a {Person.Species}");

            WriteLine($"{bob.Name} was born on {bob.HomePlanet}");

            var blankPerson = new Person();
            WriteLine(format:
                "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}.",
                arg0:blankPerson.Name,
                arg1:blankPerson.HomePlanet,
                arg2:blankPerson.Instantiated);
            

            var gunny = new Person("Gunny", "Mars");
            WriteLine(format:
            "{0} of {1} was created at {2:hh:mm:ss} on a {2:dddd}",
            arg0:gunny.Name,
            arg1:gunny.HomePlanet,
            arg2:gunny.Instantiated);
        }
    }
}
