using System;
using static System.Console;

namespace Packet.Shared
{
    public class Person 
    {
        public string Name;
        public DateTime DateOfBirth;
        public WondersOfTheAcientWorld FavouriteAncientWonder;
        public WondersOfTheAcientWorld BucketList;

        public const string Species = "Homo Sapien";

        public readonly string HomePlanet = "Earth";
        public readonly DateTime Instantiated;

        public Person()
        {
            Name = "UnKnown";
            Instantiated = DateTime.Now;
        }

        public Person(string initialName, string homePlanet)
        {
            Name = initialName;
            HomePlanet = homePlanet;
            Instantiated = DateTime.Now;
        }
    }
    public class BankAccount
    {
        public string AccountName;
        public decimal Balance;
        public static decimal InterestRate;
    }
}
