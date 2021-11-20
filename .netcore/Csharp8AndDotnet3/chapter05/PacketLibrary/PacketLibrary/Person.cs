using System;

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
    }
    public class BankAccount
    {
        public string AccountName;
        public decimal Balance;
        public static decimal InterestRate;
    }
}
