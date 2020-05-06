const PRM_KEY = 'key'
const PRM_MDL = 'mod'
const PRM_ACT = 'act'
const PRM_ID = 'id'
const createError = require('http-errors')
const CrudService = require('../services/crudService')
const { Model } = require('sequelize')

module.exports = class ApiController {
    static getCrud(req) {
        try {
            var prmModel = null;
            const bodyLength = Object.keys(req.body).length
            // console.log("bodyLength:" + bodyLength)

            if (bodyLength === 0) { prmModel = String(req.params[PRM_MDL]) }
            else { prmModel = String(req.body[PRM_MDL]) }

            if (prmModel) {
                return new CrudService(prmModel.toLowerCase())
            }
            throw console.log("Wrong params.")
        } catch (err) { console.error(err) }
        return null
    }

    static async keyCheck(req) {
        var key = null
        const bodyLength = Object.keys(req.body).length

        if (bodyLength === 0) { key = req.params[PRM_KEY] }
        else { key = req.body[PRM_KEY] }
        // console.log("key:"); console.log(key)

        if (key) {
            const Key = require("../models/key")

            var result = null;
            try {
                await Key.findOne(
                    {
                        where: { key: key },
                        raw: true
                    })
                    .then((res) => {
                        if (!res) return
                        result = res;
                    })

                if (result.id > 0) {
                    return true
                }
            } catch (err) { return false }

            return false
        }
    }

    static async reqHandler(req, resp, next) {
        try {
            const Crud = ApiController.getCrud(req)
            // console.log("Crud:"); console.log(Crud)

            if (Crud) {
                const isKeyValid = await ApiController.keyCheck(req)
                // console.log("isKeyValid:"); console.log(isKeyValid)

                if (isKeyValid) {
                    const bodyLength = Object.keys(req.body).length

                    if (bodyLength === 0) { //Для GET
                        // console.log("GET")
                        const prmAct = req.params[PRM_ACT]
                        const prmId = req.params[PRM_ID]
                        const data = await Crud.run(prmAct, prmId)
                        return resp.json(data)
                    }
                    else { //Для POST
                        // console.log("POST")
                        const prmAct = req.body[PRM_ACT]
                        const data = ApiController.getData(req)
                        await Crud.run(prmAct, data)
                        resp.locals.message = "The POST request success complete."

                        return resp.render("message")
                    }
                }
            }
        }
        catch (err) { console.log(err) }
        next(createError(400))
    }

    static getData(req) {
        const prmModel = String(req.body[PRM_MDL]).toLowerCase()

        switch (prmModel) {
            case "product":
                return {
                    id: req.body.id,
                    brand: req.body.brand,
                    model: req.body.model,
                    price: req.body.price,
                    urlImage: req.body.urlImage,
                    CategoryId: req.body.CategoryId
                }
            default:
                return null
        }
    }
}

// module.exports = new ApiController()