using System.Collections.Generic;

namespace Packet.Shared
{
    public partial class Person
    {
        public string Orgin
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
        }
    }
}