using Newtonsoft.Json;

namespace TestWebSocketApplication
{
    public class Game
    {
        [JsonProperty]
        public static int playerOneScore { get; set; }

        [JsonProperty]
        public static int playerTwoScore { get; set; }

        //[JsonProperty]
        //public static List<Card> MiddleCards { get; set; }

        [JsonProperty]
        public static Deck MyDeck { get; set; }

        public Game()
        {
            playerOneScore = 0;
            playerTwoScore = 0;
            //CardsInGame = ;
            MyDeck = new Deck();
        }

        public void CountCards()
        {

        }

        public void MoveCard(int toPosition, int playerScore)
        {
            //will we need to pass a player score? or can we just make it public and increment?
        }

        public void StartNewGame()
        {
            
        }
    }
}