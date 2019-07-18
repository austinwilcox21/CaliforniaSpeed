using System;
using System.IO;

namespace TestWebSocketApplication
{
    public class Card
    {
        public string image;
        public string suit;
        public string faceValue;
        //  private bool isPlayable;

        public Card(string image, string suit, string faceValue)
        {
            this.image = image;
            this.suit = suit;
            this.faceValue = faceValue;
            //      this.isPlayable = false;
        }

    }
}