
const PRM_ID = 'id'
const PRM_ACT = 'act'
const PRM_TITLE = 'title'
const PRM_DESC = 'description'
const PRM_PRIO = 'prio'
const PRM_START_DATE = 'startDate'
const PRM_END_DATE = 'endDate'
const PRM_OWNER = 'owner'
const Task = require('../models/Task')

class ApiController {
  async reqHandlerGet(req, resp) {
    // console.log("reqHandlerGet")
    try {
      const action = req.params[PRM_ACT]
      // console.log("action: " + action)
      const id = req.params[PRM_ID]
      // console.log("id: " + id)
      const result = await ApiController[action](id)
      // console.log("result: " + result)

      resp.status(200)
      resp.json(result)
    }
    catch (err) {
      console.log(err)
      resp.status(400)
      resp.send("Wrong Request")
    }
  }

  async reqHandlerPost(req, resp) {
    console.log("reqHandlerPost")
    try {
      const action = req.body[PRM_ACT]
      const id = req.body[PRM_ID]
      const title = req.body[PRM_TITLE]
      const description = req.body[PRM_DESC]
      const startDate = Number(req.body[PRM_START_DATE])
      const endDate = Number(req.body[PRM_END_DATE])
      const owner = req.body[PRM_OWNER]
      const prio = req.body[PRM_PRIO]
      // console.log(id, title, description, startDate, endDate, owner, prio)

      var result = await ApiController[action]({
        id, title, description, prio,
        startDate, endDate, owner
      })

      resp.status(200)
      resp.json(result)
    }
    catch (err) {
      console.log(err)
      resp.status(400)
      resp.send("Wrong Request")
    }
  }

  static async get(id) {
    // console.log("get(" + id + ")")
    var result = null

    await Task.findOne({
      where: { id: id },
      raw: true
    }).then((res) => {
      if (!res) return
      result = res
    })

    return result
  }

  static async get_all() {
    var result = null

    await Task.findAll({ raw: true }).then((res) => {
      if (!res) return
      result = res
    })

    return result
  }

  static async del(id) {
    var isSuccess = false

    await Task.destroy({
      where: { id }
    }).then((res) => {
      console.log(res)
      if (res) {
        isSuccess = true
        console.log(isSuccess)
      }
    })

    return isSuccess
  }

  static async update(task) {
    var isSuccess = false

    await Task.update(task, {
      where: {id: task.id}
    }).then((res) => {
      if (res) isSuccess = true
    })

    return isSuccess
  }

  static async add(task) {
    var isSuccess = false

    await Task.create(task).then((res) => {
      if (res) isSuccess = true
    })

    return isSuccess
  }
}

module.exports = new ApiController()
