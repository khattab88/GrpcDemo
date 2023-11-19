using Grpc.Net.Client;
using Server;

namespace Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Greeter.GreeterClient(channel);

            var request = new HelloRequest { Name = "gRPC Demo" };
            var response = await client.SayHelloAsync(request);

            Console.Out.WriteLine(response.Message);

            Console.ReadLine();
        }
    }
}