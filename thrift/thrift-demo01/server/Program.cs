// See https://aka.ms/new-console-template for more information

using Microsoft.Extensions.Logging;
using Thrift;
using Thrift.Processor;
using Thrift.Protocol;
using Thrift.Server;
using Thrift.Transport.Server;

namespace server
{
    class server 
    {
        async public static Task Main(string[] args)
        {
            Console.Title = "Thrift服务端-server";
            // TConfiguration config = new TConfiguration();
            // TODO: handle nullpointer exception
            TServerSocketTransport serverTransport = new TServerSocketTransport(8080, null, 0);
            TheUserService userService = new TheUserService();
            UserService.AsyncProcessor processor = new UserService.AsyncProcessor(userService);
            TProtocolFactory inputProtocolFactory = new TBinaryProtocol.Factory();
            TProtocolFactory outputProtocolFactory = new TBinaryProtocol.Factory();
            LoggerFactory logger = new LoggerFactory();
            TSimpleAsyncServer server = new TSimpleAsyncServer(processor,serverTransport,inputProtocolFactory,outputProtocolFactory,logger);
            Console.WriteLine("启动服务端，监听端口8080...");
            await server.ServeAsync(new CancellationToken());
        }
    }
}