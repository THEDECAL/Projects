package com.example.phonebook.models;
import java.io.Serializable;

import lombok.AllArgsConstructor;
import lombok.Data;
import lombok.NonNull;
import lombok.var;

@AllArgsConstructor
@Data
public class PhoneBookEntry implements Serializable, Cloneable {
    private int id = 0;
    private String sname = "";
    private String fname = "";
    private String phoneNumber = "";
    private String pathToPhoto = "";

    @Override
    public boolean equals(Object o){
        return ((PhoneBookEntry) o).id == id &&
            ((PhoneBookEntry) o).sname == sname &&
            ((PhoneBookEntry) o).fname == fname &&
            ((PhoneBookEntry) o).phoneNumber == phoneNumber &&
            ((PhoneBookEntry) o).pathToPhoto == pathToPhoto;
    }

    public void copy(PhoneBookEntry entry){
        id = entry.getId();
        sname = entry.getSname();
        fname = entry.getFname();
        phoneNumber = entry.getPhoneNumber();
        pathToPhoto = entry.getPathToPhoto();
    }
}
