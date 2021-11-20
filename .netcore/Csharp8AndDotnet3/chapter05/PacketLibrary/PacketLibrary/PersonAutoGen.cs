namespace Packet.Shared
{
    public partial class Person
    {
        public string Orgin
        {
            get { return $"{Name} was born on {HomePlanet}"; }
        }
    }
}