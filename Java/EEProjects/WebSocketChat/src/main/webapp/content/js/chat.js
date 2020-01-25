const url = "ws://" + document.location.host + "/chat";
console.log(`url: ${url}`);

$(document).ready(() => {
    const webSocket = new WebSocket(url);

    webSocket.addEventListener("open", (e) => {
        console.log("webSocket: ");
        console.log(webSocket);
    });

    webSocket.addEventListener("message", (e) => {
        console.log(e);
    });
});
