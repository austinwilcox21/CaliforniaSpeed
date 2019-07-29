using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

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
                updatePlayableCards();
                if (ValidateMove(player,endPos))
                {
                    // Relay information back to clients to the function ReceiveGame in site.js
                    

                    MyGame.MyDeck.PlayerOneHand[0].Position = endPos;
                    MyGame.MyDeck.CardsInGame.Insert(endPos - 1, MyGame.MyDeck.PlayerOneHand[0]);
                    MyGame.MyDeck.CardsInGame.RemoveAt(endPos);
                    MyGame.MyDeck.PlayerOneHand.RemoveAt(0);
                    var JsonGame = JsonConvert.SerializeObject(MyGame);
                    await Clients.All.SendAsync("ReceiveGame", JsonGame);
                }
            }
        }

        private void updatePlayableCards()
        {
            foreach (Card card in MyGame.MyDeck.CardsInGame)
            {
                int counter = 0;
                List<Card> matches = new List<Card>();
                matches.Add(card);
                foreach (Card compareCard in MyGame.MyDeck.CardsInGame)
                {
                    if (card.FaceValue == compareCard.FaceValue)
                    {
                        counter++;
                        matches.Add(compareCard);
                    }
                }
                if (counter > 1)
                {
                    foreach (Card match in matches)
                    {
                        match.CanBePlayedOn = true;
                    }
                }
            }
        }

        private bool ValidateMove(int player, int endPos)
        {
            //MyGame.MyDeck.CardsInGame[endPos - 1].CanBePlayedOn = true;
            if (MyGame.MyDeck.CardsInGame[endPos - 1].CanBePlayedOn == true)
            {
                return true;
            }
            return false;
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