const createError = require('http-errors')
const express = require('express')
const path = require('path')
const cookieParser = require('cookie-parser')
const logger = require('morgan')
const { host, port } = require('./config/index')
const sequelizeService = require('./services/sequelizeService')
const exp = express()

const indexRoute = require('./routes/indexRoute')
const apiRoute = require('./routes/apiRoute')

exp.set('views', path.join(__dirname, 'views'))
exp.set('view engine', 'hbs')

exp.use(express.json())
exp.use(express.urlencoded({ extended: true }))
exp.use(express.static(path.join(__dirname, 'public')))

exp.use('/api', apiRoute)
exp.use(['/index', '/'], indexRoute)

exp.use(function (req, res, next) {
  next(createError(404));
});

exp.use(function (err, req, res, next) {
  res.locals.message = err.message
  res.locals.error = req.app.get('env') === 'development' ? err : {}

  res.status(err.status || 500)
  res.render('error')
})

sequelizeService.sync(false)/*.then(() => { sequelizeService.init() })*/

exp.listen(port, host, console.log("Server has started..."))
