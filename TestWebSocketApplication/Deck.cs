using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace TestWebSocketApplication
{
    public class Deck
    {
        [JsonProperty]
        public  List<Card> PlayerOneHand { get; set; }

        [JsonProperty]
        public List<Card> PlayerTwoHand { get; set; }

        [JsonProperty]
        public List<Card> CardsInGame { get; set; }

        public List<Card> PlayerOneStack { get; set; }
        public List<Card> PlayerTwoStack { get; set; }

        public const int NUMBER_CARDS = 52;
        public Random randomNum;

        public Deck()
        {
            PlayerOneHand = new List<Card>();
            PlayerTwoHand = new List<Card>();
            CardsInGame = new List<Card>();
            PlayerTwoStack = new List<Card>();
            PlayerOneStack = new List<Card>();

            string[] images =
            {
                "AH.png","2H.png","3H.png","4H.png","5H.png","6H.png","7H.png","8H.png","9H.png","10H.png","JH.png","QH.png","KH.png",
                "AC.png","2C.png","3C.png","4C.png","5C.png","6C.png","7C.png","8C.png","9C.png","10C.png","JC.png","QC.png","KC.png",
                "AD.png","2D.png","3D.png","4D.png","5D.png","6D.png","7D.png","8D.png","9D.png","10D.png","JD.png","QD.png","KD.png",
                "AS.png","2S.png","3S.png","4S.png","5S.png","6S.png","7S.png","8S.png","9S.png","10S.png","JS.png","QS.png","KS.png"
            };

            string[] faces =
            {
                "Ace","Two","Three", "Four", "Five","Six","Seven","Eight","Nine", "Ten",
                "Jack","Queen","King"
            };
            
            string[] suits = { "Hearts", "Clubs", "Diamonds", "Spades" };
            randomNum = new Random();

            List<Card> cards = new List<Card>();
            for (var count = 0; count < NUMBER_CARDS; count++)
            {
                
                cards.Add(new Card(images[count], suits[count / 13], faces[count % 13]));
            }
            
            Shuffle(cards);
            Split(cards);
        }

        private void Shuffle(List<Card> cards)
        {
            for (var first = 0; first < cards.Count; first++)
            {
                var second = randomNum.Next(NUMBER_CARDS);
                var temp = cards[first];
                cards[first] = cards[second];
                cards[second] = temp;
            }
        }

        private void Split(List<Card> cards)
        {
            var counter = 0;
            foreach (var item in cards)
            {
                if (counter < 26)
                {
                    PlayerOneHand.Add(item);
                }
                else
                {
                    PlayerTwoHand.Add(item);
                }
                counter++;
            }
        }

        public void Deal()
        {
            if(PlayerOneHand.Count < 4 || PlayerTwoHand.Count < 4)
            {
                if(PlayerOneHand.Count < PlayerTwoHand.Count)
                {
                    //Player 1 wins
                }
                else if (PlayerTwoHand.Count < PlayerOneHand.Count)
                {
                    //Player 2 wins
                }
                else{
                    //Add points logic
                }
            }

            //Set the position for the top four cards of player one to the gameboard
            for(int i = 0; i < 4; i++)
            {
                PlayerOneHand[i].Position = i + 1;

                //Add to cards in game list
                CardsInGame.Add(PlayerOneHand[i]);

                //Remove from hand list
                PlayerOneHand.RemoveAt(i);
            }

            //Set the position for the top four cards of player two to the gameboard
            for (int i = 4; i < 8; i++)
            {
                PlayerTwoHand[i].Position = i + 1;

                //Add to cards in game list
                CardsInGame.Add(PlayerTwoHand[i]);

                //Remove from hand list
                PlayerTwoHand.RemoveAt(i);
            }
        }

        public int getNumberPlayerOneCards()
        {
           return PlayerOneHand.Count;
        }
    }
}