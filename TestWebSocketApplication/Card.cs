using System;
using System.IO;

namespace TestWebSocketApplication
{
    public class Card
    {
        private string image;
        private string suit;
        private string faceValue;

        public Card(string suit, string faceValue)
        {
            this.suit = suit;
            this.faceValue = faceValue;
        }

    }
}