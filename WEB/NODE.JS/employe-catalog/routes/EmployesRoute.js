const express = require('express')
const router = express.Router()
const EmployesCntrl = require("../controllers/EmployesController")

router.get('/add', EmployesCntrl.add)
router.get('/edit/:id', EmployesCntrl.edit)
router.get('/remove/:id', EmployesCntrl.remove)
router.get('/', EmployesCntrl.index)

router.post('/add', EmployesCntrl.addPost)
router.post('/edit/:id', EmployesCntrl.editPost)

module.exports = router
