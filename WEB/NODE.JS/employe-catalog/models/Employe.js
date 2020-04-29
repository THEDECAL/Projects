const uuid = require("uuid").v4

module.exports = class Employe{
    constructor(fname, sname, pname, email, age, post){
        this.id = uuid().toString()
        this.fname = fname
        this.sname = sname
        this.pname = pname
        this.email = email
        this.age = age
        this.post = post
    }
}