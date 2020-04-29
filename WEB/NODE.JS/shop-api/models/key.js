const { DataTypes } = require('sequelize')
const sqlz = require('../config/sequealize')
const CrudService = require('../services/crudService')

const Key = sqlz.define('Key', {
    id: {
        type: DataTypes.INTEGER,
        primaryKey: true,
        autoIncrement: true,
        allowNull: false
    },
    key: {
        type: DataTypes.STRING,
        allowNull: false
    }
},{
    timestamps: false
})

module.exports = {
    Key,
    Crud: new CrudService(Key)
}