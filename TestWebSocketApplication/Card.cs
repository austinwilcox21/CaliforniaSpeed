using System;
using System.IO;

namespace TestWebSocketApplication
{
    public class Card
    {
        private string image;
        private string suit;
        private string faceValue;
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