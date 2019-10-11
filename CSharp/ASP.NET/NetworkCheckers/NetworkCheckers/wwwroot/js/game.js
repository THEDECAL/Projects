const GUI = {
    $game: $(".game"),
    $board: $(".board"),
    $log: $("#log"),
    $whiteScore: $("#white-score"),
    $blackScore: $("#black-score")
};
var timerId = "";
const checkerSize = "50px";
const hubConnection = new signalR.HubConnectionBuilder().withUrl("/GameHub").build();
hubConnection.serverTimeoutInMilliseconds = 1000 * 180 * 10;
hubConnection.start();

hubConnection.on("CloseModalWindow", function () {
    closeModalWindow();
});
hubConnection.on("CreateModalWindow", function (title, text) {
    createModalWindow(title, text);
});
hubConnection.on("SetNamePlayers", function (players) {
    $("#white-player").text(players[0]);
    $("#black-player").text(players[1]);
});
hubConnection.on("MoveAndPickUpChecker", function (src, dst, cellsToPickUp) {
    let srcCell = $(`td[row=${src.x}][col=${src.y}]`)[0];
    let dstCell = $(`td[row=${dst.x}][col=${dst.y}]`)[0];

    for (var item in cellsToPickUp) {
        item = cellsToPickUp[item];
        let cell = $(`td[row=${item.x}][col=${item.y}]`)[0];
        cell.children[0].remove();
    }

    dstCell.append(srcCell.children[0]);
    srcCell.children[0].remove();
});
hubConnection.on("SetKing", function (checker) {
    let cell = $(`td[row=${checker.x}][col=${checker.y}]`)[0];
    cell.children[0].remove();

    let img = document.createElement("img");
    img.style.width = checkerSize;
    img.style.height = checkerSize;
    img.setAttribute("src", `/images/king_${checker.color}_checker.png`);

    cell.append(img);
});
hubConnection.on("SendMessage", function (title, text) { showMessage(title, text) });
hubConnection.on("SetCheckers", function (checkers) {
    for (var item in checkers) {
        item = checkers[item];
        let cell = $(`td[row=${item.x}][col=${item.y}]`)[0];
        
        let img = document.createElement("img");
        img.style.width = checkerSize;
        img.style.height = checkerSize;

        if (item.color === "white")
            img.setAttribute("src", "/images/white_checker.png");
        else
            img.setAttribute("src", "/images/black_checker.png");

        cell.append(img);
    }
});
hubConnection.on("StartTimer", function () {
    closeModalWindow();
    if (timerId !== "") {
        clearInterval(timerId);
    }

    timerId = setInterval(function () {
        let min = $("#minutes");
        let sec = $("#seconds");
        let currSec = Number(sec.text());

        if (currSec === 59) {
            min.text(Number(min.text()) + 1);
            if (min.text() < 10)
                min.text("0" + min.text());
            sec.text("00");
        }
        else {
            sec.text(Number(sec.text()) + 1)
            if (sec.text() < 10)
                sec.text("0" + sec.text())
        }
    }, 1000);
});
hubConnection.on("SetScore", function (points, color) {
    $(`#${color}-score`).text(points);
});
hubConnection.on("AddMessagesToLog", function (messages) {
    if (typeof (messages) === "object") {
        for (var text in messages) {
            text = messages[text];
            GUI.$log.append(`<span class="label label-default">${text}</span>`);
        }
        document.getElementById("log").scrollTop = document.getElementById("log").scrollHeight;
    }
    else GUI.$log.append(`<span class="label label-default">${messages}</span>`);
});
hubConnection.on("ClearGame", function () {
    $("td[row][col]").children().remove();
    GUI.$log.empty();
    Gui.$whiteScore.text("0");
    Gui.$blackScore.text("0");
});
$(function () {
    GUI.$game.ready(() => {
        //Создание модального окна для ожидания подключения соперника
        createModalWindow();

        let selectedCell = null;
        let boardSize = GUI.$board.attr("border-size");
        let table = document.createElement("table");
        let rowsOfCheckers = (boardSize - 2) / 2;
        GUI.$board.append(table);

        //Рисование доски
        let shift = 0;
        GUI.$board.append();
        for (var row = 0; row < boardSize; row++) {
            let tr = document.createElement("tr");
            table.append(tr);

            for (var col = 0; col < boardSize; col++) {
                //let checkerSize = "50px";
                let td = document.createElement("td");
                td.setAttribute("row", row);
                td.setAttribute("col", col);
                tr.append(td);

                //Обработка события клика на клетку
                tr.onclick = (e) => {
                    //Если есть шашка на клетке
                    if (e.srcElement.localName === "img") {
                        if (selectedCell != null) {
                            selectedCell.srcElement.style.width = checkerSize;
                            selectedCell.srcElement.style.height = checkerSize;
                            selectedCell.srcElement.style.position = "static";
                            selectedCell.srcElement.style.margin = 0;
                        }

                        //Анимация выбора
                        if (selectedCell === null || e.srcElement.id !== selectedCell.srcElement.id) {
                            e.srcElement.style.position = "absolute";
                            e.srcElement.style.margin = "-" + (checkerSize.slice(0, -2) / 2) + "px";

                            let timerId = setInterval(() => {
                                let currSize = e.srcElement.style.width.slice(0, -2);

                                e.srcElement.style.width = ++currSize + 'px';
                                e.srcElement.style.height = ++currSize + 'px';
                            }, 10);

                            setTimeout(() => { clearInterval(timerId); }, 100);

                            selectedCell = e;
                        }
                        else selectedCell = null;
                    }//Если нет шашки на клетке
                    else if (selectedCell != null) {
                        var srcX = selectedCell.path[1].attributes.row.value;
                        var srcY = selectedCell.path[1].attributes.col.value;
                        var dstX = e.srcElement.attributes.row.value;
                        var dstY = e.srcElement.attributes.col.value;
                        
                        selectedCell.srcElement.style.width = checkerSize;
                        selectedCell.srcElement.style.height = checkerSize;
                        selectedCell.srcElement.style.position = "static";
                        selectedCell.srcElement.style.margin = 0;

                        selectedCell = null;
                        //Отсылаем на хаб запрос для передвижения шашки
                        hubConnection.invoke("MoveChecker", srcX, srcY, dstX, dstY);
                    }
                }

                //Покраска чёрных клеток
                if ((col + shift) % 2 > 0)
                    td.style.backgroundColor = "rgba(0,0,0,0.3)";
            }
            shift = (shift == 0) ? 1 : 0;
        }
    })
})

function createModalWindow(title = "", text = "")
{
    title = (title === "") ? "Ожидание подключения соперника..." : title;
    text = (text === "") ? "<img src='/images/loading.svg' alt='...'>" : text;

    let modalWindow = document.createElement("div");
    modalWindow.setAttribute("id", "modal-window");
    modalWindow.setAttribute("class", "modal-window");
    $(".container.body-content").prepend(modalWindow);

    $(".modal-window").append(`<div id='message-window' class='panel panel-primary' style='opacity: 1;'> 
            <div class='panel-heading'>
                <h4 class="panel-title">${title}</h4>
            </div>
            <div class='panel-body'><center>${text}</center></div>
        </div`);
}

function showMessage(title, text) {
    createModalWindow(title, text);

    new Promise(resolve => setTimeout(resolve, 2000));

    let timerId = null;

    setTimeout(() => {
        timerId = setInterval(() => {
            let opacity = $("#message-window").css("opacity");
            $("#message-window").css("opacity", opacity - 0.05);
        }, 70);
    }, 1500);

    setTimeout(() => {
        clearInterval(timerId);
        closeModalWindow();
    }, 3000);
}

function closeModalWindow() { $("#modal-window").remove(); }