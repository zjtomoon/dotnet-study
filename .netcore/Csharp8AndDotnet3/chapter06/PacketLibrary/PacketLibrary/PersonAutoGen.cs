using System;
using System.Collections.Generic;
using static System.Console;

namespace Packet.Shared
{
    public partial class Person : IComparable<Person>
    {
        /*public string Orgin
        {
            get { return $"{Name} was born on {HomePlanet}"; }
        }
        public string FavouriteIceCream
        {
            get;
            set;
        }

        //定义可设置的属性
        public string favouritePrimaryColor;
        public string FavouritePrimaryColor
        {
            get
            {
                return favouritePrimaryColor;
            }

            set
            {
                switch (value.ToLower())
                {
                    case "red":
                    case "green":
                    case "blue":
                        favouritePrimaryColor = value;
                        break;
                    default:
                        throw new System.ArgumentException($"{value} is not a primary color." +
                            "Choose from :red,green,blue");
                }
            }
        }

        public List<Person> Children = new List<Person>();
        //定义索引器
        public Person this[int index]
        {
            get
            {
                return Children[index];
            }
            set
            {
                Children[index] = value;
            }
        }*/

        public string Name;
        public DateTime DateOfBirth;
        public List<Person> Children = new List<Person>();
        //methods
        public void WriteToConsole()
        {
            WriteLine($"{Name} was born on a {DateOfBirth:dddd}");
        }
        
        //static method to "multiply"
        public static Person Procreate(Person p1, Person p2)
        {
            var baby = new Person()
            {
                Name = $"Baby of {p1.Name} and {p2.Name}"
            };
            p1.Children.Add(baby);
            p2.Children.Add(baby);

            return baby;
        }

        //instance method to "multiply"
        public Person ProcreateWith(Person partner)
        {
            return Procreate(this, partner);
        }
        public static Person operator *(Person p1, Person p2)
        {
            return Person.Procreate(p1, p2);
        }
        
        //使用局部变量的方法
        public static int Factorial(int number)
        {
            if (number < 0)
            {
                throw new ArgumentException($"{nameof(number)} can not be less than zeor");
            }

            return localFactorial(number);

            int localFactorial(int localNumber)
            {
                if (localNumber < 1) return 1;
                return localNumber * localFactorial(localNumber - 1);
            }
        }

        public int MethodIWantToCall(string input)
        {
            return input.Length;
        }
        
        //定义和处理委托
        //public EventHandler Shout;
        //定义和处理事件
        public event EventHandler Shout;

        public int AngerLevel;

        
        public void Poke()
        {
            AngerLevel++;
            if (AngerLevel >= 3)
            {
                if (Shout != null)
                {
                    Shout(this,EventArgs.Empty);
                }
            }
        }

        public int CompareTo(Person other)
        {
            return Name.CompareTo(other.Name);//按姓名的字母顺序排序
        }

        public void TimeTravel(DateTime when)
        {
            if (when <= DateOfBirth)
            {
                throw new PersonException(
                    "If you travel back in time to a date earlier than your own birth,then the universe will explode!");
            }
            else
            {
                WriteLine($"Welcome to {when:yyyy} !");
            }
        }
    }

    public class PersonComparer : IComparer<Person> //首先用最短的姓名对人员进行排序
    {
        public int Compare(Person x, Person y)
        {
            int result = x.Name.Length.CompareTo(y.Name.Length);
            if (result == 0)
            {
                return x.Name.CompareTo(y.Name);
            }
            else
            {
                return result;
            }
        }
    }
}