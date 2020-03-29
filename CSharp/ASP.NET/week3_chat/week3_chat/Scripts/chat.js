const chat = $.connection.chatHub;

const GUI = {
    $messages: $("#chat-messages"),
    $groups: $("#chat-groups"),
    $users: $("#chat-users"),
    $notifications: $("#notifications"),
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
        let textMessage = $("#text-message").val().trim();
        let activeGroup = GUI.$groups.children(".active");
        //console.log(activeGroup);

        if (textMessage !== "" && activeGroup.length > 0) {
            let groupId = GUI.$groups.children(".active").attr("id");
            $("#text-message").val("");

            chat.server.hubSendToGroup(groupId, textMessage);
        }
    });

    $("#text-message").keydown(function (e) {
        var keycode = (e.keyCode ? e.keyCode : e.which);
        if (keycode === 13) {
            let textMessage = $("#text-message").val().trim();
            let activeGroup = GUI.$groups.children(".active");
            //console.log(activeGroup);

            if (textMessage !== "" && activeGroup.length > 0) {
                let groupId = GUI.$groups.children(".active").attr("id");
                $("#text-message").val("");

                chat.server.hubSendToGroup(groupId, textMessage);
            }
        }
    });

    //Клиентские функции которые видит хаб
    chat.client.createGroup = function (group) {
        addGroup(group);
    };

    chat.client.removeGroup = function (groupId) {
        $(`#${groupId}`).remove();
        GUI.$messages.empty();
    };

    chat.client.onConnected = function (currentUser, users, groups, messages) {
        GUI.$userId.val(currentUser.Id);
        GUI.$userId.attr("name", currentUser.Name);

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
        delUser(userName);
    };

    chat.client.createUser = function (userName) {
        addUser(userName);
    };

    chat.client.createEnterNotification = function (userName) {
        addNotification(`Пользователь <strong>${userName}</strong> вошёл в чат.`, "alert-success");
    };

    chat.client.createBlockedNotification = function (userName) {
        addNotification(`Пользователь <strong>${userName}</strong> заблокирован.`, "alert-danger");
    };

    chat.client.createExitNotification = function (userName) {
        addNotification(`Пользователь <strong>${userName}</strong> вышел из чата.`, "alert-warning");
    };

    chat.client.removeUser = function (userName) {
        delUser(userName);
    };

    chat.client.blockUser = function () {
        GUI.$messages.empty();
        //GUI.$groups.empty();
        GUI.$groups.find("li").slice(1).remove();
        GUI.$users.empty();
        $userId.val("");
    };

    chat.client.errorMessage = function(text){
        addNotification(text, "alert-danger");
    };

    chat.client.createMessage = function (groupId, message) {
        //console.log("chat.client.createMessage");
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

function addGroup(group) {
    let userId = GUI.$userId.val();
    let isOwner = false;
    for (var i = 0; i < group.Owners.length; i++) {
        if (group.Owners[i].Id === userId) {
            isOwner = true;
            break;
        }
    }
    
    let removeButton = (isOwner === true) ? `<button id='btn-del-group' style='padding: 0 !important;' class='btn btn-link btn-sm'><span class='glyphicon glyphicon-remove'></span></button>` : "";

    GUI.$groups.append(`<li id='${group.Id}' role='presentation'><a href='#'>${group.Name} ${removeButton}</a></li>`);

    let button = $(`#${group.Id}`).children().first().children().first();
    if (removeButton != "") {
        button.bind('click', function () {
            let groupId = $(this).parent().parent().attr("id");

            chat.server.hubRemoveGroup(groupId);
        })
    }

    GUI.$messages.empty();
    GUI.$groups.children("[class=active]").removeClass();
    $(`#${group.Id}`).addClass("active");

    $(`#${group.Id}`).click(function () {
        GUI.$messages.empty();
        GUI.$groups.children("[class=active]").removeClass();
        $(this).addClass("active");

        chat.server.hubGetMessagesByGroup(group.Id);
    });
};

function addUser(userName) {
    GUI.$users.append(`<a name='${userName}' href='#' class='list-group-item list-group-item-warning text-center user'>${userName}</a>`);

    GUI.$users.children(`[name='${userName}']`).bind('click', function () {
        let thisUserName = $(this).attr("name");
        let currUserName = GUI.$userId.attr("name");

        if (thisUserName !== currUserName) {
            chat.server.hubCreatePrivateGroup(currUserName, thisUserName);
        }
    });
};

function delUser(userName) {
    GUI.$users.children().remove(`[name='${userName}']`);
}

function addNotification(text, colorClass) {
    GUI.$notifications.append(`<div class='alert ${colorClass} alert-dismissible' role='alert'>
                                <button type='button' class='close' data-dismiss='alert' aria-label='Close'><span aria-hidden='true'>&times;</span></button>${text}
                            </div>`);
}

function addMessage(groupId, message) {
    //console.log("addMessage");
    let currSelectGroupId = GUI.$groups.children(".active").attr("id");

    if (currSelectGroupId === groupId) {
        let userId = GUI.$userId.val();
        let msgClass = "message ";
        let date = new Date(message.Date);
        var options = {
            month: 'short',
            day: 'numeric',
            hour: 'numeric',
            minute: 'numeric'
        };


        if (message.Owner.Id == userId) msgClass = msgClass + " right blue";
        else msgClass = msgClass + " left green";

        GUI.$messages.append(`<div class="${msgClass}">
                                <div class="message-owner">${message.Owner.Name}</div>
                                <div class="message-text">${message.Text}</div>
                                <div class="message-date right">${date.toLocaleString("ru", options)}</div>
                              </div`);
    }
};