const task = document.getElementById('task')
function newEl(elementName) { return document.createElement(elementName); }
function clearTask(){
    let task = document.getElementById("task");
    while (task.firstChild){
        task.removeChild(task.firstChild);
    }
    document.onmousemove = '';
    document.onclick = '';
}
function addTaskDesc(text){
    let taskDesc = newEl('p');
    taskDesc.style.marginBottom = '50px';
    let descText = document.createTextNode(text);
    taskDesc.appendChild(descText);
    
    return taskDesc;
}
function randomNumberPage(){
    clearTask();
    
    let paragraph = newEl('p');
    let text = document.createTextNode('Случайное число:');
    paragraph.appendChild(text);
    
    let span = newEl('span');
    span.style.fontSize = '30px';
    let number = document.createTextNode(rand(0,100));
    span.appendChild(number);
    
    let br = newEl('br');
    
    let button = newEl('button');
    button.innerText = 'Сгенерировать новое число';
    button.style.height = '30px';
    button.onclick = function(){ randomNumberPage(); };
    
    task.appendChild(addTaskDesc('Создать html-страницу для генерации случайных чисел. На странице должна быть кнопка, при нажатии на которую случайное целое число от 0 до 100 выводится в div'));
    task.appendChild(paragraph);
    task.appendChild(span);
    task.appendChild(br);
    task.appendChild(button);
       
    function rand(min, max){
        return Math.floor(Math.random() * (max - min)) + min;
    }
}
function coordinatesPage(){
    clearTask();
    
    let taskDesc = newEl('p');
    taskDesc.style.marginBottom = '50px';
    let descText = document.createTextNode("");
    taskDesc.appendChild(descText);
    
    let paragraph = newEl('p');
    let XY = "X = " + event.clientX + ", Y = " + event.clientY;
    let text = document.createTextNode(XY);
    paragraph.appendChild(text);
    
    let paragraphButton = newEl('p');
    paragraphButton.id = 'XYtext'
    document.onclick = function(){        
        let XYtext = document.getElementById("XYtext");
        while (XYtext.firstChild){
            XYtext.removeChild(XYtext.firstChild);
        }
        
        let button = event.button;
        if(button == '0'){ button = "Нажата левая кнопка мыши" }
        else if(button == '1'){ button = "Нажата средняя кнопка мыши" }
        else if(button == '2'){ button = "Нажата правая кнопка мыши" };
        
        let text = document.createTextNode(button);
        XYtext = document.getElementById('XYtext');
        XYtext.appendChild(text);
    };
    
    
    document.onmousemove = function(){ coordinatesPage(); };
    task.appendChild(addTaskDesc('Создать html-страницу с div, который занимает всю ширину и высоту экрана. При движении мышкой внутри этого div, выводить текущие координаты мышки. При клике кнопкой мыши туда же, выводить, какой именно кнопкой был совершен клик (правой или левой)'));
    task.appendChild(paragraph);
    task.appendChild(paragraphButton);
}
function hideTextPage(){
    clearTask();
    
    let text = 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.';
    
    let textNode = document.createTextNode(text);
    let p = newEl('p');
    p.id = 'hidenText';
    p.appendChild(textNode);
    
    const hide = 'Скрыть текст'; const show = 'Показать текст';
    let button = newEl('button');
    button.innerText = hide;
    button.onclick = function(){
        let hidenText = document.getElementById('hidenText');
        
        if(button.innerText == hide){
            button.innerText = show;
            hidenText.innerHTML = '';
        }
        else if(button.innerText == show){
            button.innerText = hide;
            hidenText.innerHTML = text;
        }
    };
    
    task.appendChild(addTaskDesc('Создать html-страницу, на которой будет кнопка и текст. При \
нажатии на кнопку, текст должен скрываться. При повторном нажатии – текст должен снова отображаться'));
    task.appendChild(button);
    task.appendChild(p);
}
function tabsMenuPage(){
    clearTask();
    
    let div = newEl('div');
    div.id = 'taskFour';

    let menu = newEl('div');
    menu.id ='menuTaskFour';
    div.appendChild(menu);
    
    let ul = newEl('ul');
    menu.appendChild(ul);
    
    let li = newEl('li');
    li.id = '1';
    li.onclick = setText;
    li.appendChild(document.createTextNode('-HTML-'));
    ul.appendChild(li);
    li = newEl('li');
    li.id = '2';
    li.onclick = setText;
    li.appendChild(document.createTextNode('-CSS-'));
    ul.appendChild(li);
    li = newEl('li');
    li.id = '3';
    li.onclick = setText;
    li.appendChild(document.createTextNode('-JS-'));
    ul.appendChild(li);
    li = newEl('li');
    li.id = '4';
    li.onclick = setText;
    li.appendChild(document.createTextNode('-PHP-'));
    ul.appendChild(li);
    
    let textTask = newEl('div');
    textTask.id = 'textTaskFour';
    div.appendChild(textTask);
    
    task.appendChild(addTaskDesc('Создать html-страницу со вкладками. С левой стороны страницы отображается несколько вкладок, по которым можно переключаться. У каждой вкладки есть свое содержимое, но в один момент времени отображается содержимое только активной вкладки'));
    task.appendChild(div);
       
    function setText(){
        let id = this.id;
        let textTask = document.getElementById('textTaskFour');
        while (textTask.firstChild){ textTask.removeChild(textTask.firstChild); }
        let p = newEl('p');
        let textNode;

        if(id == '1'){ textNode = document.createTextNode('HTML HTML HTML'); }
        else if(id == '2'){ textNode = document.createTextNode('CSS CSS CSS'); }
        else if(id == '3'){ textNode = document.createTextNode('JS JS JS'); }
        else if(id == '4'){ textNode = document.createTextNode('PHP PHP PHP'); }

        p.appendChild(textNode);
        textTask.appendChild(p);
    }
}
function deleteItemPage(){
    clearTask();
    
    let div = newEl('div');
    div.id = 'taskFive';
    
    let ul = newEl('ul');
    ul.appendChild(addItemToFiveTask('111'));
    ul.appendChild(addItemToFiveTask('222'));
    ul.appendChild(addItemToFiveTask('333'));
    div.appendChild(ul);
    
    task.appendChild(addTaskDesc('Создать html-страницу со списком новостей. Возле каждой новости должна быть кнопка Удалить, при нажатии на которую соответствующая новость исчезает'));
    task.appendChild(div);
    
    function addItemToFiveTask(id){
        let text = 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.';

        let li = newEl('li');
        li.id = id;

        let p = newEl('p');
        p.appendChild(document.createTextNode(text));
        li.appendChild(p);

        let button = newEl('button');
        button.innerText = 'Удалить';
        button.onclick = function(){
            let liById = document.getElementById(id);
            liById.parentNode.removeChild(liById);
        };
        li.appendChild(button);

        return li;
    }
}
function progressBarPage(){
    clearTask();
    
    let progressBarContainer = newEl('div');
    progressBarContainer.id = 'progressBarContainer';
    
    let progressBar = newEl('div');
    progressBar.id = 'progressBar';
    progressBarContainer.appendChild(progressBar);
    progressBar.appendChild(document.createTextNode(' '));
    
    let button = newEl('button');
    button.id = 'progressBarButton';
    button.innerText = 'Добавить 5%';
    
    let width = 0;
    button.onclick = function(){
        let progressBar = document.getElementById('progressBar');
        if(width >= 100){ width = 0; }
        width += 5;
        progressBar.style.width = width + '%';
    };
    
    task.appendChild(addTaskDesc('Создать html-страницу с progressbar и кнопкой, при нажатии на которую заполненность progressbar увеличивается на 5%'));
    task.appendChild(progressBarContainer);
    task.appendChild(button);
}
function cellBacklightPage(){
    clearTask();
    
    let table = newEl('table');
    table.style.margin = '0 auto';
    for(let i = 0; i < 5; i++){
        let tr = newEl('tr');
        
        for(let j = 0; j < 3; j++){
            let td = newEl('td');
            td.appendChild(document.createTextNode(i + '.' + j));
            
            td.style.border = '1px solid black';
            td.style.padding = '3px 15px';
            
            td.onmouseover = function(){
                this.style.backgroundColor = 'lightgray';
            };
            td.onmouseout = function(){
                this.style.backgroundColor = '';
            };
            
            tr.appendChild(td);
        }
        table.appendChild(tr);
    }
    
    task.appendChild(addTaskDesc('Создать html-страницу с таблицей. При наведении мышкой на ячейку таблицы, у этой ячейки должен меняться фон. Учтите, что когда мышку уводят с ячейки, то ее фон возвращается к прежнему. Выполнить задание с помощью JS, а не с помощью CSS'));
    task.appendChild(table);
}
function likePage(){
    clearTask();
    
    let button = newEl('button');
    button.style.padding = '5px';
    let div = newEl('div')
    div.style.display = 'flex';
    button.appendChild(div);
    
    let img = newEl('img');
    img.style.width = '15px'; img.style.height = '15px';
    img.src = 'images/like_icon.png';
    img.style.margin = '0px 5px';
    div.appendChild(img);
    div.appendChild(document.createTextNode('Like'));
    let span = newEl('span');
    span.id = 'liked';
    span.style.margin = '0px 5px';
    span.innerHTML = '0';
    div.appendChild(span);
    
    button.onclick = function(){
        let liked = document.getElementById('liked');
        let count = liked.innerHTML;
        liked.innerHTML = ++count;
    };
    
    task.appendChild(addTaskDesc('Создать html-страницу с кнопкой Like, при нажатии на которую увеличивается счетчик лайков'));
    task.appendChild(button);
}
function calcPage(){
    clearTask();
    
    let action = '';
    
    let div = newEl('div');
    div.id = 'calc';
    
    let input = newEl('input');
    input.id = 'textarea';
    input.readOnly = true;
    div.appendChild(input);
    
    let table = newEl('table');
    let tr0 = newEl('tr');
    let td01 = newEl('td');
    td01.innerHTML = 'Стереть';
    td01.colSpan = '4';
    td01.onclick = function(){
        input.value = '';
        action = '';
    };
    tr0.appendChild(td01);
    table.appendChild(tr0);
    let tr1 = newEl('tr');
    let td11 = newEl('td');
    td11.innerHTML = '7';
    td11.onclick = pressingNumber;
    let td12 = newEl('td');
    td12.innerHTML = '8';
    td12.onclick = pressingNumber;
    let td13 = newEl('td');
    td13.innerHTML = '9';
    td13.onclick = pressingNumber;
    let td14 = newEl('td');
    td14.innerHTML = '+';
    td14.onclick = pressingAction;
    tr1.appendChild(td11);
    tr1.appendChild(td12);
    tr1.appendChild(td13);
    tr1.appendChild(td14);
    table.appendChild(tr1);
    let tr2 = newEl('tr');
    let td21 = newEl('td');
    td21.innerHTML = '4';
    td21.onclick = pressingNumber;
    let td22 = newEl('td');
    td22.innerHTML = '5';
    td22.onclick = pressingNumber;
    let td23 = newEl('td');
    td23.innerHTML = '6';
    td23.onclick = pressingNumber;
    let td24 = newEl('td');
    td24.innerHTML = '-';
    td24.onclick = pressingAction;
    tr2.appendChild(td21);
    tr2.appendChild(td22);
    tr2.appendChild(td23);
    tr2.appendChild(td24);
    table.appendChild(tr2);
    let tr3 = newEl('tr');
    let td31 = newEl('td');
    td31.innerHTML = '1';
    td31.onclick = pressingNumber;
    let td32 = newEl('td');
    td32.innerHTML = '2';
    td32.onclick = pressingNumber;
    let td33 = newEl('td');
    td33.innerHTML = '3';
    td33.onclick = pressingNumber;
    let td34 = newEl('td');
    td34.innerHTML = '*';
    td34.onclick = pressingAction;
    tr3.appendChild(td31);
    tr3.appendChild(td32);
    tr3.appendChild(td33);
    tr3.appendChild(td34);
    table.appendChild(tr3);
    let tr4 = newEl('tr');
    let td41 = newEl('td');
    td41.innerHTML = '0';
    td41.onclick = pressingNumber;
    let td42 = newEl('td');
    td42.innerHTML = '=';
    td42.onclick = function(){
        let arrNumbers = input.value.split(action, 2);
        
        if(arrNumbers.length == 2){
            if(action == '+'){ input.value = (parseInt(arrNumbers[0]) + parseInt(arrNumbers[1])); }
            else if(action == '-'){ input.value = (parseInt(arrNumbers[0]) - parseInt(arrNumbers[1])); }
            else if(action == '*'){ input.value = (parseInt(arrNumbers[0]) * parseInt(arrNumbers[1])); }
            else if(action == '/'){
                if(parseInt(arrNumbers[1]) == 0){ input.value = '0'; }
                else{ input.value = (parseInt(arrNumbers[0]) / parseInt(arrNumbers[1])); }
            }
            action = '';
        }
    };
    td42.colSpan = '2';
    let td44 = newEl('td');
    td44.innerHTML = '/';
    td44.onclick = pressingAction;
    tr4.appendChild(td41);
    tr4.appendChild(td42);
    tr4.appendChild(td44);
    table.appendChild(tr4);
    div.appendChild(table);
    
    task.appendChild(addTaskDesc('Создать html-страницу «Калькулятор». Реализовать его функциональность'));
    task.appendChild(div);
    
    function pressingNumber(){ input.value += this.innerText; }
    function pressingAction(){
        if(input.value != '' && action == ''){
            action = this.innerText;
            input.value += action;
        }
    }
}
function inputFilterPage(){
    clearTask();
    
    let input = newEl('input');
    input.oninput = function(){
        let arr = this.value.match(/[a-zA-Zа-яА-Я]/gi);
        this.value = (arr != null)?arr.join(''):'';
    };
    
    task.appendChild(addTaskDesc('Создать html-страницу для ввода имени пользователя. Необходимо проверять каждый символ, который вводит пользователь. Если он ввел цифру, то не отображать ее в input'));
    task.appendChild(document.createTextNode('Введите своё имя:'));
    task.appendChild(newEl('br'));
    task.appendChild(input);
}
function showWindowPage(){
    clearTask();
    
    let button = newEl('button');
    button.innerText = 'Открыть модальное окно';
    button.onclick = function(){
        let div = newEl('div');
        div.id = 'modalWindow';
        
        let message = newEl('div');
        message.id ='message';
        div.appendChild(message);
        
        let button = newEl('button');
        button.innerText = 'Закрыть';
        button.onclick = function(){
            let div = document.getElementById('modalWindow');
            div.parentNode.removeChild(div);
        };
        message.appendChild(document.createTextNode('Это модальное окно'));
        message.appendChild(newEl('br'));
        message.appendChild(button);
        
        let body = document.getElementById('body');
        body.insertBefore(div, body.firstChild);
        console.log(body);
    };
    
    task.appendChild(addTaskDesc('Создать html-страницу с кнопкой Открыть и модальным окном. На модальном окне должен быть текст и кнопка Закрыть. Изначально модальное окно не отображается. При клике на кнопку Открыть появляется модальное окно, на кнопку Закрыть – исчезает'));
    task.appendChild(button);
}
function footballFieldPage(){
    clearTask();
    
    let div = newEl('div');
    div.id = 'field-border';
    let field = newEl('div');
    field.id = 'field';
    
    //Отправная точка мяча
    const ballCenter = 25;
    let srcX = 300; let srcY = 185;
    field.onclick = function(){
        //Позиция футбольного поля
        let fieldRect = this.getBoundingClientRect();
        //Текущая точка мяча
        let ball = document.getElementById('ball');
        //Конечная точка мяча
        let dstX = parseInt(event.clientX - fieldRect.x - ballCenter);
        let dstY = parseInt(event.clientY - fieldRect.y - ballCenter);
        
        console.log('dx:' + dstX + ',dy: ' + dstY);
        console.log(fieldRect);
        //Условие при выходе за границу поля
        if(dstX < 40) dstX = 40;
        if(dstX > 560) dstX = 560;
        if(dstY < 28) dstY = 28;
        if(dstY > 350) dstY = 350;
        
        let startX = srcX, startY = srcY;
        let endX = dstX, endY = dstY;
        if(srcX > dstX){ startX *= -1; endX *= -1; }
        if(srcY > dstY){ startY *= -1; endY *= -1; }
        let timerID = setInterval(function(){
            if(startX != endX) ++startX;
            if(startY != endY) ++startY;
            if(startX == endX && startY == endY) clearInterval(timerID);
            
            ball.style.marginLeft = Math.abs(startX) + 'px';
            ball.style.marginTop = Math.abs(startY) + 'px';
        }, 1);
        
        srcX = parseInt(dstX);
        srcY = parseInt(dstY);
    };
    
    div.appendChild(field);
    
    let img = newEl('img');
    img.id = 'ball';
    img.src = 'images/ball.png';
    field.appendChild(img);
    
    task.appendChild(addTaskDesc('Создать html-страницу с футбольным полем, которое занимает всю ширину и высоту экрана, и мячом размером 100 на 100 пикселей. Сделать так, чтобы при клике мышкой по полю, мяч плавно перемещался на место клика. Учтите: необходимо, чтобы центр мяча останавливался именно там, где был совершен клик мышкой. Также предусмотрите, чтобы мяч не выходил за границы поля'));
    task.appendChild(div);
}
function trafficLightsPage(){
    clearTask();
    
    let trafficLightsDiv = newEl('div');
    trafficLightsDiv.id = 'traffic-lights-div';
    
    task.appendChild(addTaskDesc('Создать html-страницу со светофором и кнопкой, которая переключает светофор на следующий цвет'));
    task.appendChild(trafficLightsDiv);
    
    let trafficLights = newEl('div');
    trafficLights.id = 'traffic-lights'
    trafficLightsDiv.appendChild(trafficLights);
    
    let ul = newEl('ul');
    trafficLights.appendChild(ul);
    
    let liRed = newEl('li');
    liRed.style.backgroundColor = 'red';
    ul.appendChild(liRed);
    let liYellow = newEl('li');
    ul.appendChild(liYellow);
    let liGreen = newEl('li');
    ul.appendChild(liGreen);
    
    let button = newEl('button');
    button.innerText = 'Вперёд';
    let currPosition = 0;
    button.onclick = function(){
        const colors = [ 'red', 'yellow', 'green'];
        const lis = [ liRed, liYellow, liGreen ];
        
        lis[currPosition].style.backgroundColor = 'gray';
        currPosition++;
        if(currPosition >= 3) currPosition = 0;
        lis[currPosition].style.backgroundColor = colors[currPosition];
    };
    trafficLightsDiv.appendChild(button);
    
    
}
function listBookPage(){
    clearTask();
    
    let div = newEl('div');
    div.id = 'text-list';
    
    task.appendChild(addTaskDesc('Создать html-страницу со списком книг. При щелчке на книгу, цвет фона должен меняться на оранжевый. Учтите, что при повторном щелчке на другую книгу, предыдущей – необходимо возвращать прежний цвет'));
    task.appendChild(div);
    
    let ul = newEl('ul');
    div.appendChild(ul);
    
    let prevElement = 0;
    for(let i = 0; i < 7; i++){
        let text = 'Lorem ipsum dolor sit amet';
        let li = newEl('li');
        
        li.onclick = function(){
            if(prevElement != 0) prevElement.style.backgroundColor = '';
            this.style.backgroundColor = 'orange';
            prevElement = this;
        };
        li.innerHTML = text;
        ul.appendChild(li);
    }
}
function listLinksPage(){
    clearTask();
    
    let div = newEl('div');
    div.id = 'links-list';
    
    task.appendChild(addTaskDesc('Создать html-страницу со списком ссылок. Ссылки на внешние источники (которые начинаются с http://) необходимо подчеркнуть пунктиром. Искать такие ссылки в списке и устанавливать им дополнительные стили необходимо с помощью JS'));
    task.appendChild(div);
    
    let ul = newEl('ul');
    div.appendChild(ul);
    
    let li = newEl('li');
    li.innerHTML = '<span>index.html</span>';
    ul.appendChild(li);
    li = newEl('li');
    li.innerHTML = '<span>http://google.com</span>';
    ul.appendChild(li);
    li = newEl('li');
    li.innerHTML = '<span>https://itstep.org</span>';
    ul.appendChild(li);
    li = newEl('li');
    li.innerHTML = '<span>https://mystat,itstep.org</span>';
    ul.appendChild(li);
    li = newEl('li');
    li.innerHTML = '<span>/images/cat.jpg</span>';
    ul.appendChild(li);
    li = newEl('li');
    li.innerHTML = '<span>/local/path</span>';
    ul.appendChild(li);
    
    let lis = ul.childNodes;
    for(let i = 0; i < lis.length; i++){
        let text = lis[i].innerHTML;
        console.log(text);
        if(text.search('http|https') != -1)
        {
            lis[i].childNodes[0].style.borderBottom = '1px dotted gray';
        }
    }
}
function treeDirPage(){
    clearTask();
    
    let div = newEl('div');
    div.id = 'tree-dir';
    
    task.appendChild(addTaskDesc('Создать html-страницу с деревом вложенных директорий. При клике на элемент списка, он должен сворачиваться или разворачиваться. При наведении на элемент, шрифт должен становится жирным (с помощью CSS)'));
    task.appendChild(div);
    
    let ul1 = newEl('ul');
    div.appendChild(ul1);
    let li1 = newEl('li');
    li1.onclick = treeOpenClose;
    li1.innerHTML = '<span>This PC</span>';
    ul1.appendChild(li1);
    
    let ul = newEl('ul');
    li1.appendChild(ul);
    for(let i = 0; i < 3; i++){
        let li2 = newEl('li');
        li2.onclick = treeOpenClose;
        li2.innerHTML = `<span>Local Disk (${String.fromCharCode(i + 67)}:)</span>`;
        ul.appendChild(li2);
        
        let ul2 = newEl('ul');
        li2.appendChild(ul2);
        for(let j = 0; j < 3; j++){
            let li3 = newEl('li');
            li3.onclick = treeOpenClose;
            li3.innerHTML = `<span>New Folder ${j + 1}</span>`;
            ul2.appendChild(li3);
        }
    }
    
    function treeOpenClose(){
        event.stopPropagation();
        let childs = this.childNodes;
        for(let i = 0; i < childs.length; i++){
            if(childs[i].tagName == 'UL'){
                let display = childs[i].style.display;
                childs[i].style.display = (display == "none")?"block":"none";
            }
        }
    }
}
function textListSelectPage(){
    clearTask();
    
    let div = newEl('div');
    div.id = 'text-list';
    
    task.appendChild(addTaskDesc('Создать html-страницу со списком книг. При щелчке на элемент, цвет текста должен меняться на оранжевый. При повторном щелчке на другую книгу, предыдущей необходимо возвращать прежний цвет. Если при клике мышкой была зажата клавиша Ctrl, то элемент добавляется/удаляется из выделенных. Если при клике мышкой была зажата клавиша Shift, то к выделению добавляются все элементы в промежутке от предыдущего кликнутого до текущего'));
    task.appendChild(div);
    
    let ul = newEl('ul');
    div.appendChild(ul);
    
    let prevElement = 0;
    let selectedItems = [];
    
    for(let i = 0; i < 7; i++){
        let text = 'Lorem ipsum dolor sit amet';
        let li = newEl('li');
        li.id = i;
        
        li.onclick = function(){
            if(event.ctrlKey){ selectedItems.push(this); }
            else if(event.shiftKey){
                if(prevElement != 0 && prevElement.style.backgroundColor != ''){
                    let start = +prevElement.id; let end = +this.id;
                    if(start > end) { end = start; start = +this.id};
                    selectedItems.push(this);
                    for(let i = start; i < end; i++){
                        let item = this.parentNode.childNodes[i];
                        selectedItems.push(item);
                        item.style.backgroundColor = 'orange';
                    }
                }
            }
            else{
                for(let item of selectedItems)
                {
                    item.style.backgroundColor = '';
                }
                if(prevElement != 0) prevElement.style.backgroundColor = '';
                prevElement = this;
            }
            this.style.backgroundColor = 'orange';
        };
        li.innerHTML = text;
        ul.appendChild(li);
    }
}
function showEditTextPage(){
    clearTask();
    
    let div = newEl('div');
    div.id = 'show-edit-text';
    
    task.appendChild(addTaskDesc('Создать html-страницу для отображения/редактирования текста. При открытии страницы текст отображается с помощью тега div. При нажатии Ctrl+E, вместо div появляется textarea с тем же текстом, который теперь можно редактировать. При нажатии Ctrl+S, вместо textarea появляет div с уже измененным текстом. Не забудьте выключить поведение по умолчанию для этих сочетаний клавиш'));
    task.appendChild(div);
    
    div.appendChild(document.createTextNode('Press Ctrl+E for edit text'));
    div.appendChild(newEl('br'));
    div.appendChild(document.createTextNode('Press Ctrl+S for save text'));
    div.appendChild(newEl('hr'));
    
    let span = newEl('span');
    span.innerText = 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.';
    div.appendChild(span);
    
    let textarea = newEl('textarea');
    textarea.readOnly = false;
    textarea.style.display = 'none';
    div.appendChild(textarea);
    
    addEventListener('keydown', function(){
        if(event.ctrlKey && (event.key == 'e' || event.key == 'E')){
            event.preventDefault();
            exchange(span, textarea);
        }
        else if(event.ctrlKey && (event.key == 's' || event.key == 'S')){
            event.preventDefault();
            exchange(textarea, span);
        }
    });
    
    function show(el){ el.style.display = 'block'; }
    function hide(el){ el.style.display = 'none'; }
    
    function exchange(src, dst){
            let text = src.innerText == '' ? src.value : src.innerText;
            dst.innerText = text;
            show(dst); hide(src);
    }
}
function tableSortPage(){
    clearTask();
    
    class Person{
        constructor(Firstname, Lastname, Age, Company){
            this.Firstname = Firstname;
            this.Lastname = Lastname;
            this.Age = Age;
            this.Company = Company;
        }
    }
    
    let div = newEl('div');
    div.id = 'table-sort';
    
    task.appendChild(addTaskDesc('Создать html-страницу с большой таблицей. При клике по заголовку колонки, необходимо отсортировать данные по этой колонке. Например: на скриншоте люди отсортированы по возрасту. Учтите, что числовые значения должны сортироваться как числа, а не как строки'));
    task.appendChild(div);
    
    let table = newEl('table');
    div.appendChild(table);
    
    let tr = newEl('tr');
    table.appendChild(tr);
    
    //Получаем название полей у класса Person и добавляем в столбцы
    for(item of Object.keys(new Person)){
        let td = newEl('td');
        td.onclick = colSort;
        td.innerText = item;
        tr.appendChild(td);
    }
    
    let persons = [];
    persons.push(new Person('Timothy', 'Cok', 57, 'Apple'))
    persons.push(new Person('Bill', 'Gates', 62, 'Microsoft'));
    persons.push(new Person('Mark', 'Zuckerberg', 34, 'Facebok'));
    persons.push(new Person('Larry', 'Page', 45, 'Google'));
    persons.push(new Person('Larry', 'Page', 4, 'Google'));
    persons.push(new Person('Larry', 'Page', 0, 'Google'));
    for(item of persons){ addRow(item); }
    
    function addRow(person){
        let tr = newEl('tr');
        table.appendChild(tr);
        let td = newEl('td');
        td.innerText = person.Firstname;
        tr.appendChild(td);
        td = newEl('td');
        td.innerText = person.Lastname;
        tr.appendChild(td);
        td = newEl('td');
        td.innerText = person.Age;
        tr.appendChild(td);
        td = newEl('td');
        td.innerText = person.Company;
        tr.appendChild(td);
        
        table.appendChild(tr);
    }
    function clearRows(){
        let count = table.childNodes.length;
        for(let i = 1; i < count; i++){
            table.removeChild(table.lastChild);
        }
    }
    function colSort(){
        clearRows();
        
        let colToSort = this.innerText;
        
        function compare(o1, o2){
            if(o1[colToSort] > o2[colToSort]) return 1;
            else if(o1[colToSort] < o2[colToSort]) return -1;
            else return 0;
        }
        
        persons.sort(compare);
        
        for(item of persons){ addRow(item); }
    }
}
function resizeBlockPage(){
    clearTask();
    
    let div = newEl('div');
    div.id = 'resize-block';
    
    task.appendChild(addTaskDesc('Создать html-страницу с блоком текста в рамочке. Реализовать возможность изменять размер блока, если зажать мышку в правом нижнем углу и тянуть ее дальше'));
    task.appendChild(div);
    
    let spanDiv = newEl('div');
    spanDiv.id = 'span-text'
    div.appendChild(spanDiv);
    
    let span = newEl('span');
    span.innerText = 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.';
    spanDiv.appendChild(span);
    
    let imgDiv = newEl('div');
    imgDiv.id = 'triangle'
    div.appendChild(imgDiv);
    
    const triangleWidth = 15;
    let img = newEl('img');
    img.src = "images/resize-triangle.png";
    img.onmousedown = function(){
        const rect = div.getBoundingClientRect();
        
        document.body.onmousemove = function(){
            event.preventDefault();
            let Width = (event.clientX - rect.x) + 5;
            let Height = (event.clientY - rect.y) + 5;
            div.style.width = Width + 'px';
            div.style.height = Height + 'px';
        };
    };
    img.onmouseup = function(){
        document.body.onmousemove = null;
    };
    
    imgDiv.appendChild(img);
}