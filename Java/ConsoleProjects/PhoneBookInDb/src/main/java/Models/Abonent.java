package Models;
import lombok.AllArgsConstructor;
import lombok.Data;

/** Класс абонента в записной книжке */
@Data
@AllArgsConstructor
public class Abonent {
    private Integer id;
    /** Поле имени */
    private String fname;
    /** Поле фамилии */
    private String sname;
    private String phoneNumber;
    private  String country;
    private Integer age;

    public Abonent(String fname, String sname, String phoneNumber, String country, Integer age) {
        this.fname = fname;
        this.sname = sname;
        this.phoneNumber = phoneNumber;
        this.country = country;
        this.age = age;
    }

    public void Copy(Abonent obj) {
        this.fname = obj.fname;
        this.sname = obj.sname;
        this.phoneNumber = obj.phoneNumber;
        this.country = obj.country;
        this.age = age;
    }

    @Override
    public String toString() {
        return id + ". " + fname + " " + sname + ", " + age + "л. " + phoneNumber + " " + " (" + country + ")";
    }
}