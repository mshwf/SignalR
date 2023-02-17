using Microsoft.AspNetCore.SignalR;

public class ChatHub : Hub
{
    public async Task SendMessage(string message, string user)
    {
        await Clients.Others.SendAsync("ReceiveMessage", message, user);
    }
}