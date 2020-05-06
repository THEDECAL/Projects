const express = require('express');
const ApiController = require('../controller/apiController')
const router = express.Router();

// http://127.0.0.1:7777/api/624d22d7002f9fdb131e5ad962abbb4a35a6377aa23f0c6010403d6ace0a9683/product/get_all
// http://127.0.0.1:7777/api/624d22d7002f9fdb131e5ad962abbb4a35a6377aa23f0c6010403d6ace0a9683/product/del/1

router.get('/:key/:mod/:act', ApiController.reqHandler)
router.get('/:key/:mod/:act/:id', ApiController.reqHandler)

router.post('/', ApiController.reqHandler)

module.exports = router;
