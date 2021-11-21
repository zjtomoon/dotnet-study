using System;
using System.Threading;

namespace Packet.Shared
{
    public static class Squarer
    {
    
        //使用泛型方法
        public static double Square<T>(T input) where T: IConvertible
        {
            double d = input.ToDouble(Thread.CurrentThread.CurrentCulture);
            return d * d;
        }
    }
}