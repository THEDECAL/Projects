const { DataTypes } = require('sequelize')
const sequelize = require('../config/sequelize')
const Category = require('../models/category')

const Product = sequelize.define('Product', {
    id: {
        type: DataTypes.INTEGER,
        primaryKey: true,
        autoIncrement: true,
        allowNull: false
    },
    brand: {
        type: DataTypes.STRING,
        allowNull: false
    },
    model: {
        type: DataTypes.STRING,
        allowNull: false
    },
    price: {
        type: DataTypes.DOUBLE,
        allowNull: false
    }
}, { timestamps: false })

Category.hasOne(Product)
Product.belongsTo(Category, { foreignKey: 'CategoryId' })

module.exports = Product