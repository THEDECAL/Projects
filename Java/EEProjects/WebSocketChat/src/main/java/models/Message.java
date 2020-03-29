package models;
import java.util.Date;

public class Message {
    public enum Type
    {
        CONN("conn"),
        USER_ADD("user_add"),
        MSG("msg");

        String value;
        Type(String value){ this.value = value; }
        public String getValue(){ return value; }
    }

    private String type;
    private String owner;
    private String data;
    private String date;

    public Message(Type type, String owner, String data, String date){
        this.type = type.getValue();
        this.owner = owner;
        this.data = data;
        this.date = date;
    }
    public String getType() { return type; }
    public String getData() {
        return data;
    }
    public String getDate() {
        return date;
    }
}
