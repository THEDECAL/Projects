const PAGE = { $task: $('#task') };
function newEl(elementName) { return document.createElement(elementName); }
function forumMessagesPage(){
    PAGE.$task.empty();
    addTaskDesc('Создать html-страницу со списком сообщений на форуме и формой для добавления нового сообщения. После заполнения формы добавить сообщение к списку на экране.');
    
    let div = newEl('div');
    $(div).attr('id', 'forum');
    PAGE.$task.append(div);

    let ul = newEl('ul');
    $(ul).attr('id', 'messages');
    $(ul).attr('type', 'none');
    $(div).append(ul);

    let form = newEl('div');
    $(div).append(form);

    let p = newEl('p');
    $(p).text('Добавить новое сообщение:');
    $(form).append(p);

    let input = newEl('input');
    $(input).css('width', '100%');
    $(input).attr('placeholder', 'Ваше имя...');
    $(form).append(input);
    $(form).append(newEl('br'));

    let textarea = newEl('textarea');
    $(textarea).css('width', '100%');
    $(textarea).attr('placeholder', 'Ваше сообщение...');
    $(form).append(textarea);

    let button = newEl('button');
    $(button).bind('click', function(){
        let currDate = dateFormat(new Date());
        let name = $('input').val();
        let text = $('textarea').val();
        
        let li = newEl('li');
        $('#messages').append(li);

        let table = newEl('table');
        $(li).append(table);

        let tr1 = newEl('tr');
        $(table).append(tr1);
        let td1 = newEl('td');
        $(td1).css('display', 'flex');
        $(td1).css('justify-content', 'space-between');
        $(tr1).append(td1);

        let spanName = newEl('span');
        $(spanName).text(name);
        $(td1).append(spanName);

        let spanDate = newEl('span');
        $(spanDate).text(currDate);
        $(td1).append(spanDate);

        let tr2 = newEl('tr');
        $(table).append(tr2);
        let td2 = newEl('td');
        $(tr2).append(td2);
        $(td2).text(text);

        $('input').val('');
        $('textarea').val('');
    });
    $(button).css('width', '100px');
    $(button).css('height', '30px');
    $(button).text('Отправить');
    $(form).append(button);

    // console.log(document.getElementById('task'));
    function dateFormat(date){
        let h = (date.getHours() < 10) ? '0' + date.getHours() : date.getHours();
        let m = (date.getMinutes() < 10) ? '0' + date.getMinutes() : date.getMinutes();
        let s = (date.getSeconds() < 10) ? '0' + date.getSeconds() : date.getSeconds();

        let d =  (date.getDay() < 10) ? '0' + date.getDay() : date.getDay();
        let mo = (date.getMonth() < 10) ? '0' + date.getMonth() : date.getMonth();

        return h + ':' + m + ':' + s + ' ' + d + '.' + mo + '.' + date.getFullYear();
    }
}
function addTaskDesc(text){
    let p = newEl('p');
    p.style.marginBottom = '50px';
	p.style.textAlign = 'left';
    p.innerHTML = text;
    PAGE.$task.append(p);
}
function testPage(){
    PAGE.$task.empty();
    addTaskDesc('Создать html-страницу для прохождения теста. Вопросы теста имеют два варианта ответа (только 1 правильный). После прохождения теста, вывести количество правильных ответов.');

    class Question{
        constructor(question, firstAnswer, secondAnswer){
            this.question = question;
            this.firstAnswer = firstAnswer;
            this.secondAnswer = secondAnswer;
        }
    }

    let questions = [];
    questions.push(new Question('Сколько букв в слове "Привет"?', '6', '2'));
    questions.push(new Question('Сколько букв в слове "Мир"?', '3', '5'));
    questions.push(new Question('Сколько букв в слове "JS"?', '2', '3'));

    
    let div = newEl('div');
    PAGE.$task.append(div);

    let cnt = 0;
    let correctAnswers = 0;
    showQuestion();

    function showQuestion(){
        let q = questions[cnt];

        $(div).empty();

        let p = newEl('p');
        $(p).text((cnt + 1) + ') ' + q.question);
        $(div).append(p);

        let prbtn1 = newEl('p');
        $(div).append(prbtn1);
        let rbtn1 = newEl('input');
        $(rbtn1).attr('id', 'firstAnswer');
        $(rbtn1).attr('type', 'radio');
        $(rbtn1).attr('name', 'test');
        $(prbtn1).append(rbtn1);
        $(prbtn1).append(q.firstAnswer);

        let prbtn2 = newEl('p');
        $(div).append(prbtn2);
        let rbtn2 = newEl('input');
        // $(rbtn2).attr('id', 'secondAnswer');
        $(rbtn2).attr('type', 'radio');
        $(rbtn2).attr('name', 'test');
        $(prbtn2).append(rbtn2);
        $(prbtn2).append(q.secondAnswer);

        let button = newEl('button');
        $(div).append(button);

        if(cnt != questions.length - 1){
            $(button).text('Следующий');
            $(button).bind('click', function(){
                cnt++;
                if($('#firstAnswer:checked').val() === 'on'){
                    correctAnswers++;
                }
                showQuestion();
            });
        }
        else{
            $(button).text('Финиш');
            $(button).bind('click', function(){
                if($('#firstAnswer:checked').val() === 'on'){
                    correctAnswers++;
                }
                
                $(div).empty();
                let p = newEl('p');
                $(p).text('Результат: ' + correctAnswers + '/' + questions.length);
                $(div).append(p);
            });
        }
    }
}
function stylizedTextPage(){
    PAGE.$task.empty();
    addTaskDesc('Создать html-страницу с формой для ввода стилизованного текста. После заполнения формы, вывести текст на экран в соответствии с указанными стилями.');

    let div = newEl('div');
    $(div).attr('id', 'stylized-text');
    PAGE.$task.append(div);

    let label = newEl('label');
    let bold = newEl('input');
    $(bold).attr('type', 'checkbox');
    $(bold).attr('value', 'bold');
    $(bold).attr('name', 'fstyle');
    $(label).append(bold);
    $(label).append('Bold');
    $(div).append(label);

    label = newEl('label');
    let uline = newEl('input');
    $(uline).attr('type', 'checkbox');
    $(uline).attr('value', 'underline');
    $(uline).attr('name', 'fstyle');
    $(label).append(uline);
    $(label).append('Underline');
    $(div).append(label);

    label = newEl('label');
    let italics = newEl('input');
    $(italics).attr('type', 'checkbox');
    $(italics).attr('value', 'italic');
    $(italics).attr('name', 'fstyle');
    $(label).append(italics);
    $(label).append('Italics');
    $(div).append(label);

    label = newEl('label');
    let left = newEl('input');
    $(left).attr('type', 'radio');
    $(left).attr('value', 'left');
    $(left).attr('name', 'align');
    $(left).attr('checked', '');
    $(label).append(left);
    $(label).append('Left');
    $(div).append(label);

    label = newEl('label');
    let right = newEl('input');
    $(right).attr('type', 'radio');
    $(right).attr('value', 'right');
    $(right).attr('name', 'align');
    $(label).append(right);
    $(label).append('Right');
    $(div).append(label);

    label = newEl('label');
    let justify = newEl('input');
    $(justify).attr('type', 'radio');
    $(justify).attr('value', 'justify');
    $(justify).attr('name', 'align');
    $(label).append(justify);
    $(label).append('Justify');
    $(div).append(label);

    let textarea = newEl('textarea');
    $(div).append(textarea);

    let btn = newEl('button');
    $(btn).text('Применить');
    $(btn).bind('click', function(){
        let text = $(textarea).val();
        let align = $('input[name=align]:checked').val();
        let span = newEl('span');
        let stylizedText = $('#stylized-text');
        let bold = $('input[name=fstyle][value=bold]:checked').val();
        let italic = $('input[name=fstyle][value=italic]:checked').val();
        let uline = $('input[name=fstyle][value=underline]:checked').val();

        $(stylizedText).css('text-align', align);
        // console.log($('input[name=fstyle][value=bold]:checked').val());
        if(bold != 'undefined'){ $(span).css('font-weight', bold); }
        if(italic != 'undefined'){ $(span).css('font-style', italic); }
        if(uline != 'undefined'){ $(span).css('text-decoration', uline); }

        $(div).empty();
        $(span).text(text);
        $(div).append(span);
    });
    $(div).append(btn);
}
function bookShopPage(order){
    PAGE.$task.empty();
    addTaskDesc('Создать html-страницу для магазина книг. Пользователь должен иметь возможность выбрать книгу, указать количество экземпляров, ввести свое имя, дату доставки, адрес доставки и комментарий. После заполнения формы необходимо вывести на экран: «Имя покупателя, спасибо за заказ. Такой-то товар будет доставлен в такую-то дату по такому-то адресу».');

    class Book{
        constructor(name, author, price, imgUri){
            this.name = name;
            this.author = author;
            this.price = price;
            this.imgUri = imgUri;
        }
    }

    let div = newEl('div');
    $(div).attr('id', 'book-shop');
    PAGE.$task.append(div);

    if(order === undefined){
        let books = initBooks();

        let ul = newEl('ul');
        $(div).append(ul);

        for(let book of books){
            let li = newEl('li');
            $(ul).append(li);

            $(li).append(`<img src='${book.imgUri}'><h2>${book.name}</h2><h3>${book.author}</h3><h1>${book.price}$</h1>`);
            
            let btn = newEl('button');
            $(btn).text('Выбрать');
            $(btn).bind('click', function(){ $('input[name=selected-book]').val(book.name); });
            $(li).append(btn);
        }

        let form = newEl('form');
        $(div).append(form);

        $(form).append(`<label>Выбранная книга:<input name='selected-book' placeholder='Выберите книгу...' disabled></label>`);
        $(form).append(`<label>Количество:<input name='count' type='number' min='1' value='1'></label>`);
        $(form).append(`<label>Ваше имя:<input name='customer-name'></label>`);
        $(form).append(`<label>Адрес доставки:<input name='address'></label>`);
        $(form).append(`<label>Дата доставки:<input name='date' type='date'></label>`);
        $(form).append(`<label>Коментарии:<input name='comment'></label>`);

        let btn = newEl('button');
        $(btn).css('width', '100%');
        $(btn).text('Купить');
        $(btn).bind('click', function(){
            let selectedBook = $('input[name=selected-book]').val();

            if(selectedBook != ''){
                let order = {
                    bookName: selectedBook,
                    count: $('input[name=count]').val(),
                    customerName: $('input[name=customer-name]').val(),
                    address: $('input[name=address]').val(),
                    date: $('input[name=date]').val(),
                    comment: $('input[name=comment]').val()
                }
                bookShopPage(order);
            }
            else { bookShopPage(); }
        });
        $(form).append(btn);
    }
    else{
        let block = newEl('div');
        $(block).attr('id', 'order');
        $(div).append(block);

        $(block).append(`<p>Спасибо за заказ ${order.customerName}!<br><br>Книга "${order.bookName}" будет доставлена ${order.date} по адресу ${order.address}</p>`);
    }

    function initBooks(){
        let books = JSON.parse(localStorage.getItem('books'));

        if(books === null){
            books = [];
            books.push(new Book('JavaScript and JQuery: Interactive Front-End Web Development', 'Jon Duckett', 22, 'images/book1.jpg'));
            books.push(new Book('JavaScript. Подробное руководство', 'Дэвид Флэнаган', 16, 'images/book2.jpg'));
            books.push(new Book('You Don\'t Know JS: Up & Going', 'Kyle Simpson', 20, 'images/book3.jpg'));

            localStorage.setItem('books', JSON.stringify(books));
        }

        return books;
    }
}
function logBook(){
    PAGE.$task.empty()
    addTaskDesc('Создать html-страницу с возможностью отмечать присутствующих на паре. Для начала пользователь выбирает группу и пару, дальше вводит тему занятия и отмечает присутствующих. Также добавить возможность посмотреть уже отмеченные пары. Хранить информацию в заранее подготовленных массивах.')

    class Group{
        constructor(name, students, lessons){
            this.name = name
            this.students = students
            this.lessons = lessons
        }
    }

    class Lesson{
        constructor(topic, studentsCnt){
            this.topic = topic
            this.attendance = []

            for(let i = 0; i < studentsCnt; i++)
                this.attendance.push(false)
        }
        addStudentPresence(studentIndex, presence){ this.attendance[studentIndex] = presence }
    }

    //Генерация групп, студентов, пар
    let groups = []
    let groupsCnt = randNum(3, 5)
    for(let i = 0; i < groupsCnt; i++){
        let students = []
        let lessons = []

        let studentsCnt = randNum(2, 5)
        for(let j = 0; j < studentsCnt; j++)
            students.push(randName())

        let lessonsCnt = randNum(3, 6);
        for(let j = 0; j < lessonsCnt; j++)
            lessons.push(new Lesson('', studentsCnt))

        groups.push(new Group('Группа-' + (i + 1), students, lessons))
    }

    // console.log(groups);

    let logBook = newEl('div')
    $(logBook).attr('id', 'log-book')
    PAGE.$task.append(logBook)
    initSelectGroup();

    let divShowGroup = newEl('div')
    $(divShowGroup).attr('id', 'show-group')
    $(logBook).append(divShowGroup)
    showGroup()

    function initSelectGroup(){
        let group = newEl('div')
        $(logBook).append(group)
    
        let groupLabel = newEl('label')
        $(groupLabel).append('Группа:')
        $(group).append(groupLabel)
    
        let slctGroup = newEl('select');
        $(slctGroup).attr('value', 'group');
        $(slctGroup).bind('change', changeGroup)
        $(groupLabel).append(slctGroup);
    
        for(let i = 0; i < groups.length; i++){
            let option = newEl('option');
            $(option).append(groups[i].name);
            $(slctGroup).append(option);
        }
    
        let lessonLabel = newEl('label')
        $(lessonLabel).append('Пара:')
        $(group).append(lessonLabel)
    
        let slctLesson = newEl('select')
        $(slctLesson).attr('value', 'lesson')
        $(lessonLabel).append(slctLesson)
        
        let button = newEl('button');
        $(button).append('Выбрать');
        $(button).bind('click', showGroup);
        $(group).append(button);

        changeGroup()
    }

    function changeGroup(){
        let selectGroup = $("select[value=group]").val()
        let selectLesson = $("select[value=lesson]")
        let groupIndex = groups.findIndex(g => g.name === selectGroup)
        $(selectLesson).empty()

        //Показать пары в группе
        for(let i = 0; i < groups[groupIndex].lessons.length; i++){
            let option = newEl('option')
            $(option).append(i + 1)
            $(selectLesson).append(option)
        }
    }

    function showGroup(isEdit){
        let divShowGroup = $("#show-group")
        let selectGroup = $("select[value=group]").val()
        let lessonIndex = $("select[value=lesson]").val()
        let groupIndex = groups.findIndex(g => g.name === selectGroup)
        let currGroup = groups[groupIndex]
        let currLesson = currGroup.lessons[lessonIndex - 1]
        let currStudents = groups[groupIndex].students
        let currAttendance = currLesson.attendance;
        
        $(divShowGroup).empty()
        if(isEdit != true){
            let topicLabel = newEl('label')
            $(topicLabel).append('Тема: ' + currLesson.topic)
            $(divShowGroup).append(topicLabel)

            let table = newEl('table');
            $(table).append(`<tr><td>Имя Фамилия</td><td>Посещаемость</td></tr>`);
            $(divShowGroup).append(table);
            
            for(let i = 0; i < currStudents.length; i++){
                let attendance = (currAttendance[i] === false) ? 'Отсутствовал' : 'Присутствовал'
                $(table).append(`<tr><td>${currStudents[i]}</td><td>${attendance}</td></tr>`);
            }

            let button = newEl('button');
            $(button).append('Изменить');
            $(button).bind('click', () => { showGroup(true) });
            $(divShowGroup).append(button);
        }
        else{
            let topicLabel = newEl('label')
            $(topicLabel).append('Тема: ' + `<input name="topic" value=${currLesson.topic}>`)
            $(divShowGroup).append(topicLabel)

            let table = newEl('table');
            $(table).append(`<tr><td>Имя Фамилия</td><td>Посещаемость</td></tr>`);
            $(divShowGroup).append(table);
            
            for(let i = 0; i < currStudents.length; i++){
                let attendance = (currAttendance[i] === false) ? '' : 'checked'
                $(table).append(`<tr><td>${currStudents[i]}</td><td><input name="att" type="checkbox" ${attendance}></td></tr>`);
            }

            let cancel = newEl('button');
            $(cancel).append('Отмена');
            $(cancel).bind('click', showGroup);
            $(divShowGroup).append(cancel);

            let save = newEl('button');
            $(save).append('Сохранить');
            $(save).bind('click', function(){
                let checkBoxes = $("input[name=att]")
                let topic = $("input[name=topic]")
                currLesson.topic = $(topic).val()

                for(let i = 0; i < checkBoxes.length; i++)
                    currAttendance[i] = checkBoxes[i].checked

                showGroup()
            });
            $(divShowGroup).append(save);
        }
    }
}

