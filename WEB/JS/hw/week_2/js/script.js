const task = document.getElementById('task')
function newEl(elementName) { return document.createElement(elementName); }
function clearTask(){
    let task = document.getElementById("task");
    while (task.firstChild){
        task.removeChild(task.firstChild);
    }
}
function addTaskDesc(text){
    let taskDesc = newEl('p');
    taskDesc.style.marginBottom = '50px';
    taskDesc.innerHTML = text;
    
    return taskDesc;
}
function circleClassPage(){
    clearTask();
    
    task.appendChild(addTaskDesc('Реализовать класс, описывающий окружность.<br>В классе должны быть следующие компоненты:<br>■ поле, хранящее радиус окружности;<br>■ get-свойство, возвращающее радиус окружности;<br>■ set-свойство, устанавливающее радиус окружности;<br>■ get-свойство, возвращающее диаметр окружности;<br>■ метод, вычисляющий площадь окружности;<br>■ метод, вычисляющий длину окружности.<br>Продемонстрировать работу свойств и методов'));
    
    class Circle{
        constructor(radius){ this.radius = radius; }
        set Radius(radius) { this.radius = radius; }
        get Radius(){ return this.radius; }
        Diameter() { return (this.radius * 2); }
        Area(){ return (3.14 * (this.radius * this.radius)) }
        Circumference(){ return (2 * 3.14 * this.radius); }
    }
    
    let div = newEl('div');
    task.appendChild(div);
    
    let span = newEl('span');
    span.innerText = 'Введите радиус круга: ';
    div.appendChild(span);
    
    let input = newEl('input');
    input.style.display = 'inline';
    input.style.width = '50px';
    input.oninput = function(){
        let arr = this.value.match(/[0-9]/gm);
        this.value = (arr != null)?arr.join(''):'';
    }
    div.appendChild(input);
    
    let button = newEl('button');
    button.style.display = 'inline';
    button.innerText = 'Принять';
    button.onclick = function(){
        let radius = input.value;
        let circle = new Circle(radius);
        p.innerHTML = 'Площадь: ' + circle.Area();
        p.innerHTML += '<br>' + 'Диаметр: ' + circle.Diameter();
        p.innerHTML += '<br>' + 'Длина окружности: ' + circle.Circumference();
    }
    div.appendChild(button);
    
    let p = newEl('p');
    div.appendChild(p);
}
class HtmlElement{
    constructor(tagName, isTagClosing = true, nestedText = '', attributes, styles, childElements){
        this.tagName = tagName;
        this.isTagClosing = isTagClosing;
        this.nestedText = nestedText;
        this.attributes = [];
        this.styles = [];
        this.childElements = [];
    }
    AddAttribute(name, value){
        this.attributes.push({
                name: name,
                value: value
        });
    }
    AddStyle(name, value){
        this.styles.push({
                name: name,
                value: value
        });
    }
    AddHtmlElToEnd(htmlEl){ this.childElements.push(htmlEl); }
    AddHtmlElToStart(htmlEl){ this.childElements.splice(0, 0, htmlEl); }
    getHtml(){
        let closingTag = (this.isTagClosing) ? '</' + this.tagName + '>' : '';

        let attrs = '';
        for(let attr of this.attributes){
            attrs += ' ' + attr.name + '=' + "'" + attr.value + "'"
        }

        if(this.styles.length > 0){
            attrs += ' style=' + "'";
            let style = '';
            for(let stl of this.styles){
                style += stl.name + ': ' + stl.value + "; "
            }
            attrs += style += "'";
        }

        let childsEl = '';
        for(let child of this.childElements){
            childsEl += child.getHtml();
        }

        return '<' + this.tagName + attrs + '>' + this.nestedText + childsEl + closingTag; 
    }
}
class CssClass{
    constructor(className, styles){
        this.className = className;
        this.styles = [];
    }
    addStyle(name, value){
        this.styles.push({name: name, value: value});
    }
    delStyle(name){
        for(let i = 0; i < this.styles.length; i++){
            if(this.styles[i].name === name){
                this.styles.splice(i, 1)
            }
        }
    }
    getCss(){
        let stylelLine = '';
        for(let stl of this.styles){
            stylelLine += stl.name + ': ' + stl.value + ';';
        }

        return ' .' + this.className + '{' + stylelLine + '}';
    }
}
class HtmlBlock{
    constructor(){
        this.styles = [];
        this.root = new HtmlElement();
    }
    getCode(){
        let stylesLine = '';
        for(let stl of this.styles){
            stylesLine += stl.getCss();
        }
        return '<style>' + stylesLine + '</style>' + this.root.getHtml();
    }
}
function htmlElementPage(){
    clearTask();
    
    task.appendChild(addTaskDesc('Реализовать класс, описывающий html элемент.<br>Класс HtmlElement должен содержать внутри себя:<br>■ название тега;<br>■ самозакрывающийся тег или нет;<br>■ текстовое содержимое;<br>■ массив атрибутов;<br>■ массив стилей;<br>■ массив вложенных таких же тегов;<br>■ метод для установки атрибута;<br>■ метод для установки стиля;<br>■ метод для добавления вложенного элемента в конец текущего элемента;<br>■ метод для добавления вложенного элемента в начало текущего элемента;<br>■ метод getHtml(), который возвращает html код в виде<br>строки, включая html код вложенных элементов.<br>С помощью написанного класса реализовать следующий блок и добавить его на страницу с помощью document.write()'));
    
    let wrapper = new HtmlElement('div');
    wrapper.AddAttribute('id', 'wrapper');
    wrapper.AddStyle('display', 'flex');
    
    for(let i = 0; i < 2; i++){        
        let div = new HtmlElement('div');
        div.AddStyle('width', '300px');
        div.AddStyle('margin','10px');
        wrapper.AddHtmlElToEnd(div);

        let h3 = new HtmlElement('h3');
        h3.nestedText = 'What is Lorem Ipsum?';
        div.AddHtmlElToEnd(h3);

        let img = new HtmlElement('img', false);
        img.AddAttribute('src', 'lipsum.jpg');
        img.AddAttribute('alt', 'Lorem Ipsum');
        img.AddStyle('width', '100%');
        div.AddHtmlElToEnd(img);

        let p = new HtmlElement('p');
        p.nestedText = 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.';
        p.AddStyle('text-align', 'justify');
        div.AddHtmlElToEnd(p);

        let a = new HtmlElement('a');
        a.AddAttribute('href', 'https://www.ipsum.com/');
        a.AddAttribute('target', '_blank');
        a.nestedText = 'More...';
        p.AddHtmlElToEnd(a);
    }
    
    task.innerHTML += wrapper.getHtml();
    
    console.log(wrapper.getHtml());
}
function cssClassPage(){
    clearTask();
    
    task.appendChild(addTaskDesc('Реализовать класс, который описывает css класс.<br>Класс CssClass должен содержать внутри себя:<br>■ название css класса;<br>■ массив стилей;<br>■ метод для установки стиля;<br>■ метод для удаления стиля;<br>■ метод getCss(), который возвращает css код в виде строки.'));
    
    let cssClass = new CssClass('cssClass');
    cssClass.addStyle('display', 'none');
    cssClass.addStyle('color', 'gray');
    cssClass.addStyle('border', '1px solid lightgray');
    
    console.log('До удаления:');
    console.log(cssClass.getCss());
    cssClass.delStyle('display');
    console.log('После удаления:');
    console.log(cssClass.getCss());
    
    task.innerHTML += cssClass.getCss();
}
function htmlBlockPage(){
    clearTask();
    
    task.appendChild(addTaskDesc('Реализовать класс, описывающий блок html документ.<br>Класс HtmlBlock должен содержать внутри себя:<br>■ коллекцию стилей, описанных с помощью класса CssClass;<br>■ корневой элемент, описанный с помощью класса HtmlElement;<br>■ метод getCode(), который возвращает строку с html кодом (сначала теги style с описанием всех классов, а потом все html содержимое из корневого тега и его вложенных элементов).<br>С помощью написанных классов реализовать следующий блок (см. рис. 2) и добавить его на страницу с помощью document.write().'));
    
    let htmlBlock = new HtmlBlock();
    
    let styles = [];
    let wrap = new CssClass('wrap');
    wrap.addStyle('display', 'flex');
    styles.push(wrap);
    let block = new CssClass('block');
    block.addStyle('width', '300px');
    block.addStyle('margin', '10px');
    styles.push(block);
    let img = new CssClass('img');
    img.addStyle('width', '100%');
    styles.push(img);
    let text = new CssClass('text');
    text.addStyle('text-align', 'justify');
    styles.push(text);
    
    htmlBlock.styles = styles;
    
    let root = new HtmlElement('div');
    root.AddAttribute('id', 'wrapper');
    root.AddAttribute('class', 'wrap');
    
    for(let i = 0; i < 2; i++){        
        let div = new HtmlElement('div');
        div.AddAttribute('class', 'block');
        root.AddHtmlElToEnd(div);

        let h3 = new HtmlElement('h3');
        h3.nestedText = 'What is Lorem Ipsum?';
        div.AddHtmlElToEnd(h3);

        let img = new HtmlElement('img', false);
        img.AddAttribute('class', 'img');
        img.AddAttribute('src', 'lipsum.jpg');
        img.AddAttribute('alt', 'Lorem Ipsum');
        div.AddHtmlElToEnd(img);

        let p = new HtmlElement('p');
        p.AddAttribute('class', 'text');
        p.nestedText = 'Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.';
        div.AddHtmlElToEnd(p);

        let a = new HtmlElement('a');
        a.AddAttribute('href', 'https://www.ipsum.com/');
        a.AddAttribute('target', '_blank');
        a.nestedText = 'More...';
        p.AddHtmlElToEnd(a);
    }
    htmlBlock.root = root;
    
    task.innerHTML += htmlBlock.getCode();
    
    console.log(htmlBlock.getCode());
}