const projectName = 'todo-list';
const express = require('express')
const path = require('path')
const ApiRoute = require('./routes/ApiRoute')
const Task = require('./models/Task') // Для инициализации таблицы Tasks
const SequelizeService = require('./services/SequelizeService')
const exp = express()

exp.use(express.json())
exp.use(express.urlencoded({ extended: true }))
exp.use(express.static(__dirname + `/dist/${projectName}`));

SequelizeService.checkConnect()

exp.use('/api', ApiRoute)

exp.use('/*', (req, res) => {
  res.sendFile(path.join(__dirname + `/dist/${projectName}/index.html`))
})

exp.listen(process.env.PORT || 8080)
