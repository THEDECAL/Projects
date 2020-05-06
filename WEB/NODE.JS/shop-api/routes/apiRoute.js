const express = require('express');
const ApiController = require('../controller/apiController')
const router = express.Router();

router.get('/:key/:mod/:act', ApiController.reqHandler)
router.get('/:key/:mod/:act/:id', ApiController.reqHandler)

router.post('/', ApiController.reqHandler)

module.exports = router;
