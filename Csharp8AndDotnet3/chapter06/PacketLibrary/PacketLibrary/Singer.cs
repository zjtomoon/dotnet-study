using static System.Console;

namespace Packet.Shared
{
    public class Singer
    {
        public virtual void Sing()
        {
            WriteLine("Singing...");
        }
    }

    public class LadyGaga : Singer
    {
        //防止继承和覆盖：通过对方法应用sealed关键字，防止别人进一步覆盖自己类中的virtual方法
        public sealed override void Sing()
        {
            WriteLine("Singing with style...");
        }
    }
}