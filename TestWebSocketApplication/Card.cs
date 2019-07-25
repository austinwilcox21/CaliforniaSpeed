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
        public string suit { get; set; }

        [JsonProperty]
        public string faceValue { get; set; }

        [JsonProperty]
        public int Position { get; set; }

        [JsonProperty]
        public bool CanBePlayedOn { get; set; }

        public Card(string ImagePath, string suit, string faceValue)
        {
            this.ImagePath = ImagePath;
            this.suit = suit;
            this.faceValue = faceValue;
            CanBePlayedOn = false;
            // set position?
        }

    }
}