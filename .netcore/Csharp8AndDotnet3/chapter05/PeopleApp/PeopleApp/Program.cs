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

        }
    }
}
