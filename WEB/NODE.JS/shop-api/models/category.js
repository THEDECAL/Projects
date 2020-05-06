const { DataTypes } = require('sequelize')
const sequelize = require('../config/sequelize')
const Product = require('../models/product')

const Category = sequelize.define('Category', {
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

Category.hasMany(Product)
//Product.belongsTo(Category)

module.exports = Category