using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
                if (ValidateMove())
                {
                    // Relay information back to clients to the function ReceiveGame in site.js
                    int endPos = 0;
                    switch (endPosition)
                    {
                        case "pos1":
                            endPos = 1;
                            break;
                        case "pos2":
                            endPos = 2;
                            break;
                        case "pos3":
                            endPos = 3;
                            break;
                        case "pos4":
                            endPos = 4;
                            break;
                        case "pos5":
                            endPos = 5;
                            break;
                        case "pos6":
                            endPos = 6;
                            break;
                        case "pos7":
                            endPos = 7;
                            break;
                        case "pos8":
                            endPos = 8;
                            break;
                        default:
                            break;
                    }
                    MyGame.MyDeck.PlayerOneHand[0].Position = endPos;
                    MyGame.MyDeck.CardsInGame.Insert(endPos - 1, MyGame.MyDeck.PlayerOneHand[0]);
                    MyGame.MyDeck.CardsInGame.RemoveAt(endPos);
                    MyGame.MyDeck.PlayerOneHand.RemoveAt(0);
                    var JsonGame = JsonConvert.SerializeObject(MyGame);
                    await Clients.All.SendAsync("ReceiveGame", JsonGame);
                }
            }
        }

        private bool ValidateMove()
        {
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
            MyGame.MyDeck.Deal();

            var JsonGame = JsonConvert.SerializeObject(MyGame);

            await Clients.All.SendAsync("ReceiveStartGame", JsonGame);
        }
    }
}