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
connection.on("ReceiveGame", (startPosition, endPosition) => 
{
    //replace second card with first card
    document.getElementById(endPosition).replaceWith(document.getElementById(startPosition));   
});

//Receives Deck object in the form of Json to be unloaded
connection.on("ReceiveStartGame", (jsonDeck) =>
{
    var arr_from_json = JSON.parse(jsonDeck);
    
    //Examples on how to access specific pieces of json array
    console.log("The gameDeck List: " + arr_from_json.cardsInGame);
    console.log("A specific Card Object: " + arr_from_json.cardsInGame[0]);
    console.log("That card's position: " + arr_from_json.cardsInGame[0].position);
    console.log("That card's imagePath: " + arr_from_json.cardsInGame[0].imagePath);

    //Iterate through the decks and set image paths for each position
    for (i in arr_from_json.cardsInGame)
    {
        document.getElementById("pos" + arr_from_json.cardsInGame[i].position).src = "../images/" + arr_from_json.cardsInGame[i].imagePath;
    }

    //Set the player hands to the top card on their deck
    document.getElementById("pOneHand").src = "../images/" + arr_from_json.playerOneHand[0].imagePath;
    document.getElementById("pTwoHand").src = "../images/" + arr_from_json.playerTwoHand[0].imagePath;

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
    var startPosition = ev.dataTransfer.getData("text");
    var endPosition = ev.target.id;

    console.log("sourcePosition = " + startPosition);
    console.log("destinationPosition = " + endPosition);

    //Take the positions of both cards allowed in the move and send to SERVER function MoveCard() in Chathub.cs
    connection.invoke("MoveCard", startPosition, endPosition).catch(err => console.error(err.toString()));
    
    // TODO: Send that info to the server to see if move is allowed??

    // SET A CARD IN A SPECIFIC POSITION [to be determined by server output, just example for now]
    // var position = "pos1";
    // var path = "../images/10H.png";
    // document.getElementById(position).src = path;
}

