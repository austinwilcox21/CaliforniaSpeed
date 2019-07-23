using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.ObjectPool;

namespace TestWebSocketApplication
{
    public class Deck
    {
        public List<Card> cards = new List<Card>();
        public List<Card> playerOneHand = new List<Card>();
        public List<Card> playerTwoHand = new List<Card>();
        public const int NUMBER_CARDS = 52;
        public Random randomNum;

        public void CreateDeck()
        {
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

            for (var count = 0; count < NUMBER_CARDS; count++)
            {
                cards.Add(new Card(images[count], suits[count / 13], faces[count % 13]));
            }
            
            Shuffle();
            Split();
        }
        private void Shuffle()
        {
            for (var first = 0; first < cards.Count; first++)
            {
                var second = randomNum.Next(NUMBER_CARDS);
                var temp = cards[first];
                cards[first] = cards[second];
                cards[second] = temp;
            }
        }

        private void Split()
        {
            var counter = 0;
            foreach (var item in cards)
            {
                if (counter < 26)
                {
                    playerOneHand.Add(item);
                }
                else
                {
                    playerTwoHand.Add(item);
                }
                counter++;
            }
        }

        public void Deal()
        {
            
        }

    }

}