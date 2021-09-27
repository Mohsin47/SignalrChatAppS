"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable send button until connection is established
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    var msg = message.replace(/&/g, "&amp;").replace(/</g, "&lt;").replace(/>/g, "&gt;");
    var encodedMsg = user + " says " + msg;
    var li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});

connection.start().then(function () {
    debugger;
    connection.invoke("GetConnectionId").then(function (id) {
        document.getElementById("connectionId").innerText = id;
        
        alert(id);
    });
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});



$("#show-all-connections").on("click", function () {

    debugger;
    connection.invoke("GetAllActiveConnections").then(function (connections) {
        $.map(connections, function (item) {
            debugger;
         
            //$("#user-list").prepend("<li>ID : " + item + "</li>");
            //if (connection == connection) {
            //    $("#user-list").append("<li>ID : " + item + "</li>");

            //}
            //else {
            //    $("#user-list").append("<li>ID : " + "Sorry" + "</li>");

            //}
            /*$("#user-list").empty();*/
            /* $("#user-list").empty();*/

            $("#user-list").append("<li>ID : " + item + "</li>");
            //$("#user-list").append("<li>ID : " + item + "</li>");

            

     

            //if (connection = connection++) {
            //    $("#user-list").append("<li>ID : " + "Same Id" + "</li>");

            //}
            //else {
            //    $("#user-list").append("<li>ID : " + item + "</li>");

            //}
        });
    });
});



document.getElementById("sendButton").addEventListener("click", function (event) {
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendMessage", user, message).catch(function (err) {
        return console.error(err.toString());
    });




    event.preventDefault();
});

document.getElementById("sendToUser").addEventListener("click", function (event) {
    debugger;
    var user = document.getElementById("userInput").value;
    var receiverConnectionId = document.getElementById("receiverId").value;
    var message = document.getElementById("messageInput").value;
    connection.invoke("SendToUser", user, receiverConnectionId, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});