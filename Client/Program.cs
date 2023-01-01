using Microsoft.AspNetCore.SignalR.Client;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();


        app.MapGet("/", () => "Hello World!");

        var connection = new HubConnectionBuilder()
                    .WithUrl("https://localhost:7096/chatHub")
                    .Build();


        connection.On("ReceiveMessage", (string message) => Console.WriteLine(message));

        await connection.StartAsync();

        await connection.InvokeAsync("SendMessage", "Hello World agian");
        app.Run();
    }
}