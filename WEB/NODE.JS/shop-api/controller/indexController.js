class IndexController {
    index(req, resp){
        resp.render('index',
            {
                title: 'Shop'
            })
    }
}

module.exports = new IndexController()