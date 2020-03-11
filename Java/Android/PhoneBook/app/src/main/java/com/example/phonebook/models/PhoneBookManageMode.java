package com.example.phonebook.models;

public enum PhoneBookManageMode {
    ADD(0), EDIT(1);
    private int value;

    PhoneBookManageMode(int value){ this.value = value; }
    public int getValue(){ return value; }
    static public PhoneBookManageMode getMode(int value){
        for (PhoneBookManageMode m: PhoneBookManageMode.values()) {
            if(m.getValue() == value)
                return m;
        }
        return null;
    }
};
