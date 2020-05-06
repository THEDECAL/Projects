const PRM_ID = 'id'
const CrudService = require("../services/crudService")
const Product = require("../models/product")
const CreateError = require("http-errors")

const CrudProduct = new CrudService(Product.name.toLowerCase())
class IndexController {
    async index(req, resp) {
        const products = await CrudProduct.get_all()
        // console.log("products: " + products)

        resp.render('index', {
            title: 'Shop',
            products
        })
    }

    async details(req, resp, next) {
        const prmId = req.params[PRM_ID]
        const product = await CrudProduct.get(prmId)

        if (product.id > 0) {
            resp.render('details', {
                title: 'Details',
                title_bar: product.brand + ' ' + product.model,
                product
            })
        }
    }

    contacts(req, resp) {
        resp.render('contacts', {
            title: 'Contacts'
        })
    }
}

module.exports = new IndexController()