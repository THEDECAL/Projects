const Employe = require("../models/Employe")
const EmplService = require("../services/EmployesService")
const { host, port } = require("../config/index")
const urlEmployes = "http://" + host + ":" + port + "/employes"

class EmployesController {
    index(req, resp) {
        const empls = EmplService.getAll()

        resp.render('layout', {
            title: 'Employes List',
            context: function () { return "employes" },
            list: empls
        })
    }

    remove(req, resp){
        EmplService.remove(req.params.id)
        resp.redirect(urlEmployes)
    }

    add(req, resp){
        resp.render('layout', {
            title: 'Create Employe',
            context: function () { return "employe_manager" },
            posts: EmplService.getPosts(),
            slctd: "",
            button_name: "Add employe"
        })
    }

    edit(req, resp) {
        if (req.params.id !== undefined) {
            const empls = EmplService.getAll()
            const empl = empls.filter((e) => {
                return (req.params.id === e.id)?true:false
            })
            const posts = EmplService.getPosts().filter((p) => {
                return (p != empl[0].post) ? true : false
            })

            resp.render('layout', {
                title: 'Edit Employe',
                context: function () {
                    return "employe_manager"
                },
                emp: empl[0],
                posts: posts,
                slctd: empl[0].post,
                button_name: "Edit employe"
            })
        }
        else{
            resp.status(404)
            resp.render('layout', {
                title: 'ERROR',
                context: function () {
                    return "error"
                }
            })
        }
    }

    addPost(req, resp){
        const emp = new Employe(
            req.body.fname,
            req.body.sname,
            req.body.pname,
            req.body.email,
            req.body.age,
            req.body.post)

        EmplService.add(emp)
        resp.redirect(urlEmployes)
    }

    editPost(req, resp){
        const emp = new Employe(
            req.body.fname,
            req.body.sname,
            req.body.pname,
            req.body.email,
            req.body.age,
            req.body.post)
        emp.id = req.body.id

        EmplService.edit(emp)
        resp.redirect(urlEmployes)
    }
}

module.exports = new EmployesController()