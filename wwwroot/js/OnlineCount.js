let onlineCount = document.querySelector('span.online-count');
debugger;
let updateCountCallback = function (message) {
    if (!message) return;
    console.log('updateCount = ' + message);
    if (onlineCount) onlineCount.innerText = message;
};

function onConnectionError(error) {
    if (error && error.message) console.error(error.message);
}


let countConnection = new signalR.HubConnectionBuilder().withUrl('/onlinecount').build();
debugger;
countConnection.on('updateCount', updateCountCallback);
countConnection.onclose(onConnectionError);
countConnection.start()
    .then(function () {
        debugger;
        console.log('OnlineCount Connected');
;
        
    })
    .catch(function (error) {
        console.error(error.message);
    });