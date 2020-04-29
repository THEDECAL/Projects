const config = require("./config/index")
const express = require("express")
const handlebars = require("hbs")
const exp = express()
var People = require("./models/People")
const listPeople = [
    new People("Zvegintsev", "Nikita", "Yriyovich", 29, "www@www.www", "https://bootdey.com/img/Content/user_3.jpg"),
    new People("Petrov", "Max", "Destiny", 22, "www@www.www", "https://bootdey.com/img/Content/user_1.jpg"),
    new People("Zorina", "Iren", "Roland", 35, "www@www.www", "https://bootdey.com/img/Content/user_2.jpg")
]

exp.use(express.urlencoded({ extended: true }))
//Регестрация шаблонизатора
exp.set('view engine', 'hbs')
handlebars.registerPartials(`${__dirname}/views/partials`)

//Подключение статических ресурсов
exp.use(express.static(`${__dirname}/public`))
exp.use(express.static(`${__dirname}/node_modules`))

//Настройка заголовка ответа
exp.use((req, resp, next) => {
    resp.setHeader("Content-Type", "text/html;charset=utf8")
    next()
})

exp.get([ "/", "/index" ], (req, resp) => {
    resp.render("index", {
        title: "People List",
        context: () => { return "people"},
        list: listPeople
    })
})

exp.get("/details/:id", (req, resp) => {
    const peopleId = req.params["id"]
    const item = listPeople.find((el, index, arr) => {
        return el.id === peopleId
    })

    resp.render("index", {
        title: "Details",
        context: () => { return "details" },
        item: item
    })
})


//Обработка некорректных URL
exp.use((req, resp, next) => {
    resp.statusCode = 404
    resp.render("index", {
        title: "Ошибка",
        context: () => { return "error" },
        message: "Простите, но такой страницы нет..."})
})

exp.listen(config.port, config.host, console.log("Server has started..."))
