using Newtonsoft.Json;

namespace TestWebSocketApplication
{
    public class Game
    {
        [JsonProperty]
        public int PlayerOneScore { get; set; }

        [JsonProperty]
        public int PlayerTwoScore { get; set; }

        // we wanted to move this one to the game class instead of deck. It works either way though...
        //[JsonProperty]
        //public static List<Card> MiddleCards { get; set; }

        [JsonProperty]
        public Deck MyDeck { get; set; }

        public Game()
        {
            PlayerOneScore = 0;
            PlayerTwoScore = 0;
            //CardsInGame = ;
            MyDeck = new Deck();
        }

        public void CountCards()
        {
            // at the end of the game. Need to make sure we increment every time we play a card.
        }

        // this one is actually being done by site.js...
        public void MoveCard(int toPosition, int playerScore)
        {
            //will we need to pass a player score? or can we just make it public and increment?
        }

        // this one is also being done by site.js...
        public void StartNewGame()
        {
            
        }
    }
}