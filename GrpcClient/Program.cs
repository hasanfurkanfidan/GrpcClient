using Grpc.Net.Client;
using GrpcMessageService;
using GrpcService;
using System;

namespace GrpcClient
{
    class Program
    {
        static void Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001/");
            //var greetClient = new Greeter.GreeterClient(channel);
            //var a =  greetClient.SayHello(new HelloRequest() { Name = "Furkan" });
            var messageClient = new Message.MessageClient(channel);
            var result = messageClient.SendMessage(new MessageRequest
            {
                Message = "Naber",
                Name = "Furkan"
            });
            Console.WriteLine(result.Message);
            Console.Read();
        }
    }
}
