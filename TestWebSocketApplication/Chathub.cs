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

        public async Task SendMessage(string user)
        {
            // Relay information back to clients to the function ReceiveMessage in site.js
            //TODO
            //Check this and see if this will work

            var playerAssignment = MyGame.GetPlayerAssignment();
            if(playerAssignment == 1)
            {
                MyGame.PlayerOnesName = user;
            }
            else if(playerAssignment == 2)
            {
                MyGame.PlayerTwosName = user;
            }

            await Clients.All.SendAsync("ReceiveMessage", user, playerAssignment);
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
                if (ValidateMove(player,endPos))
                {
                    try
                    {
                        if (player == 1)
                        {
                            MyGame.MyDeck.PlayerOneHand[0].Position = endPos;
                            MyGame.MyDeck.CardsInGame.Insert(endPos - 1, MyGame.MyDeck.PlayerOneHand[0]);
                            MyGame.MyDeck.PlayerOneStack.Add(MyGame.MyDeck.CardsInGame[endPos - 1]);
                            MyGame.MyDeck.CardsInGame.RemoveAt(endPos);
                            MyGame.MyDeck.PlayerOneHand.RemoveAt(0);
                        }
                        else if (player == 2)
                        {
                            MyGame.MyDeck.PlayerTwoHand[0].Position = endPos;
                            MyGame.MyDeck.CardsInGame.Insert(endPos - 1, MyGame.MyDeck.PlayerTwoHand[0]);
                            MyGame.MyDeck.PlayerTwoStack.Add(MyGame.MyDeck.CardsInGame[endPos]);
                            MyGame.MyDeck.CardsInGame.RemoveAt(endPos);
                            MyGame.MyDeck.PlayerTwoHand.RemoveAt(0);
                        }

                        //This is where we call the win event and handle that
                        //TODO
                        if (MyGame.MyDeck.PlayerOneHand.Count == 0)
                        {
                            MyGame.IsGameOver = true;
                            await Clients.All.SendAsync("GameIsOver", $"{MyGame.PlayerOnesName} Wins!");
                        }
                        else if (MyGame.MyDeck.PlayerTwoHand.Count == 0)
                        {
                            Console.WriteLine("Player Two wins");
                            MyGame.IsGameOver = true;
                            await Clients.All.SendAsync("GameIsOver", $"{MyGame.PlayerTwosName} Wins!");
                        }


                        var JsonGame = JsonConvert.SerializeObject(MyGame);
                        await Clients.All.SendAsync("ReceiveGame", JsonGame);
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("test");
                    }
                    // Relay information back to clients to the function ReceiveGame in site.js
                    
                }

                while(!updatePlayableCards())
                {
                    if(MyGame.MyDeck.PlayerOneHand.Count < 4)
                    {
                        MyGame.IsGameOver = true;
                        await Clients.All.SendAsync("GameIsOver", $"{MyGame.PlayerOnesName} Wins!");
                        break;
                    }
                    else if(MyGame.MyDeck.PlayerTwoHand.Count < 4)
                    {
                        MyGame.IsGameOver = true;
                        await Clients.All.SendAsync("GameIsOver", $"{MyGame.PlayerTwosName} Wins!");
                        break;
                    }

                    for(int i = 0; i < 4; i++)
                    {
                        MyGame.MyDeck.PlayerOneStack.Add(MyGame.MyDeck.CardsInGame[i]);
                    }
                    for (int i = 4; i < 8; i++)
                    {
                        MyGame.MyDeck.PlayerTwoStack.Add(MyGame.MyDeck.CardsInGame[i]);
                    }

                    for(int i = 0; i < 8; i++)
                    {
                        MyGame.MyDeck.CardsInGame.RemoveAt(0);
                    }

                    foreach(var item in MyGame.MyDeck.PlayerOneStack)
                    {
                        MyGame.MyDeck.PlayerOneHand.Add(item);
                    }

                    foreach (var item in MyGame.MyDeck.PlayerTwoStack)
                    {
                        MyGame.MyDeck.PlayerTwoHand.Add(item);
                    }

                    MyGame.MyDeck.PlayerTwoStack.Clear();
                    MyGame.MyDeck.PlayerOneStack.Clear();

                    //for(int j = 4; j < 8; j++)
                    //{
                    //    MyGame.MyDeck.CardsInGame.RemoveAt(j);
                    //}
                    MyGame.MyDeck.Deal();

                    var JsonGame = JsonConvert.SerializeObject(MyGame);
                    await Clients.All.SendAsync("ReceiveGame", JsonGame);
                }
            }
        }
        
        private Boolean updatePlayableCards()
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

            // This is set to true if there is at least one match
            foreach (Card card in MyGame.MyDeck.CardsInGame)
            {
                if (card.CanBePlayedOn == true)
                {
                    return true;
                }
            }
            return false;
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
            try{
                string testToFail = MyGame.PlayerOnesName;

                if(MyGame.IsGameOver)
                {
                    MyGame = new Game();
                    MyGame.MyDeck.Deal();

                    MyGame.PlayerOnesName = "";
                    MyGame.PlayerTwosName = "";
                }
            }
            catch(Exception){
                MyGame = new Game();
                MyGame.MyDeck.Deal();
            }

            // initial check to see if cards are playable
            while (!updatePlayableCards())
            {
                // there are no more cards left to play. time to reshuffle.

                Console.WriteLine("Time to reshuffle...");
                if (MyGame.MyDeck.PlayerOneHand.Count < 4)
                {
                    MyGame.IsGameOver = true;
                    await Clients.All.SendAsync("GameIsOver", $"{MyGame.PlayerOnesName} Wins!");
                    break;
                }
                else if (MyGame.MyDeck.PlayerTwoHand.Count < 4)
                {
                    MyGame.IsGameOver = true;
                    await Clients.All.SendAsync("GameIsOver", $"{MyGame.PlayerTwosName} Wins!");
                    break;
                }

                for (int i = 0; i < 8; i++)
                {
                    MyGame.MyDeck.CardsInGame.RemoveAt(0);
                }

                //for(int j = 4; j < 8; j++)
                //{
                //    MyGame.MyDeck.CardsInGame.RemoveAt(j);
                //}
                MyGame.MyDeck.Deal();

                var myJsonGame = JsonConvert.SerializeObject(MyGame);
                await Clients.All.SendAsync("ReceiveStartGame", myJsonGame);
            }

            var JsonGame = JsonConvert.SerializeObject(MyGame);

            await Clients.All.SendAsync("ReceiveStartGame", JsonGame);
        }
    }
}