package PhoneBook.Models;

public class Abonent {
    private String fname;
    private String sname = "<Пусто>";
    private String phoneNumber;
    private String country = "<Пусто>";
    private Integer age = 0;

    public Abonent(String fname, String sname, String phoneNumber, String country, Integer age) {
        if(fname != null && sname != null && phoneNumber != null && country != null) {
            this.fname = fname;
            this.sname = sname;
            this.phoneNumber = phoneNumber;
            this.country = country;
            this.age = age;
        }
        else throw new NullPointerException();
    }

    public String getFname() {
        return fname;
    }

    public void setFname(String fname) {
        this.fname = fname;
    }

    public String getSname() {
        return sname;
    }

    public void setSname(String sname) {
        this.sname = sname;
    }

    public String getPhoneNumber() {
        return phoneNumber;
    }

    public void setPhoneNumber(String phoneNumber) {
        this.phoneNumber = phoneNumber;
    }

    public String getCountry() {
        return country;
    }

    public void setCountry(String country) {
        this.country = country;
    }

    public Integer getAge() {
        return age;
    }

    public void setAge(Integer age) {
        this.age = age;
    }

    public void copy(Abonent abon) {
        this.fname = abon.fname;
        this.sname = abon.sname;
        this.phoneNumber = abon.phoneNumber;
        this.country = abon.country;
        this.age = abon.age;
    }

    @Override
    public String toString() {
        var _age = (age == 0) ? "" : age;
        return fname + ' ' + sname + ' ' + phoneNumber + " (" + _age + ", " + country + ')';
    }
}