const express = require('express');
const ApiCntrl = require('../controller/apiController')
const router = express.Router();

router.get('/:key/:obj/:act', ApiCntrl.reqHandler)
router.get('/:key/:obj/:act/:id', ApiCntrl.reqHandler)

router.post('/:key/:obj/:act', ApiCntrl.reqHandler)

module.exports = router;
