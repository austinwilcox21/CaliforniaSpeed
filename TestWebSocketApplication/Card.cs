using System;
using System.IO;

namespace TestWebSocketApplication
{
    public class Card
    {
        private string imagePath;
        private string suit;
        private string faceValue;
        private int position;
        public bool CanBePlayedOn = false;

        public Card(string imagePath, string suit, string faceValue)
        {
            this.imagePath = imagePath;
            this.suit = suit;
            this.faceValue = faceValue;
        }

        public string GetImagePath()
        {
            return imagePath;
        }

        public string GetSuit()
        {
            return suit;
        }

        public string GetFaceValue()
        {
            return faceValue;
        }

        public void SetPosition(int pos)
        {
            
        }

        public int GetPosition()
        {
            return position;
        }

    }
}