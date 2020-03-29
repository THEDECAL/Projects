const URL = "ws://" + document.location.host + "/chat";
const GUI = {
    USER_NAME: $("#userName"),
    TEXT_MSG: $("#textMsg"),
    USRS: $("#users"),
    MSGS: $("#messages"),
    BTN_CONNECT: $("#btnConnect"),
    BTN_SEND: $("#btnSend")
};
var webSocket = null;

$(document).ready(() => {
    webSocket = new WebSocket(URL);

    webSocket.addEventListener("open", (e) => {
        console.log("connected");
    });
    webSocket.addEventListener("close", (e) => {
        console.log("disconnected");
    });
    webSocket.addEventListener("error", (e) => {
        console.log("error");
    });
    //Приём сообщения
    webSocket.addEventListener("message", (e) => {
        var msg = JSON.parse(e.data); /*console.log(msg);*/

        switch (msg.type) {
            case Message.TYPES().MSG:
                var userName = GUI.USER_NAME.val();
                    var mess = $(`<div class='${(msg.owner == userName?'incoming_msg':'outgoing_msg')}'></div>`);
                    var rmsg = $(`<div class='${(msg.owner == userName?'sent_msg':'received_withd_msg')}'>${msg.owner}</div>`);
                    var data = $(`<p>${msg.data}</p><span class='time_date'>${msg.date}</span>`);
                    rmsg.append(data);
                    mess.append(rmsg);

                    GUI.MSGS.append(mess);
                break;
            case Message.TYPES().USER_ADD:
                var userList = JSON.parse(msg.data);
                console.log("userList: ");
                console.log(userList);
                GUI.USRS.empty();

                for (var user in userList) {
                    var user = userList[user];
                    GUI.USRS.append(`<div class='chat_list active_chat'><div class='chat_people'><div class='chat_ib'><h5>${user}</h5></div></div></div>`);
                }
                break;
        }
    });

    //Обработка события нажатия кнопки подключения
    GUI.BTN_CONNECT.click(() => {
        var userName = GUI.USER_NAME.val().trim();
        if(userName != "" && userName.length >= 3) {
            sendMsg(new Message(Message.TYPES().CONN, null, userName));
            fieldsOnOff(true);
        }
        else{ alert("Обязательно нужно ввести имя. Имя должно быть больше четырёх символов."); }
    });
    //Обработка события нажатия кнопки отправки сообщения
    GUI.BTN_SEND.click(() => {
        var msgText = GUI.TEXT_MSG.val().trim();
        if (msgText != "") {
            sendMsg(new Message(Message.TYPES().MSG, null, msgText));
            GUI.TEXT_MSG.val("");
        }
    });
});

//Отправка сообщения
function sendMsg(msg){
    if (webSocket.readyState === WebSocket.OPEN) {
        var jsonMsg = JSON.stringify(msg);
        webSocket.send(jsonMsg);
    }
    else{ alert("Подключение не установлено."); }
}
//Включение отключение управляющих полей и кнопок
function fieldsOnOff(swtch){
    GUI.USER_NAME.prop('disabled', swtch);
    GUI.BTN_CONNECT.prop('disabled', swtch);
    GUI.TEXT_MSG.prop('disabled', !swtch);
    GUI.BTN_SEND.prop('disabled', !swtch);
}