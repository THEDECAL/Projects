const { DataTypes } = require('sequelize')
const sqlz = require('../config/sequealize')
const { Category } = require('./category')
const CrudService = require('../services/crudService')

const Product = sqlz.define('Product', {
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

const Crud = new CrudService(Product)
console.log("Crud:"); console.log(Crud)
module.exports = { Product, Crud }