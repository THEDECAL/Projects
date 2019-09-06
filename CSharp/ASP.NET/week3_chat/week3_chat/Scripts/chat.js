const chat = $.connection.chatHub;
let userName = null;
let groups = [];


const GUI = {
    $messages: $("#chat-messages"),
    $groups: $("#chat-groups"),
    $users: $("#chat-users"),
    $infoMessages: $("#info-messages"),
    $userId: $("#user-id")
};

$.connection.hub.start();

$(function () {
    $("#btn-add-group").bind('click', function () {
        hideAddGroupTab();

        GUI.$groups.append("<li id='add-group-tab' role='presentation'>\
                <div class='add-group-field'>\
                    <input id='new-group-name' type='text' class='form-control' placeholder='Имя группы' >\
                    <button class='btn btn-link' onclick='transferAddGroup()'><span class='glyphicon glyphicon-ok'></span></button>\
                    <button class='btn btn-link' onclick='hideAddGroupTab()'><span class='glyphicon glyphicon-remove'></span></button>\
                </div></li");
    });

    $("#btn-send-message").bind('click', function () {
        let textMessage = $("#text-message").val();
        let groupId = GUI.$groups.children(".active").attr("id");
        $("#text-message").val("");

        chat.server.hubSendToGroup(groupId, textMessage);
    });

    //Клиентские функции которые видит хаб
    chat.client.createGroup = function (group) {
        addGroup(group);
    };

    chat.client.removeGroup = function (groupId) {
        GUI.$users.children().remove(`[name='${userName}']`);
    };

    chat.client.onConnected = function (id, users, groups, messages) {
        GUI.$userId.val(id);

        if (groups.length > 0) {
            for (var i = 0; i < groups.length; i++) {
                addGroup(groups[i]);
            }

            $(`#${groups[0].Id}`).addClass("active");
        }

        GUI.$users.empty();
        for (var i = 0; i < users.length; i++) {
            addUser(users[i]);
        }

        GUI.$messages.empty();
        for (var i = 0; i < messages.length; i++) {
            addMessage(groups[0].Id, messages[i]);
        }
    };

    chat.client.onDisconnected = function (userName) {
        disconnectedUserMessage(userName);
        delUser(userName);
    };

    chat.client.addNewUser = function (userName) {
        connectedUserMessage(userName);
        addUser(userName);
    };

    chat.client.errorMessage = function(text){
        errorMessage(text);
    };

    chat.client.createMessage = function (groupId, message) {
        addMessage(groupId, message);
    };

    chat.client.createMessages = function (groupId, messages) {
        for (var i = 0; i < messages.length; i++) {
            addMessage(groupId, messages[i]);
        }
    };
});

function hideAddGroupTab() {
    $("#add-group-tab").remove();
}

function transferAddGroup() {
    let groupName = $("#new-group-name").val();
    let userId = GUI.$userId.val();
    
    chat.server.hubCreateGroup(groupName, userId);

    hideAddGroupTab();
}

function transferDelGroup() {
    let groupId = $("#btn-del-group").parent().parent().attr("id");

    chat.server.hubRemoveGroup(groupId);
}

function addGroup(group) {
    let userId = GUI.$userId.val();
    let removeButton = (userId === group.OwnerId) ? "<button id='btn-del-group' style='padding: 0 !important;' class='btn btn-link btn-sm' onclick='transferDelGroup()'><span class='glyphicon glyphicon-remove'></span></button>" : "";

    GUI.$groups.append(`<li id='${group.Id}' role='presentation'><a href='#'>${group.Name} ${removeButton}</a></li>`);
    $(`#${group.Id}`).click(function () {
        GUI.$groups.children("[class=active]").removeClass();

        $(this).addClass("active");

        GUI.$messages.empty();
        chat.server.hubGetMessagesByGroup(group.Id);
    });
};

function addUser(userName) {
    GUI.$users.append(`<a name='${userName}' href='#' class='list-group-item list-group-item-warning text-center'>${userName}</a>`);
};

function delUser(userName) {
    GUI.$users.children().remove(`[name='${userName}']`);
}

function connectedUserMessage(userName) {
    GUI.$infoMessages.append(`<div class='alert alert-success alert-dismissible' role='alert'>\
            <button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button>\
            Пользователь <strong>${userName}</strong> вошёл в чат...\
            </div>`);
};

function disconnectedUserMessage(userName) {
    GUI.$infoMessages.append(`<div class='alert alert-warning alert-dismissible' role='alert'>\
            <button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button>\
            Пользователь <strong>${userName}</strong> вышел с чата...\
            </div>`);
};

function errorMessage(text) {
    GUI.$infoMessages.append(`<div class='alert alert-danger alert-dismissible' role='alert'>\
            <button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button>${text}\
            </div>`);
};

function addMessage(groupId, message) {
    let currSelectGroupId = GUI.$groups.children(".active").attr("id");

    if (currSelectGroupId === groupId) {
        let userId = GUI.$userId.val();
        //let msgClass = "col-md-2 col-md-offset-2 message alert";
        let msgClass = "message";
        let date = new Date(message.Date);
        var options = {
            month: 'short',
            day: 'numeric',
            hour: 'numeric',
            minute: 'numeric'
        };


        //if (message.Owner.Id == userId) msgClass = msgClass + " alert-success right";
        //else msgClass = msgClass + " alert-info left";
        if (message.Owner.Id == userId) msgClass = msgClass + " right";
        else msgClass = msgClass + " left";

        GUI.$messages.append(`<div class="${msgClass}">
                                <div class="message-owner">${message.Owner.Name}</div>
                                <div class="message-text">${message.Text}</div>
                                <div class="message-date right">${date.toLocaleString("ru", options)}</div>
                              </div`);
    }
};