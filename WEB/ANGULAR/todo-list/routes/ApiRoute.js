const express = require('express')
const ApiController = require('../controllers/ApiController')
const router = express.Router()

router.get('/:act', ApiController.reqHandlerGet)
router.get('/:act/:id', ApiController.reqHandlerGet)

router.post('/', ApiController.reqHandlerPost)

module.exports = router
