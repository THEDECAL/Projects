class IndexController {
    index(req, resp) {

        resp.render('layout', {
            title: 'Employes Catalog',
            context: function () { return "index" },
            desc: "Easy site for employes catalog"
        })
    }
}

module.exports = new IndexController()