fNames = [
    'Алексей', 'Артём', 'Вадим', 'Владимир', 'Валентин', 'Данил', 'Денис', 'Дмитрий',
    'Егор', 'Кирилл', 'Леонид', 'Максим', 'Матвей', 'Никита', 'Олег',
    'Павел', 'Пётр', 'Роман', 'Сергей', 'Станислав'
]
sNames = [
    'Иванов', 'Смирнов', 'Кузнецов', 'Попов', 'Васильев', 'Петров', 'Соколов',
    'Михайлов', 'Новиков', 'Фёдоров', 'Морозов', 'Волков', 'Алексеев', 'Лебедев',
    'Семёнов', 'Егоров', 'Павлов', 'Козлов', 'Степанов', 'Николаев'
]
function randName(){ return fNames[randNum(0, fNames.length)] + ' ' + sNames[randNum(0, sNames.length)] }
function randNum(min, max){ return parseInt(Math.random() * (max - min) + min); }

function tickedBookingPage(){
    PAGE.$task.empty()
    addTaskDesc('Создать html-страницу с возможностью забронировать билеты на поезд. Для начала пользователь выбирает направление поезда и дату поездки, дальше отмечает места для брони. Также добавить возможность посмотреть уже забронированные билеты. Хранить информацию в заранее подготовленных массивах.')

    const seatsCount = 28
	const priceOnTicked = 62
    class Flight{
        constructor(direction, date){
            this.direction = direction
            this.date = date
            
            this.seats = []
            for(let i = 0; i < seatsCount; i++){
                this.seats.push(false);
            }
        }
    }
    
    let tickedBooking = newEl('div')
    $(tickedBooking).attr('id','ticked-booking')
    PAGE.$task.append(tickedBooking)

    let directionSearch = newEl('div')
    $(directionSearch).attr('id', 'flight-search')
    $(tickedBooking).append(directionSearch)

    let directionLabel = newEl('label')
    $(directionLabel).append('Направление:')
    $(directionSearch).append(directionLabel)

    let directionSelect = newEl('select')
    $(directionSelect).attr('name', 'direction')
    $(directionLabel).append(directionSelect)

    let directions = [ 'Днепр - Киев', 'Днепр - Одесса', 'Днепр - Львов' ]
    for(let direction of directions)
        $(directionSelect).append(`<option>${direction}</option>`)

    let dateLabel = newEl('label')
    $(dateLabel).append('Дата:' + '<input name=date type=date>')
    $(directionSearch).append(dateLabel)

    let btn = newEl('button')
    $(btn).append('Искать')
    $(btn).bind('click', showFlight)
    $(directionSearch).append(btn)
    
    let selectedFlight = newEl('div');
    $(selectedFlight).attr('id', 'selected-flight')
    $(tickedBooking).append(selectedFlight)
    
    function showFlight(isEdit){
        let selectedFlight = $('#selected-flight')
        let selectedDirection = $('select[name=direction]')
        let selectedDate = $('input[name=date]')
        
        $(selectedFlight).empty()
        if(selectedDate.val() != ''){
            let allFlights = JSON.parse(localStorage.getItem('flights'))
			if(allFlights == null) allFlights = []
			let findSelectedFlightIndex = allFlights.findIndex(f => f.date === selectedDate.val() && f.direction === selectedDirection.val())
            let currFlight = (findSelectedFlightIndex === -1) ? new Flight(selectedDirection.val(), selectedDate.val()) : allFlights[findSelectedFlightIndex]
			let selectedSeats = []
			
            let table = newEl('table')
            $(selectedFlight).append(table)
            let tr1 = newEl('tr'); $(table).append(tr1)
            let tr2 = newEl('tr'); $(table).append(tr2)
            
            for(let i = 0; i < seatsCount; i++){
                let seatLabel = newEl('label')
                let seatCheckbox = newEl('input')
                $(seatCheckbox).attr('name', 'seat')
                $(seatCheckbox).attr('type', 'checkbox')
                $(seatCheckbox).attr('value', i + 1)
                $(seatCheckbox).bind('change', function(){
					let price = $('#price')
					if(this.checked == true){
						$(price).text(parseInt(price.text()) + priceOnTicked)
						selectedSeats.push(this.value)
					}
					else{
						$(price).text(parseInt(price.text()) - priceOnTicked)
						let index = selectedSeats.findIndex(s => s === this.value)
						selectedSeats.splice(index, 1)
					}
				})
                
                if(currFlight.seats[i] === true){
                    $(seatCheckbox).attr('checked', '')
                    $(seatCheckbox).attr('disabled', '')
                }
                
                $(seatLabel).append(seatCheckbox)
                $(seatLabel).append(i + 1)
                
                if(i%2 === 0) $(tr1).append(seatLabel)
                else $(tr2).append(seatLabel)
            }
            
			let totalPrice = newEl('div')
			$(totalPrice).attr('id', 'total-price')
            $(selectedFlight).append(totalPrice)
			
			$(totalPrice).append('<span>Общая сумма: <span id=price>0</span>$</span>')
			
            let btnBook = newEl('button')
            $(btnBook).append('Бронировать')
            $(btnBook).bind('click', function(){
				if(selectedSeats.length != 0){
					for(let i = 0; i < currFlight.seats.length; i++){
						currFlight.seats[i] = ($(`input[name=seat][value=${i+1}]`)[0].checked === true) ? true : false
					}
					if(findSelectedFlightIndex === -1) allFlights.push(currFlight)
					else allFlights[findSelectedFlightIndex] = currFlight

					localStorage.setItem('flights', JSON.stringify(allFlights))

					$(tickedBooking).empty()
					
					$(tickedBooking).append(`Вы забронировали рейс
					${selectedDirection.val()} на число
					${selectedDate.val()} , места
					${selectedSeats.join(', ')} .`)
				}
        		else selectedFlight.append('Выберите места...')
            })
            $(totalPrice).append(btnBook)
        }
        else selectedFlight.append('Выберите дату...')
    }
}
function stringGeneratorPage(){
	PAGE.$task.empty()
	addTaskDesc('Реализовать генератор случайных строк.<br>Пользователь должен иметь возможность указать:<br>■ длину строки;<br>■ из каких символов строка может состоять:<br>• цифры;<br>• латинские буквы в верхнем регистре;<br>• латинские буквы в нижнем регистре.<br>При нажатии на кнопку Generate необходимо вывести сгенерированную по пользовательским критериям строку в текстовое поле')
	
	let stringGenerator = newEl('div');
	$(stringGenerator).attr('id', 'string-generator')
	PAGE.$task.append(stringGenerator)
    
    let title = newEl('h3')
    $(title).append('Генератор случайных строк')
    $(stringGenerator).append(title)
    
    const defaultLongString = 8
    let charsLongBlock = newEl('div');
    $(stringGenerator).append(charsLongBlock)
    let charsLongLabel = newEl('label');
    $(charsLongBlock).append(charsLongLabel)
    $(charsLongLabel).append('Введите длину строки: ')
    let charsLongInput = newEl('input')
    $(charsLongInput).attr('type', 'number')
    $(charsLongInput).attr('min', '1')
    $(charsLongInput).attr('max', '255')
    $(charsLongInput).attr('value', defaultLongString)
    $(charsLongInput).bind('input', function(){
        if(this.value > 255 || this.value < 1) this.value = defaultLongString
        else{
            let arr = this.value.match(/[0-9]/gi);
            this.value = (arr != null)?arr.join(''):'';
        }
    })
    $(charsLongLabel).append(charsLongInput)
    
    let charsSettingsBlock = newEl('div')
    $(charsSettingsBlock).append('Выберите набор символов:')
    let numsLabel = newEl('label');
    $(stringGenerator).append(charsSettingsBlock)
    
    let chars = [
        genChars(48, 57), //0. Цифры
        genChars(97, 122), //1. Маленькие буквы
        genChars(65, 90) //2. Большие буквы
    ]
    
    for(let i = 0; i < chars.length; i++){
        let charsSettingsCheckBoxParagraph = newEl('p');
        $(charsSettingsBlock).append(charsSettingsCheckBoxParagraph)
        let charsSettingsLabel = newEl('label')
        let charsSettingsCheckBox = newEl('input')
        $(charsSettingsCheckBox).attr('value', i)
        $(charsSettingsCheckBox).attr('type', 'checkbox')
        $(charsSettingsCheckBox).attr('checked', '')
        $(charsSettingsCheckBox).bind('change', function(){
            //Обеспечение хотя-бы одной галочки
            let charsCollections = $('input[type=checkbox]:checked')
            if(charsCollections.length === 0 && this.checked === false)
                this.checked = true
        })
        $(charsSettingsLabel).append(charsSettingsCheckBox)
        $(charsSettingsLabel).append(chars[i])
        $(charsSettingsCheckBoxParagraph).append(charsSettingsLabel)
    }
    
    let btn = newEl('button');
    $(btn).append('Создать')
    $(btn).bind('click', function(){
        let charsCollections = $('input[type=checkbox]:checked').map(function(){
            return $(this).val()
        }).get()
        let genString = ''
        let lengthString = parseInt($('input[type=number]')[0].value)
        for(let i = 0; i < lengthString; i++){
            let randCharsCollection = charsCollections[randNum(0, charsCollections.length)]
            let randCharOnCollection = randNum(0, chars[randCharsCollection].length - 1)
            genString += chars[randCharsCollection].split('')[randCharOnCollection]
        }
        $('input[name=string]')[0].value = genString
    })
    $(stringGenerator).append(btn)
    
    let charsGenBlock = newEl('div');
    $(charsGenBlock).append('Строка: ' + '<input size=50 name=string readonly>')
    $(stringGenerator).append(charsGenBlock)
    
	function genChars(from, to){
        if(from > to) genChars(to, from)
        else{
            if(from != to)
                return String.fromCharCode(from) + genChars(++from, to)
            else return String.fromCharCode(to)
        }
    }
}
