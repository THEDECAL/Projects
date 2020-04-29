const { DataTypes } = require('sequelize')
const sqlz = require('../config/sequealize')
const CrudService = require('../services/crudService')

const Category = sqlz.define('Category', {
    id: {
        type: DataTypes.INTEGER,
        primaryKey: true,
        autoIncrement: true,
        allowNull: false
    },
    name: {
        type: DataTypes.STRING,
        allowNull: false
    }
}, {
    timestamps: false
})


const Crud = new CrudService(Category)

module.exports = { Category, Crud }