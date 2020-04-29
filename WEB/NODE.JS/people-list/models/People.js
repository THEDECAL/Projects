const uuid = require("uuid").v4

module.exports = class People{
    constructor (sname, fname, pname, age, email, urlImage){
        this.id = uuid().toString()
        this.sname = sname
        this.fname = fname
        this.pname = pname
        this.age = age
        this.email = email
        this.urlImage = urlImage
        this.createDate = new Date()
    }
}