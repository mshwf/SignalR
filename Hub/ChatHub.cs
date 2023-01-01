using Microsoft.AspNetCore.SignalR;

public class ChatHub : Hub
{
    public async Task SendMessage(string message)
    {
        await Clients.Others.SendAsync("ReceiveMessage", message);
    }
}