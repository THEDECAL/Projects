const MAX_PLAYERS = 8;
const CNT_RETRY_CONN = 3;
const THROW_TIME_ANIM = 700;
const COMB_NAMES_ARR = [
    "Старшая карта",
    "Пара",
    "Две пары",
    "Сет",
    "Стрит",
    "Флэш",
    "Фул-Хаус",
    "Карэ",
    "Стрит-Флэш",
    "Роял-Флэш"];
const GUI = {
    BANK: $("#bank-count"),
    GAME_ID: $("#game-id").val(),
    BANK: $("#bank"),
    DECK: $("#deck"),
    COMB_NAME: $("#combination"),
    ACTIONS: $("#player-actions"),
    ALERTS: $("#alerts"),
    MODALS: $("#modal-wins")
}
var currCombNum = null;
var coinsInBank = null;
var nickNamesArray = null;
var crds = {};

//Настройка и пожключение к хабу
const hubConnection = new signalR.HubConnectionBuilder()
    .withUrl("/PokerHub")
    .withAutomaticReconnect()
    .configureLogging(signalR.LogLevel.Warning)
    .build();

hubConnection.serverTimeoutInMilliseconds = 7200000; //2 часа
////Объявление клиентских методов
hubConnection.on("WaitWindow", waitWindow);
hubConnection.on("CloseWaitWindow", () => { setTimeout(closeWaitWindow, 500); });
hubConnection.on("AddPlayer", (nickNamesArr) => { nickNamesArray = nickNamesArr; });
hubConnection.on("CardDist", (plCardsArr) => {
    addPlayers(nickNamesArray);
    cardDist(plCardsArr);
});
hubConnection.on("QuickCardDist", (plCardsArr) => quickCardDist(plCardsArr));
hubConnection.on("AddCombName", (combNum) => { currCombNum = combNum; });
hubConnection.on("AddCoinsToBank", (coinsAmount) => { addCoinsToBank(coinsAmount); coinsInBank = coinsAmount; });
hubConnection.on("AddAlert", (title, text, bsColor) => setTimeout(addAlert(title, text, bsColor)), 500);
hubConnection.on("ShowOfferToBeShowdown", (playerNickName) => showOfferToBeShowdown(playerNickName));
hubConnection.on("ShowWindowGameOver", (playerNickName, isWinn) => showWindowGameOver(playerNickName, isWinn));
//Подключение к хабу
hubConnection.start(setTimeout(connectToGame));

////Объвление серверных методов
//Кнопка сделать ставку
function btnBet() {
    const amountBet = Number($("#amount-bet").val());
    hubConnection.send("Bet", GUI.GAME_ID, amountBet);//.then(console.log(`Error running function ${btnBet.name}`));
}
//Кнопка завершить игру
function btnFold() {
    hubConnection.send("Fold", GUI.GAME_ID);//.then(console.log(`Error running function ${btnFold.name}`));
}
//Кнопка предложения вскрыть карты
function btnShowdown() {
    hubConnection.send("OfferToBeShowdown", GUI.GAME_ID);//.then(console.log(`Error running function ${btnShowdown.name}`));
}
//Отправка ответа на вопрос о вскрытии карт
function btnShowdownAnswer(isAgree) {
    $("#modalWindow").modal('hide');
    GUI.MODALS.empty();
    hubConnection.send("ShowdownAnswer", GUI.GAME_ID, isAgree);//.then(console.log(`Error running function ${btnYesOrNot.name}`));
}
//Отправка ответа на вопрос о новой партии
function btnNewParty(isAgree) {
    $("#modalWindow").modal('hide');
    GUI.MODALS.empty();

    if (isAgree) { clearTable(); }
    else {
        setTimeout(() => {
            window.location.href = location.protocol + '//' + window.location.host;
        }, 1000);
    }

    hubConnection.send("NewParty", GUI.GAME_ID, isAgree);
}

