using Microsoft.AspNetCore.SignalR.Client;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var connection = new HubConnectionBuilder()
                    .WithUrl("https://localhost:7096/chatHub")
                    .Build();


        connection.On("ReceiveMessage", (string message) => Console.WriteLine(message));

        await connection.StartAsync();
        Console.WriteLine("Write your message:");
        do
        {
            var message = Console.ReadLine();
            await connection.InvokeAsync("SendMessage", message);
        } while (true);
    }
}