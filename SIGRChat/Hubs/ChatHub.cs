using Microsoft.AspNetCore.SignalR; 

namespace SignalChat.Hubs 
{ 
    public class ChatHub_NET: Hub
    { 
        public async Task SendMessage(string user, string message)
        { 
            await Clients.All.SendAsync("ReceiveMessage", user, message); 
        }
    }
}