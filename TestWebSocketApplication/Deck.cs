using System;
using System.Collections.Generic;
using System.IO;

namespace TestWebSocketApplication
{
    public class Deck
    {
        private List<Card> cards = new List<Card>();
        private const int NUMBER_CARDS = 53;
        private Random randomNum;

        public void createDeck()
        {
            string[] faces =
            {
                "Ace","Two","Three", "Four", "Five","Six","Seven","Eight","Nine", "Ten",
                "Jack","Queen","King"};
            string[] suits = { "Hearts", "Clubs", "Diamonds", "Spades" };
            randomNum = new Random();

            String value = faces[52 % 11];
            // value = suits[52 / 13];

            for (int count = 0; count < NUMBER_CARDS; count++)
            {
                if(count > 51)
                {
                    cards.Add(new Card(faces[count % 11], suits[51/13]));
                }
                else
                {
                    cards.Add(new Card(faces[count % 11], suits[count / 13]));
                }
   
            }
            shuffle();
        }
        public void shuffle()
        {
            for (int first = 0; first < cards.Count; first++)
            {
                int second = randomNum.Next(NUMBER_CARDS);
                Card temp = cards[first];
                cards[first] = cards[second];
                cards[second] = temp;
            }
        }
    }
}