const SECRET_KEY = require('../config/secret')
const sequelize = require('../config/sequelize')
const Category = require('../models/category')
const Product = require('../models/product')
const Key = require('../models/key')
const Crypto = require('crypto')

class SequelizeService {
    async sync(isForce) {
        await sequelize
            .sync({ force: isForce })
            .catch(err => console.error(err))
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
                cat.setProduct()
            })
        await Category.create({ name: 'Notebook' })
        await Category.create({ name: 'Tablet' })

        //Продукты
        const prods = [
            await Product.create({
                brand: "Samsung",
                model: "A100",
                price: 54.99,
                urlImage: "",
                CategoryId: cats[0].id
            }),
            await Product.create({
                brand: "Hp",
                model: "8460p",
                price: 93.99,
                urlImage: "",
                CategoryId: cats[1].id
            }),
            await Product.create({
                brand: "Apple",
                model: "4G",
                price: 103.99,
                urlImage: "",
                CategoryId: cats[2].id
            })
        ]

        //prods[0].getDataValue().setCategory()
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