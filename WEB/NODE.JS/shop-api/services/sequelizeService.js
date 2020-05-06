const SECRET_KEY = require('../config/secret')
const sequelize = require('../config/sequelize')
const Category = require('../models/category')
const Product = require('../models/product')
const Key = require('../models/key')
const Crypto = require('crypto')

class SequelizeService {
    async sync(isForce, isInit) {
        await sequelize.sync({ force: isForce })
        if (isInit) { await this.init() }
    }

    async checkConnect() {
        try {
            await sequelize.authenticate()
            console.log('Connection has been established successfully.')
            await sequelize.close()

            return true;
        } catch (error) {
            console.error('Unable to connect to the database:', error)

            return false;
        }
    }

    /**
     * Инициализация БД
     */
    async init() {
        await this.initKeys()

        await Category.create({ name: 'Smartphone' })
            .then((cat) => {
                Product.create({
                    brand: "Samsung",
                    model: "A100",
                    price: 54.99,
                    urlImage: "/images/iphone.png",
                    CategoryId: cat.id
                })
                Product.create({
                    brand: "Lenovo",
                    model: "C300",
                    price: 58.39,
                    urlImage: "/images/iphone.png",
                    CategoryId: cat.id
                })
            })
        await Category.create({ name: 'Notebook' })
            .then((cat) => {
                Product.create({
                    brand: "Sony",
                    model: "PoweBook p9089",
                    price: 64.29,
                    urlImage: "/images/laptop.png",
                    CategoryId: cat.id
                })
                Product.create({
                    brand: "Hp",
                    model: "EliteBook 8460p",
                    price: 62.39,
                    urlImage: "/images/laptop.png",
                    CategoryId: cat.id
                })
            })
        await Category.create({ name: 'Web Camera' })
            .then((cat) => {
                Product.create({
                    brand: "SeliconPower",
                    model: "Bp900",
                    price: 14.99,
                    urlImage: "/images/camera.png",
                    CategoryId: cat.id
                })
                Product.create({
                    brand: "Genius",
                    model: "Y5490",
                    price: 38.39,
                    urlImage: "/images/camera.png",
                    CategoryId: cat.id
                })
            })
    }

    /**
     * Инициализация ключей доступа
     */
    async initKeys() {
        const hmac = Crypto.createHmac('sha256', SECRET_KEY);
        var hash = null

        hmac.on('readable', () => {
            hash = hmac.read()
        });

        hmac.end();

        if (hash) {
            await Key.create({
                key: hash.toString('hex')
            }, { raw: true }).then(res => {
                //console.log(res)
            }).catch(err => console.log(err))
        }
    }
}

module.exports = new SequelizeService()