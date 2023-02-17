using Microsoft.AspNetCore.SignalR.Client;

internal class Program
{
    private static HubConnection connection;

    private static async Task Main(string[] args)
    {
        Console.Title = "Client 2";
        connection = new HubConnectionBuilder()
            .WithUrl("https://localhost:7096/chatHub")
            .Build();


        connection.On("ReceiveMessage", async (string message, string from) =>
        {
            Console.WriteLine($"\n{from}: {message}");
        });

        await connection.StartAsync();
        do
        {
            await Prompt();
        } while (true);
    }

    private static async Task Prompt()
    {
        Console.Write("Me: ");
        var message = Console.ReadLine();
        await connection.InvokeAsync("SendMessage", message, "Client2");
    }
}