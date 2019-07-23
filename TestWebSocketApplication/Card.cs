using System;
using System.IO;

namespace TestWebSocketApplication
{
    public class Card
    {
        public string imagePath;
        public string suit;
        public string faceValue;
        public int position = 0;
        public bool CanBePlayedOn = false;

        public Card(string imagePath, string suit, string faceValue)
        {
            this.imagePath = imagePath;
            this.suit = suit;
            this.faceValue = faceValue;
        }

    }
}