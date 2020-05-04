const { DataTypes } = require('sequelize')
const sequelize = require('../config/sequelize')

module.exports = sequelize.define('Key', {
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
}, { timestamps: false })