using static System.Console;

namespace Packet.Shared
{
    public interface IPlayable
    {
        void Play();
        void Pause();

        void Stop()
        {
            WriteLine("Default implementation of stop.");
        }
    }
}