using Grpc.Net.Client;
using Server;

namespace Client
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            #region Grreet Service

            //var channel = GrpcChannel.ForAddress("https://localhost:5001");
            //var client = new Greeter.GreeterClient(channel);

            //var request = new HelloRequest { Name = "gRPC Demo" };
            //var response = await client.SayHelloAsync(request);

            //Console.Out.WriteLine(response.Message);

            #endregion


            var channel = GrpcChannel.ForAddress("https://localhost:5001");
            var client = new Customer.CustomerClient(channel);

            Console.Out.WriteLine("Enter Customer Id:");
            int id = Convert.ToInt32(Console.ReadLine());

            var request = new CustomerLookupModel() { UserId = id };
            var response = await client.GetCustomerInfoAsync(request);

            Console.Out.WriteLine($"Customer# {response.Id}: {response.FirstName} {response.LastName}");


            Console.Out.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
    }
}