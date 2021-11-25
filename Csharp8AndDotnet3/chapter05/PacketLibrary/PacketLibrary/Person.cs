using System;
using static System.Console;

namespace Packet.Shared
{
    public partial class Person 
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
        
        //methods
        public void WriteToConsole()
        {
            WriteLine($"{Name} was born on a {DateOfBirth: dddd}.");
        }

        public string GetOrigin()
        {
            return $"{Name} was born on {HomePlanet}.";
        }

        public (string, int) GetFruit()
        {
            return ("Apple", 5);
        }

        public (string Name,int Number) GetNamedFruit()
        {
            return ( Name: "Apples", Number: 5);
        }

        public string SayHello()
        {
            return $"{Name} says 'Hello!'";
        }

        public string SayHelloTo(string name)
        {
            return $"{Name} says 'Hello {name} !'";
        }

        //创建一个带三个参数的方法
        public string OptionalParameters(      
            string command = "Run!",
            double number = 0.0,
            bool active = true)
        {
            return string.Format(format:"command is {0},number is {1},active is {2}",
                arg0: command,arg1: number,arg2: active);
        }
        
        //控制参数的传递方式
        public void PassingParameter(int x, ref int y, out int z)
        {
            z = 99;
            x++;
            y++;
            z++;
        }
    }
    public class BankAccount
    {
        public string AccountName;
        public decimal Balance;
        public static decimal InterestRate;
    }

    public class TextAndNumber
    {
        public string Text;
        public int Number;
    }
    public class Processor
    {
        public TextAndNumber GetAndNumber()
        {
            return new TextAndNumber
            {
                Text = "What's the meaning of life?",
                Number = 42
            };
        }
    }
}
