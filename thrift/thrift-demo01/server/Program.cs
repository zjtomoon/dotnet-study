// See https://aka.ms/new-console-template for more information

using Thrift;
using Thrift.Processor;
using Thrift.Protocol;
using Thrift.Server;
using Thrift.Transport.Server;

namespace server
{
    class server 
    {
        public static void Main(string[] args)
        {
            Console.Title = "Thrift服务端-server";
            // TConfiguration config = new TConfiguration();
            // TODO: handle nullpointer exception
            TServerSocketTransport serverTransport = new TServerSocketTransport(8080, null, 0);
            TheUserService userService = new TheUserService();
            UserService.AsyncProcessor processor = new UserService.AsyncProcessor(userService);
            TProtocolFactory inputProtocolFactory = null;
            TProtocolFactory outputProtocolFactory = null;
            TSimpleAsyncServer server = new TSimpleAsyncServer(processor,serverTransport,inputProtocolFactory,outputProtocolFactory,null);
            Console.WriteLine("启动服务端，监听端口8080...");
            server.ServeAsync(new CancellationToken());
        }
    }
}