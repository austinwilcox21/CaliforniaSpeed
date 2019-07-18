using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace TestWebSocketApplication
{
    public class Chathub: Hub
    {
        public async Task SendMessage(string user, string message)
        {
            // Relay information back to clients to the function ReceiveMessage in site.js
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        
        public async Task MoveCard(string startPosition, string endPosition)
        {
            // TODO: IMPLEMENT THE GAME LOGIC STARTING HERE (OR IN OTHER METHODS)
            
            // Relay information back to clients to the function ReceiveGame in site.js
            await Clients.All.SendAsync("ReceiveGame", startPosition, endPosition);
        }
    }
}