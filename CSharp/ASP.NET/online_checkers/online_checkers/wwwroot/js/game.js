const GUI = {
    $game: $(".game"),
    $board: $(".board"),
};
const hubConnection = new signalR.HubConnectionBuilder().withUrl("/GameHub").build();

$(function () {
    GUI.$game.ready(() => {
        hubConnection.start();

        //Создание модального окна для ожидания подключения соперника
        let modalWindow = document.createElement("div");
        modalWindow.setAttribute("class", "modal-window");
        $(".container.body-content").prepend(modalWindow);

        $(".modal-window").append(`<div class='panel panel-primary'>
            <div class='panel-heading'>
                <h4 class="panel-title">Ожидание подключения соперника...</h4>
            </div>
            <div class='panel-body'>
                <center><img src='/images/loading.svg' alt='...'"></center>
            </div>
        </div`);

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
                let checkerSize = "50px";
                let td = document.createElement("td");
                td.setAttribute("row", row);
                td.setAttribute("col", col);
                tr.append(td);

                //Обработка события клика на клетку
                tr.onclick = (e) => {
                    //Если есть шашке на клетке
                    if (e.srcElement.localName === "img") {
                        if (selectedCell != null) {
                            selectedCell.style.width = checkerSize;
                            selectedCell.style.position = "static";
                            selectedCell.style.margin = 0;
                        }

                        if (selectedCell === null || e.srcElement.id !== selectedCell.id) {
                            e.srcElement.style.position = "absolute";
                            e.srcElement.style.margin = "-" + (checkerSize.slice(0, -2) / 2) + "px";

                            let timerId = setInterval(() => {
                                let currSize = e.srcElement.style.width.slice(0, -2);

                                e.srcElement.style.width = ++currSize + 'px';
                            }, 10);

                            setTimeout(() => { clearInterval(timerId); }, 100);

                            selectedCell = e.srcElement;
                        }
                        else selectedCell = null;
                    }//Если нет шашки на клетке
                    else if (selectedCell != null) {
                        //Отсылаем на хаб запрос
                    }
                }

                //Размещение шашок
                if ((col + shift) % 2 > 0) {
                    td.style.backgroundColor = "rgba(0,0,0,0.3)";
                    let img = document.createElement("img");
                    img.style.width = checkerSize;
                    img.setAttribute("id", col + 1);

                    if (row < rowsOfCheckers) {
                        img.setAttribute("src", "/images/white_checker.png")
                        td.append(img);
                    }
                    else if (row >= (boardSize - rowsOfCheckers)) {
                        img.setAttribute("src", "/images/black_checker.png");
                        td.append(img);
                    }
                }
            }
            shift = (shift == 0) ? 1 : 0;
        }
    })
})