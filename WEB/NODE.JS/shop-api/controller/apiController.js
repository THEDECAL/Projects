const PRM_KEY = 'key'
const PRM_MDL = 'model'
const PRM_ACT = 'act'
const PRM_ID = 'id'
const createError = require('http-errors')
const CrudService = require('../services/crudService')
const { Model } = require('sequelize')

class ApiController {
    getCrud(req) {
        try {
            const prmModel = String(req.params[PRM_MDL]).toLowerCase().trim()
            // const prmAct = String(req.params[PRM_ACT]).toLowerCase().trim()
            // const prmId = String(req.params[PRM_ID]).toLowerCase().trim()
            const Model = require(`../models/${prmModel}`)
            // console.log("Model:"); console.log(Model)

            if (Model) {
                //const obj = new Model()
                // console.log("obj:"); console.log(obj)
                this.Crud = new CrudService(Model)

                return true
            }
            throw console.log("Wrong params.")
        } catch (err) { console.error(err) }
        return false
    }

    async keyCheck(req) {
        const key = String(req.params[PRM_KEY]).toLowerCase().trim()
        //console.log(key)

        if (key) {
            // console.log("this.Crud:"); console.log(this.Crud)
            // console.log("Object.keys(this.Crud):"); console.log(Object.keys(this.Crud))
            //console.log("this.Crud.getMethods():"); console.log(this.Crud.getMethods())
            // console.log("Object.getOwnPropertyNames(this.Crud.CurrentModel):")
            // console.log(Object.getOwnPropertyNames(this.Crud.CurrentModel))
            const Key = require("../models/key")

            var result = null;
            await Key.findOne(
                { where: { key: key }, raw: true }).then((res) => {
                    result = res;
                })/*.catch(err => console.error(err))*/
            console.log("result:"); console.log(result)

            // const result = await this.Crud.filter({
            //     where: { key: key }
            // }).catch(err => console.error(err))
            // console.log("result:"); console.log(result)

            if (result.id > 0) {
                return true
            }
        }

        return false
    }

    reqHandler(req, resp, next) {
        const api = new ApiController()
        const isGetCrud = api.getCrud(req)
        console.log("isGetCrud:"); console.log(isGetCrud)

        if (isGetCrud) {
            const isKeyValid = api.keyCheck(req)
            console.log("isKeyValid:"); console.log(isKeyValid)

            if (isKeyValid) { resp.json("Yes!") }
        }
        next(createError(401))
    }
}

module.exports = new ApiController()