const express = require('express')
const IndexController = require('../controller/indexController.js')
const router = express.Router()

router.get('/', IndexController.index)
router.get('/contacts', IndexController.contacts)
router.get('/details/:id', IndexController.details)

module.exports = router;
