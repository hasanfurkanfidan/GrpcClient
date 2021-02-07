using Grpc.Net.Client;
using GrpcService;
using System;

namespace GrpcClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001/");
            var greetClient = new Greeter.GreeterClient(channel);
            var a =  greetClient.SayHello(new HelloRequest() { Name = "Furkan" });
            Console.WriteLine(a.Message);
            Console.Read();
        }
    }
}
