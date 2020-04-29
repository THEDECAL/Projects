const express = require('express')
const router = express.Router()
const IndexCntrl = require("../controllers/IndexController")

router.get('/', IndexCntrl.index);

module.exports = router;
