// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

//===============================================================================================================
// CARSON'S NOTES ABOUT CLIENT TO SERVER COMMUNICATION                                                          |
//                                                                                                              |
// (1) SignalR HUB & Connection are created.                                                                    |
// (2) Hub methods are called by client using invoke("methodName") on some event (such as a button click).      |
// (3) The method in the hub (Chathub.cs) is run. The server then can use the information acquired from client. |
// (4) The server sends the information out to the clients using Clients.All.SendAsync("methodName").           |
// (5) The Client Side Method connection.on("methodName", () => { }); is run and changes the game for the user. |
//===============================================================================================================

//------------------------------------------
// SET UP THE SIGNALR CONNECTION & START IT |
//------------------------------------------

// Create the signalR connection hub (HUB is basically a collection of methods on the server)
var connection = new signalR.HubConnectionBuilder()
    .withUrl("/ChatHub")
    .build();

//Create signalR connection
connection.start().catch(err => console.error(err.toString()));

//-----------------------------------------------------------------------------------
// CLIENT SIDE METHODS (these are used to make alterations for what the player sees) |
//-----------------------------------------------------------------------------------

//Messenger: Display Message to Client (user)
connection.on("ReceiveMessage", (user, message) => {
    const rec_msg = user + ": " + message;
    const li = document.createElement("li");

    li.textContent = rec_msg;
    document.getElementById("messageList").appendChild(li);
});

//Game: Update cards to reflect what has been determined by the server
connection.on("ReceiveGame", (jsonGame) => 
{
    var arr_from_json = JSON.parse(jsonGame)
    console.log(arr_from_json);
    //replace second card with first card
    console.log("../images/" + arr_from_json.MyDeck.PlayerOneHand[0].ImagePath);
    document.getElementById("pOneHand").src = "../images/" + arr_from_json.MyDeck.PlayerOneHand[0].ImagePath;
    document.getElementById("pTwoHand").src = "../images/" + arr_from_json.MyDeck.PlayerTwoHand[0].ImagePath;
    document.getElementById("pos" + arr_from_json.MyDeck.CardsInGame[0].Position).src = "../images/" + arr_from_json.MyDeck.CardsInGame[0].ImagePath;
    document.getElementById("pos" + arr_from_json.MyDeck.CardsInGame[1].Position).src = "../images/" + arr_from_json.MyDeck.CardsInGame[1].ImagePath;
    document.getElementById("pos" + arr_from_json.MyDeck.CardsInGame[2].Position).src = "../images/" + arr_from_json.MyDeck.CardsInGame[2].ImagePath;
    document.getElementById("pos" + arr_from_json.MyDeck.CardsInGame[3].Position).src = "../images/" + arr_from_json.MyDeck.CardsInGame[3].ImagePath;
    document.getElementById("pos" + arr_from_json.MyDeck.CardsInGame[4].Position).src = "../images/" + arr_from_json.MyDeck.CardsInGame[4].ImagePath;
    document.getElementById("pos" + arr_from_json.MyDeck.CardsInGame[5].Position).src = "../images/" + arr_from_json.MyDeck.CardsInGame[5].ImagePath;
    document.getElementById("pos" + arr_from_json.MyDeck.CardsInGame[6].Position).src = "../images/" + arr_from_json.MyDeck.CardsInGame[6].ImagePath;
    document.getElementById("pos" + arr_from_json.MyDeck.CardsInGame[7].Position).src = "../images/" + arr_from_json.MyDeck.CardsInGame[7].ImagePath;
    
});

//Receives Deck object in the form of Json to be unloaded
connection.on("ReceiveStartGame", (jsonGame) =>
{
    var arr_from_json = JSON.parse(jsonGame);
    console.log(arr_from_json);
    //Examples on how to access specific pieces of json array
    console.log("The gameDeck List: " + arr_from_json.MyDeck.CardsInGame);
    console.log("A specific card Object: " + arr_from_json.MyDeck.CardsInGame[0]);
    console.log("That card's position: " + arr_from_json.MyDeck.CardsInGame[0].Position);
    console.log("That card's imagePath: " + arr_from_json.MyDeck.CardsInGame[0].ImagePath);

    //Iterate through the decks and set image paths for each position
    var card;
    var positionElement;
    for (i in arr_from_json.MyDeck.CardsInGame)
    {
        card = arr_from_json.MyDeck.CardsInGame[i];
        positionElement = document.getElementById("pos" + (card.Position));
        positionElement.src = "../images/" + card.ImagePath;
    }

    //Set the player hands to the top card on their deck
    document.getElementById("pOneHand").src = "../images/" + arr_from_json.MyDeck.PlayerOneHand[0].ImagePath;
    document.getElementById("pTwoHand").src = "../images/" + arr_from_json.MyDeck.PlayerTwoHand[0].ImagePath;

});

//--------------------------------------------------------------------
// CALLING HUB METHODS FROM CLIENT (called by using invoke() method) |
//--------------------------------------------------------------------

//MESSENGER: Send Message to Server on button click
document.getElementById("sendMessage").addEventListener("click", event =>
{
    const user = document.getElementById("userName").value;
    const message = document.getElementById("userMessage").value;

    //Take the name and message entered into the box and send it to SERVER function SendMessage() in Chathub.cs
    //connection.invoke("SendMessage", user, message).catch(err => console.error(err.toString()));
    connection.invoke("StartGame");
    event.preventDefault();
});

//--------------------------------
//  Drag & Drop Logic For Cards  |
//--------------------------------

// A function that enables a card to be dropped on top of the card
function allowDrop(ev)
{
    ev.preventDefault();
}

// A function that enables a card to be dragged
function drag(ev)
{
    ev.dataTransfer.setData("text", ev.target.id);
}

// When card is dropped onto another card
function drop(ev)
{
    ev.preventDefault();

    // Determines the names of the <img> of the card being moved and the card being dropped onto
    var player = 1; // This should be the actual player, not just player 1
    var endPosition = ev.target.id;

    console.log("player = " + player);
    console.log("destinationPosition = " + endPosition);

    //Take the positions of both cards allowed in the move and send to SERVER function MoveCard() in Chathub.cs
    connection.invoke("MoveCard", player, endPosition).catch(err => console.error(err.toString()));
    
    // TODO: Send that info to the server to see if move is allowed??

    // SET A CARD IN A SPECIFIC POSITION [to be determined by server output, just example for now]
    // var position = "pos1";
    // var path = "../images/10H.png";
    // document.getElementById(position).src = path;
}

