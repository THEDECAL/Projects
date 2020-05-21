const { DataTypes, Sequelize } = require('sequelize')
const dbConfig = require('../configs/DataBase')
const sequelize = new Sequelize(dbConfig.uri, dbConfig.options)

const Task = sequelize.define('Task', {
  id: {
    type: DataTypes.INTEGER,
    primaryKey: true,
    autoIncrement: true,
    allowNull: false
  },
  title: {
    type: DataTypes.STRING,
    allowNull: false
  },
  description: {
    type: DataTypes.STRING,
    allowNull: true
  },
  prio: {
    type: DataTypes.INTEGER,
    allowNull: false
  },
  startDate: {
    type: DataTypes.DATE,
    allowNull: false
  },
  endDate: {
    type: DataTypes.DATE,
    allowNull: false
  },
  owner: {
    type: DataTypes.STRING,
    allowNull: false
  }
}, { timestamps: false })

// Task.sync({force: false}).then(() => {
//   return Task.create({
//         title: 'First Task',
//         description: 'Description First Task',
//         prio: 3,
//         startDate: 1589385223,
//         endDate: 1589385223,
//         owner: 'THE DECAL!'
//       })
// })

module.exports = Task
