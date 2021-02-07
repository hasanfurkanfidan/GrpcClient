using Grpc.Core;
using Grpc.Net.Client;
using GrpcMessageService;
using GrpcService;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GrpcClient
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = GrpcChannel.ForAddress("https://localhost:5001/");
            //var greetClient = new Greeter.GreeterClient(channel);
            //var a =  greetClient.SayHello(new HelloRequest() { Name = "Furkan" });
            var messageClient = new Message.MessageClient(channel);
            //var result = messageClient.SendMessageStream(new MessageRequest
            //{
            //    Message = "Naber",
            //    Name = "Furkan"
            //});
            //CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            //while ( result.ResponseStream.MoveNext(cancellationTokenSource.Token).Result)
            //{
            //    System.Console.WriteLine(result.ResponseStream.Current.Message);
            //}
            //var messageClient = new Message.MessageClient(channel);

            //var request = messageClient.SendMessageStreamFromClient();
            //for (int i = 0; i < 10; i++)
            //{
            //   await request.RequestStream.WriteAsync(new MessageRequest { Name = "Furkan", Message = "Naber" });
            //}
            //await request.RequestStream.CompleteAsync();

            //var response =await  request.ResponseAsync;
            //Console.WriteLine(response.Message);
            //Console.Read();
            var result = messageClient.SendMessageStreamBiDirectioanal();
          
                for (int i = 0; i < 10; i++)
                {
                    await result.RequestStream.WriteAsync(new MessageRequest { Name = "Furkan", Message = "Naber" });
                }
            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
            while (await result.ResponseStream.MoveNext(cancellationTokenSource.Token))
            {
                System.Console.WriteLine(result.ResponseStream.Current.Message);
            }
            Console.Read();
        }
    }
}
