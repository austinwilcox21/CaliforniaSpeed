using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;

namespace TestWebSocketApplication
{
    public class Chathub: Hub
    {
        public static Game MyGame;

        public async Task SendMessage(string user, string message)
        {
            // Relay information back to clients to the function ReceiveMessage in site.js
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        
        public async Task MoveCard(int player, string endPosition)
        {
            // TODO: IMPLEMENT THE GAME LOGIC STARTING HERE (OR IN OTHER METHODS)
            
            if (MyGame != null)
            {
                if (ValidateMove(player,endPosition))
                {
                    // Relay information back to clients to the function ReceiveGame in site.js
                   Int32.TryParse(endPosition, out int endPos);
                    MyGame.MyDeck.PlayerOneHand[0].Position = endPos;
                    var JsonGame = JsonConvert.SerializeObject(MyGame);
                    await Clients.All.SendAsync("ReceiveGame", JsonGame);
                }
            }
        }

        private bool ValidateMove(int player, string endPosition)
        {
            if (MyGame.MyDeck.CardsInGame[endPosition].CanBePlayedOn == false)
                return true;
            return true;
            //return false;
        }

        /// <summary>
        /// Starts Game by creating a new deck object and sending it to the client
        /// </summary>
        /// <returns></returns>
        public async Task StartGame()
        {
            MyGame = new Game();
            Game.MyDeck.Deal();

            var JsonGame = JsonConvert.SerializeObject(MyGame);

            await Clients.All.SendAsync("ReceiveStartGame", JsonGame);
        }
    }
}