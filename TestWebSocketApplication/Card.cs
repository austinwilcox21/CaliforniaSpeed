using Newtonsoft.Json;
using System;
using System.IO;

namespace TestWebSocketApplication
{
    public class Card
    {
        [JsonProperty]
        public string ImagePath { get; set; }

        [JsonProperty]
        public string Suit { get; set; }

        [JsonProperty]
        public string FaceValue { get; set; }

        [JsonProperty]
        public int Position { get; set; }

        [JsonProperty]
        public bool CanBePlayedOn { get; set; }

        public Card(string ImagePath, string suit, string faceValue)
        {
            this.ImagePath = ImagePath;
            this.Suit = suit;
            this.FaceValue = faceValue;
            CanBePlayedOn = false;
            // set position?
        }

    }
}