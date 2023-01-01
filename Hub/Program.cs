using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSignalR();

var app = builder.Build();
app.MapHub<ChatHub>("/chatHub");

app.UseWebSockets();

app.Run();

public class ChatHub : Hub
{
    public async Task SendMessage(string message)
    {
        await Clients?.All.SendAsync("ReceiveMessage", message);
    }
}