class Message{
    constructor(type, owner, data){
        this.type = type;
        this.owner = owner;
        this.data = data;
        var options = {
            month: 'short',
            day: 'numeric',
            hour: 'numeric',
            minute: 'numeric'
        };
        this.date = new Date().toLocaleString("ru", options);
        console.log(this.date);
    }
    static TYPES(){
        return {
            CONN: "conn",
            MSG: "msg",
            USER_ADD: "user_add"
        };
    }
}
