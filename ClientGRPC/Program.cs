using ClientGRPC;
using Grpc.Net.Client;

using (var channel = GrpcChannel.ForAddress("https://localhost:7047"))
{
    var client = new Beers.BeersClient(channel);
    var reply = await client.SayHelloAsync(new HelloRequest
    {
        Name = "Majo"
    });

    var reply2 = await client.GetAsync(new BeersRequest { });

    Console.WriteLine(reply.Message);

    foreach (var beer in reply2.Beers)
    {
        Console.WriteLine(beer);
    }
    Console.ReadKey();
}