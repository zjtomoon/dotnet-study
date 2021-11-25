using System;

namespace Packet.Shared
{
    //释放非托管资源
    public class Animal : IDisposable
    {
        public Animal()
        {
            
        }

        //每个类型都有终结器，当需要释放资源时，.NET运行时将调用终结器。终结器与构造函数同名，但终结器的前面有波浪号~
        ~Animal()
        {
            if (disposed) return;
            Dispose(false);
        }

        private bool disposed = false;

        public void Dispose() //公有的Dispose方法将由使用类型的开发人员调用。在调用时，需要释放非托管资源和托管资源
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)//带有bool参数的受保护的Dispose方法在内部用于实现资源的重新分配。
        {
            if (disposed) return;
            if (disposing)
            {
                //    
            }

            disposed = true;
        }
    }
}