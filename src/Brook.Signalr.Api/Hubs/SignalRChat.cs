using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace Brook.Signalr.Api.Hubs
{
    public class SignalRChat : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}
