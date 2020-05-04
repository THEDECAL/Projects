const { Model } = require('sequelize')
//const sqlz = require('../config/sequealize')
const MSG_NOT = " don`t"
const MSG_SUCCESS = " success"
const MSG_SUCCESS_ADD = `${MSG_SUCCESS} added.`
const MSG_SUCCESS_DEL = `${MSG_SUCCESS} delete.`
const MSG_SUCCESS_FND = `${MSG_SUCCESS} found.`
const MSG_SUCCESS_UPD = `${MSG_SUCCESS} update.`
const MSG_NOT_ADD = `${MSG_NOT} added.`
const MSG_NOT_DEL = `${MSG_NOT} delete.`
const MSG_NOT_FND = `${MSG_NOT} found.`
const MSG_NOT_UPD = `${MSG_NOT} update.`
const MSG_WRONG_TYPE = " has wrong type."
const MSG_NULL = " is a null."

module.exports = class CrudService {
    constructor(model) {
        if (model) {
            //message = model.prototype.constructor.name
            //console.log(model)

            if (model instanceof Model) {
                this.CurrentModel = model
                console.log("CrudService" += MSG_SUCCESS_ADD)
                return
            }
        }
        throw console.log("CrudService" + MSG_WRONG_TYPE)
    }
    /**
     * Получение объекта по ID
     * @param {*} id идентификатор объекта
     */
    async get(id) {
        var message = `${this.getModelName()} id=${id}`

        if (!this.getTypeName(id) === Number.name) {
            throw console.log(this.getTypeName(id) += MSG_WRONG_TYPE)
        }

        return await this.CurrentModel.findByPk(id).then((res) => {
            if (!res) throw message += MSG_NOT_FND
            console.log(message += MSG_SUCCESS_FND)
            console.debug(res)
        }).catch(err => console.error(err))
    }

    /**
     * Получение объекта по условию
     * @param {*} conditions условие поиска пример: {where: {name: "Example"}}
     */
    async filter(conditions) {
        var message = this.getModelName()

        if (!conditions) {
            throw console.log(message += MSG_NULL)
        }

        return await this.CurrentModel.findOne(filter, { raw: true }).then((res) => {
            if (!res) throw message += MSG_NOT_FND
            console.log(message += MSG_SUCCESS_FND)
            console.debug(res)
        }).catch(err => console.error(err))
    }

    /**
     * Возвращает название типа объекта
     * @param {*} obj объект любого класса
     */
    getTypeName(obj) { return obj.constructor.name }

    /**
     * Возвращает название типа текущей модели
     */
    getModelName() { return this.CurrentModel.name }

    /**
     * Возвращает имена всех методов в классе
     */
    getMethods() {
        const props = Object.getOwnPropertyNames(CrudService.prototype)
        // console.log("props:"); console.log(props)

        if (props) {
            return props.sort().filter((el, index, arr) => {
                console.log(el)
                if (el != arr[index + 1] && typeof el === 'function') {
                    //console.log(el)
                    //console.log(arr[index])

                    return true
                }
                else { return false }
            })
        }
        throw console.debug("Properties" + MSG_NULL)
    }

    /**
     * Получение всех объектов модели
     */
    async getAll() {
        var message = this.getModelName()

        await this.CurrentModel.findAll({
            raw: true
        }).then((res) => {
            if (!res) throw message += MSG_NOT_FND
            console.log(message += MSG_SUCCESS_FND)
            console.debug(res)

            return JSON.stringify(res)
        }).catch(err => console.error(err))
    }

    /**
     * Добавление объекта
     * @param {*} model объект унаследованный от Model
     */
    async add(model) {
        var message = model.prototype.constructor.name

        if (!model.build() instanceof this.CurrentModel) {
            throw console.log(message += MSG_NOT_ADD)
        }
        await this.CurrentModel.create(model).then((res) => {
            if (!res) throw message += MSG_NOT_ADD
            console.log(message += MSG_SUCCESS_ADD)
            console.debug(res)
        }).catch(err => console.error(err))
    }

    /**
     * Удаление объекта по id
     * @param {*} id идентификатор объекта
     */
    async del(id) {
        var message = `${this.getModelName()} id=${id} `

        if (!this.getTypeName(id) === Number.name) {
            throw console.log(id.prototype += MSG_WRONG_TYPE)
        }

        await this.CurrentModel.destroy({
            where: { id: id }
        }).then((res) => {
            if (!res) throw message += MSG_NOT_DEL
            console.log(message += MSG_SUCCESS_DEL)
            console.debug(res)

            return JSON.stringify(res)
        }).catch(err => console.debug(err))
    }

    /**
     * Изменение объекта
     * @param {*} model объект унаследованный от Model
     */
    async update(model) {
        var message = `${this.getModelName()} ${model.prototype} `

        if (!model.build() instanceof this.CurrentModel) {
            throw console.log(message += MSG_NOT_UPD)
        }
        await this.CurrentModel.update({ model }, {
            where: { id: model.id }
        }).then((res) => {
            if (!res) throw message += MSG_NOT_UPD
            console.log(message += MSG_SUCCESS_UPD)
            console.debug(res)
        }).catch(err => console.debug(err))
    }

    async run(methodName, args) {
        this[methodName](args)
    }
}