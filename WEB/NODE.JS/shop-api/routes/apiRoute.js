const express = require('express');
const ApiController = require('../controller/apiController')
const router = express.Router();

router.get('/:key/:model/:act', ApiController.reqHandler)
router.get('/:key/:model/:act/:id', ApiController.reqHandler)

router.post('/:key/:model/:act', ApiController.reqHandler)

module.exports = router;
