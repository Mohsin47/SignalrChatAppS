$("#show-all-connections").on("click", function () {
    debugger;

    //var connection = new signalR.HubConnectionBuilder().withUrl("/onlinecount").build();

    debugger;
    connection.invoke("GetAllActiveConnections").then(function (connections) {
        $.map(connections, function (item) {
            $("#user-list").append("<li>Connection ID : " + item + "</li>");
        });
    });
    //chatHub.server.getAllActiveConnections().done(function (connections) {
    //    $.map(connections, function (item) {
    //        $("#user-list").append("<li>Connection ID : " + item + "</li>");
    //    });
    //});
});


debugger;
connection.invoke("GetAllActiveConnections").then(function (connections) {
    $.map(connections, function (item) {
        $("#user-list").append("<li>ID : " + item + "</li>");
    });
});