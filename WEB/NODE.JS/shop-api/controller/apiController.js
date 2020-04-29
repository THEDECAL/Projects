const PRM_KEY = 'key'
const PRM_OBJ = 'obj'
const PRM_ACT = 'act'
const PRM_ID = 'id'
const createError = require('http-errors')
const CrudService = require('../services/crudService')

class ApiController {
    extractParams(req) {
        try {
            const prmObj = String(req.params[PRM_OBJ]).toLowerCase().trim()
            const prmAct = String(req.params[PRM_ACT]).toLowerCase().trim()
            const prmId = String(req.params[PRM_ID]).toLowerCase().trim()
            const models = Array(CrudService.getModels())
            console.log(prmObj)
            console.log(prmAct)
            console.log(prmId)
            console.log(models)

            if (models[prmObj]) {
                this.crud = models[prmObj].Crud
                const actions = Array(this.crud.getMethods())

                if (actions[prmAct]) {
                    this.crud.run(prmAct, prmId)
                    console.log("Method has success ran.")
                    return
                }
            }
            throw console.log("Wrong params.")
        } catch (err) { console.error(err) }
    }

    async keyCheck(req) {
        const key = String(req.params[PRM_KEY]).toLowerCase().trim()

        if (!key) {
            const result = await this.crud.filter({
                where: { key: key }
            }).catch(err => console.error(err))

            if (result.id > 0) {
                return true
            }
        }

        return false
    }

    reqHandler(req, resp, next) {
        const apic = new ApiController()
        apic.keyCheck(req)
        apic.extractParams(req)

        // console.log(req.params)
        // const isKeyValid = this.keyCheck(req)
        // const isParamsValid = this.extractParams(req)

        // if (isKeyValid && isParamsValid) {

        // }

        next(createError(401))
    }
}

module.exports = new ApiController()