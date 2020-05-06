const { Model, Sequelize } = require('sequelize')
const Category = require('../models/category')
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
    constructor(modelName) {
        const model = require(`../models/${modelName}`)
        if (model) {
            //message = model.prototype.constructor.name
            // console.log("model:"); console.log(model)

            if (model.build() instanceof Model) {
                this.CurrentModel = model
                console.log("CrudService" + MSG_SUCCESS_ADD)
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
        var result = null
        var incAttrs = await this.getIncludeAttributes()

        if (!this.getTypeName(id) === Number.name) {
            throw console.log(this.getTypeName(id) += MSG_WRONG_TYPE)
        }

        await this.CurrentModel.findOne({
            where: { id: id },
            raw: true,
            include: incAttrs
        }).then((res) => {
            if (!res) throw message += MSG_NOT_FND
            console.log(message += MSG_SUCCESS_FND)
            // console.debug(res)
            const Pr = require("../models/product")
            Pr.getTableName()
            result = res
        }).catch(err => console.error(err))

        return result
    }

    /**
     * Получение атрибутов для моделей
     */
    async getIncludeAttributes() {
        const model = this.CurrentModel.name

        switch (model) {
            case "Product":
                // return "Category"
                return {
                    model: require("../models/category"),
                    attributes: ['name']
                }
            default:
                return null;
        }
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
    async get_all() {
        var message = this.getModelName()
        var result = null;
        var incAttr = await this.getIncludeAttributes()

        await this.CurrentModel.findAll({
            raw: true,
            include: incAttr
        }).then((res) => {
            if (!res) throw message += MSG_NOT_FND
            console.log(message += MSG_SUCCESS_FND)
            // console.debug(res)

            result = res
        }).catch(err => console.error(err))
        return result
    }

    /**
     * Добавление объекта
     * @param {*} model объект унаследованный от Model
     */
    async add(model) {
        var message = this.CurrentModel.name
        await this.CurrentModel.create(model).then((res) => {
            if (!res) throw message += MSG_NOT_ADD
            console.log(message += MSG_SUCCESS_ADD)
            // console.debug(res)
        })
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
            // console.debug(res)
        }).catch(err => console.debug(err))
    }

    /**
     * Изменение объекта
     * @param {*} model объект унаследованный от Model
     */
    async update(model) {
        var message = this.CurrentModel.name
        // console.log("model keys: " + Object.keys(model))

        if (!model.id) {
            throw message + " field 'id'" + MSG_NULL
        }

        await this.CurrentModel.update(model, {
            where: { id: model.id }
        }).then((res) => {
            if (!res) throw message += MSG_NOT_UPD
            console.log(message += MSG_SUCCESS_UPD)
            // console.debug(res)
        })
    }
    /**
     * Запуск метода по имени
     * @param {*} methodName Название метода
     * @param {*} args Аргументы
     */
    async run(methodName, args) {
        // console.log("methodName:"); console.log(methodName)
        const data = await this[methodName](args)
        // console.log("data:"); console.log(data)
        return data
    }
}