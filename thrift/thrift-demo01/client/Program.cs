using Thrift.Protocol;
using Thrift.Transport;
using Thrift.Transport.Client;

namespace client
{
    class client
    {
        async public static Task Main(string[] args)
        {
            Console.Title = "Thrift客户端-Client";
            TTransport transport = new TSocketTransport("127.0.0.1", 8080, null, 0);
            TProtocol protocol = new TBinaryProtocol(transport);
            UserService.Client client = new UserService.Client(protocol);
            // await transport.OpenAsync();
            var user = client.GetUserByID(1);
            Console.WriteLine("------------------");
            Console.WriteLine(string.Format("User ID : {0}, User Name {1}", user.Result.ID, user.Result.Name));
            Console.ReadLine();
        }
    }
}