//Подключение к хабу
function connectToGame(cntRetry = 0, isSending = false) {
    if (++cntRetry <= CNT_RETRY_CONN) {
        setTimeout(() => {
            if (hubConnection.state === "Connected" && !isSending) {
                hubConnection.send("ConnectToGame", GUI.GAME_ID).then(connectToGame(cntRetry, true));
            }
            else if (hubConnection.state === "Disconnected") {
                hubConnection.start().then(connectToGame(cntRetry, false));
            }
        }, 500 * cntRetry);
    }
}
//Открытие анимации ожидания
function waitWindow() {
    let title = "Ожидание подключения соперников...";

    GUI.MODALS.empty();
    GUI.MODALS.append(`<div class="modal fade" data-keyboard="false" data-backdrop="static" id="modalWindow" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content" style="width: unset;margin: 0 auto;">
                <div class="modal-header">
                    <h5 class="modal-title" id="modalWindowTitle">${title}</h5>
                </div>
                <div class="modal-body">
                    <center><img src="/images/loading.svg" /></center>
                </div>
            </div>
        </div>
    </div>`);
    $("#modalWindow").modal('show');
}
//Закрытие анимации ожидания
function closeWaitWindow() {
    $("#modalWindow").modal('hide');
    GUI.MODALS.empty();
}
//Добавление поля названия комбинации
function addCombName(combNum) {
    GUI.COMB_NAME.empty();
    GUI.COMB_NAME.append(COMB_NAMES_ARR[Number(combNum)]);
}
//Раздача карт с анимацией и показ названия комбинации
function cardDist(plCardsArr, plNum) {
    crds = plCardsArr;
    if (plNum === undefined) {
        GUI.DECK.show();
        plNum = Number(plCardsArr.length) + Number(1);
    }

    if (plNum > 1) {
        var plIndex = Number(--plNum) - Number(1);
        var cards = plCardsArr[plIndex];

        setTimeout(() => {
            var cardIndex = 0;
            throwCard(plNum);

            var cardTimerId = setInterval(() => {
                var imgName = cards[cardIndex] + ".png";
                if (cardIndex < cards.length - 1) {
                    throwCard(plNum);
                    cardIndex++;
                }
                else {
                    clearInterval(cardTimerId);
                    cardIndex = 0;
                }
                addCard(imgName, plNum);

            }, THROW_TIME_ANIM);

            if (plNum > 0) {
                setTimeout(() => {
                    cardDist(plCardsArr, plNum)
                }, THROW_TIME_ANIM * cards.length);
            }
        }); 
    }
    else {
        GUI.DECK.hide();
        GUI.COMB_NAME.show();
        GUI.BANK.show();
        GUI.ACTIONS.show();
        addCombName(Number(currCombNum));
        addCoinsToBank(Number(coinsInBank));
        
    }
}
//Раздача карт без анимации и показ названия комбинации
function quickCardDist(plCardsArr) {
    crds = plCardsArr;
    GUI.DECK.show();

    addPlayers(nickNamesArray);
    for (var i in plCardsArr) {
            var plNum = parseInt(Number(i) + Number(1));
            var cards = plCardsArr[i];

            for (var j in cards) { addCard(cards[j] + ".png", plNum); }
    }

    GUI.DECK.hide();
    GUI.COMB_NAME.show();
    GUI.BANK.show();
    addCombName(Number(currCombNum));
    addCoinsToBank(Number(coinsInBank));
    GUI.ACTIONS.show();
}
//Добавление имени игрока на стол
function addPlayers(nickNamesArr) {
    for (var i in nickNamesArr) {
        var el = $(`#player${parseInt(Number(i) + Number(1))} .player-title`);
        el.empty();
        el.append(nickNamesArr[i]);
    }
}
//Анимация броска карты
function throwCard(plNum) {
    var cardPoint = GUI.DECK.offset();
    var playerPoint = $(`#player${plNum}`).offset();
    var top = Math.round(playerPoint.top - cardPoint.top);
    var left = Math.round(playerPoint.left - cardPoint.left + 80);

    GUI.DECK[0].lastElementChild.animate([
        {
            transform: "rotate(0deg)",
            top: "0px",
            left: "0px"
        },
        {
            transform: "rotate(180deg)",
            top: `${top}px`,
            left: `${left}px`
        }],
    { duration: THROW_TIME_ANIM });
}
//Добавление карты на стол
function addCard(imgName, plNum) {
    var playerEl = $(`#player${plNum} .player-cards`);
    var childCount = playerEl[0].childElementCount;
    var cardNumber = parseInt(childCount + 1);
    var currOffset = (childCount === 0) ? 0 : playerEl[0].childNodes[parseInt(childCount - 1)].style.left;
    if (currOffset !== 0) { currOffset = parseInt(currOffset.substring(0, currOffset.length - 2)); }
    var offset = (cardNumber == 1) ? 0 : `${currOffset + (-35)}`;

    var style = `style="
    left: ${offset}px;
    z-index: ${cardNumber};"`;

    var el = $(`<div class="game-card" ${style}></div>`);
    var img = $(`<img src="/images/cards/${imgName}", alt="...">`);
    el.append(img);
    playerEl.append(el);
    img.mouseenter((e) => { setTimeout(() => {
            if (!e.target.src.includes("0.png")) {
                var el = e.target;
                el.animate(
                    [{
                        bottom: "0px"
                    }, {
                        bottom: "35px"
                    }],
                    { duration: 500 });
                e.target.style.bottom = "35px";
            }
    }, 100);});
    img.mouseleave((e) => { setTimeout(() => {
            if (!e.target.src.includes("0.png")) {
                var el = e.target;
                el.animate(
                    [{
                        bottom: "35px"
                    }, {
                        bottom: "0px"
                    }],
                    { duration: 500 });
                e.target.style.bottom = "0px";
            }
    }, 100);});
}
//Добавление монет в банк
function addCoinsToBank(coins) {
    const BANK = $("#bank-count");
    BANK.empty();
    BANK.append(Number(coins) + " монет");
}
//Добавление уведомления
function addAlert(title, text, bsColor) {
    var alert = $(`<div class="alert alert-${bsColor} alert-dismissible fade show" role="alert">
        <strong>${title}</strong>&emsp;${text}
        <button type="button" class="close" data-dismiss="alert" aria-label="Close">
            <span aria-hidden="true">&times;</span>
        </button>
    </div>`);
    GUI.ALERTS.prepend(alert.hide().fadeIn());

    //Закрытие по таймауту
    //const timeOut = Number(3000);
    //setTimeout(alert.fadeOut().remove(), timeOut);
}
//Показ модального окна предложения вскрыть карты
function showOfferToBeShowdown(playerNickName) {
    let title = "Игрок <strong>" + playerNickName + "</strong> предлагает вскрыть карты";

    GUI.MODALS.empty();
    GUI.MODALS.append(`<div class="modal fade" data-keyboard="false" data-backdrop="static" id="modalWindow" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content" style="width: unset;margin: 0 auto;">
                <div class="modal-header">
                    <center><h5 class="modal-title" id="modalWindowTitle">${title}</h5></center>
                </div>
              <div class="modal-body" style="margin: 0 auto;">
                <p>Вы согласны вскрыть карты?</p>
              </div>
              <div class="modal-footer" style="margin: 0 auto;">
                <button type="button" class="btn btn-success" data-dismiss="modal" onclick='btnShowdownAnswer(true)'>Да</button>
                <button type="button" class="btn btn-danger" data-dismiss="modal" onclick='btnShowdownAnswer(false)'>Нет</button>
              </div>
            </div>
        </div>
    </div>`);
    $("#modalWindow").modal('show');
}
//Показ окна завершения игры и предложение начать новую партию
function showWindowGameOver(playerNickName, isWinn) {
    let title = null;
    if (isWinn) {
        title = "Поздравляем <strong>" + playerNickName + "</strong> вы победили!";
    }
    else {
        title = "К сожалению вы проиграли, победил <strong>" + playerNickName + "</strong>";
    }

    GUI.MODALS.empty();
    GUI.MODALS.append(`<div class="modal fade" data-keyboard="false" data-backdrop="static" id="modalWindow" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
        <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content" style="width: unset;margin: 0 auto;">
                <div class="modal-header">
                    <center><h5 class="modal-title" id="modalWindowTitle">${title}</h5></center>
                </div>
              <div class="modal-body" style="margin: 0 auto;">
                <p>Хотите начать новую партию?</p>
              </div>
              <div class="modal-footer" style="margin: 0 auto;">
                <button type="button" class="btn btn-success" data-dismiss="modal" onclick='btnNewParty(true)'>Да</button>
                <button type="button" class="btn btn-danger" data-dismiss="modal" onclick='btnNewParty(false)'>Нет</button>
              </div>
            </div>
        </div>
    </div>`);
    $("#modalWindow").modal('show');
}
//Очитска игрального стола
function clearTable() {
    GUI.ACTIONS.hide();
    GUI.BANK.hide();
    GUI.DECK.hide();
    GUI.COMB_NAME.hide();

    for (let i = 1; i <= MAX_PLAYERS; i++) {
        $(`#player${i} .player-title`).empty();
        $(`#player${i} .player-cards`).empty();
    }
}