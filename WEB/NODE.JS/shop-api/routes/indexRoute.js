const express = require('express')
const IndexCntrl = require('../controller/indexController.js')
const router = express.Router()

router.get('/', IndexCntrl.index);

module.exports = router;
