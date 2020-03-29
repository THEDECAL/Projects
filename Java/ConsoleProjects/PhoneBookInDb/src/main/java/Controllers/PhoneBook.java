package Controllers;
import Controllers.Data.AbonentCrud;
import Models.Abonent;
import Views.DataIO;
import lombok.Data;
import lombok.SneakyThrows;
import lombok.var;

import java.util.LinkedHashMap;
import java.util.function.Predicate;

public class PhoneBook {
    static private PhoneBook phoneBook;

    private AbonentCrud abonentCrud;
    private LinkedHashMap<String, Runnable> menu;

    @SneakyThrows
    private PhoneBook() {
        abonentCrud = new AbonentCrud();
        menu = new LinkedHashMap();

        initMenu();
        //initAbonents();
    }

    private void initAbonents() {
        abonentCrud.save(new Abonent("Никита", "Звегинцев","+380992993734" ,"Украина",  29));
        abonentCrud.save(new Abonent("Иван", "Чёрный","+380992223734" ,"Украина",  24));
        abonentCrud.save(new Abonent("Валера", "Солёный","+720992121734" ,"Россия",  32));
        abonentCrud.save(new Abonent("Степан", "Нудный","+720232121734" ,"Россия",  55));
    }

    private void initMenu() {
        menu.put("Показать", () -> { showAbons(); });
        menu.put("Добавить", () -> { addAbon(); });
        menu.put("Изменить", () -> { editAbon(); });
        menu.put("Удалить", () -> { delAbon(); });
        menu.put("Поиск по имени", () -> { findAbon(); });
        menu.put("Выход", () -> { System.exit(0); });
    }

    private Abonent inputAbonent() {
        var fname = DataIO.inputString("Введите имя* (>2): ", text -> text.trim() != "" && text.trim().length() > 2);
        var sname = DataIO.inputString("Введите фамилию: ", null);
        var phoneNumber = DataIO.inputString("Введите номер телефона* (>3): ", text -> text.trim() != "" && text.trim().length() > 3);
        var country = DataIO.inputString("Введите страну: ", null);
        var age = DataIO.inputNumber("Введите возраст: ", num -> num >= 0);

        return new Abonent(fname, sname, phoneNumber, country, age);
    }

    private void addAbon() {
        abonentCrud.save(inputAbonent());
    }

    private void delAbon() {
        var id = DataIO.inputNumber("Введите id абонента* (>0): ", num -> num > 0);
        var abon = abonentCrud.get(id);

        if(abon != null) abonentCrud.delete(id);
        else throw new IllegalArgumentException("Запись не найдена.");
    }

    private void findAbon() {
        var fname = DataIO.inputString("Введите имя* (>2): ", text -> text.trim() != "" && text.trim().length() > 2);
        var sname = DataIO.inputString("Введите фамилию: ", null);
        var abon = abonentCrud.findByName(fname, sname);

        if(abon != null) DataIO.Show(abon);
        else throw new IllegalArgumentException("Запись не найдена.");
    }

    private void editAbon() {
        var id = DataIO.inputNumber("Введите id абонента* (>0): ", num -> num > 0);
        var abon = abonentCrud.get(id);

        if(abon != null) {
            var editedAbon = inputAbonent();
            abon.Copy(editedAbon);

            abonentCrud.update(abon);
        }
        else throw new IllegalArgumentException("Запись не найдена.");
    }

    private void showAbons() {
        DataIO.Show(abonentCrud.getAll());
    }

    public void run() {
        DataIO.Show("\nТелефонная книга\n");

        while(true) {
            try {
                DataIO.indent();

                var counter = 1;
                for (String key : menu.keySet()) {
                    DataIO.Show(counter + ". " + key + '\n');
                    counter++;
                }

                Predicate<Integer> slctCondition = slctNum -> slctNum > 0 && slctNum <= menu.size();
                var slct = DataIO.inputNumber("Введите номер действия: ", slctCondition);

                var key = menu.keySet().toArray()[slct - 1];
                menu.get(key).run();
            } catch (Exception ex) { DataIO.Show(ex.getMessage()); }
        }
    }

    @SneakyThrows
    static public PhoneBook getInstance() {
        if(phoneBook == null)
            return phoneBook = new PhoneBook();
        return phoneBook;
    }
}
