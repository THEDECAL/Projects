const createError = require('http-errors')
const hbs = require("hbs")
const express = require('express')
const path = require('path')
const { host, port } = require("./config/index")
const exp = express()

const indexRoute = require('./routes/IndexRoute')
const employesRoute = require('./routes/EmployesRoute')

hbs.registerHelper("inc", function (value, options) {
    return parseInt(value) + 1
})
//Не находит inverse вынужден обходными путями действовать
// hbs.registerHelper("ifStrEq", function (str1, str2, options) {
//     return (str1 == str2) ? options.fn(this) : options.inverse(this)
// })

exp.set('view engine', 'hbs')
hbs.registerPartials(__dirname + '/views/partials')

exp.use(express.json())
exp.use(express.urlencoded({ extended: false }))

exp.use(express.static(path.join(__dirname, 'public')))
exp.use(express.static(path.join(__dirname, 'node_modules')))

exp.use('/', indexRoute)
exp.use('/index', indexRoute)
exp.use('/employes', employesRoute)


exp.use(function(req, res, next) {
  next(createError(404))
})


exp.use(function(err, req, res, next) {
    res.locals.message = err.message
    res.locals.error = req.app.get('env') === 'development' ? err : {}

    res.status(err.status || 500)
    res.render('layout', {
        title: "ERROR",
        context: function(){ return "error" }
    })
})

exp.listen(port, host)
