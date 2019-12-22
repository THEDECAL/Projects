package PhoneBook;
import PhoneBook.Models.*;
import java.util.LinkedHashMap;
import java.util.Scanner;
import java.util.function.Predicate;

public class Main {
    private static final PhoneBook phoneBook = new PhoneBook();
    private static final LinkedHashMap<String, Runnable> menu = new LinkedHashMap();

    public static void main(String[] args) {
        initAbonents();
        initMenu();

        while (true) {
            try {
                System.out.print("Телефонная книга\n");
                indent();

                var counter = 1;
                for (String key : menu.keySet()) {
                    System.out.print(counter + ". " + key + '\n');
                    counter++;
                }

                var slct = inputNumber("Введите номер действия: ", null);

                var key = menu.keySet().toArray()[slct - 1];
                menu.get(key).run();
            }
            catch(IllegalArgumentException ex){ System.out.print(ex.getMessage() + '\n'); }
            catch(Exception ex){  }
        }
    }

    private static void initAbonents() {
        phoneBook.addAbonent(new Abonent("Никита", "Звегинцев","+380992993734" ,"Украина",  29));
        phoneBook.addAbonent(new Abonent("Иван", "Чёрный","+380992223734" ,"Украина",  24));
        phoneBook.addAbonent(new Abonent("Валера", "Солёный","+720992121734" ,"Россия",  32));
        phoneBook.addAbonent(new Abonent("Степан", "Нудный","+720232121734" ,"Россия",  55));
    }

    private static void initMenu(){
        menu.put("Показать", Main::showAbons);
        menu.put("Показать (группировка по стране)", Main::groupByCountry);
        menu.put("Показать (группировка по возрасту)", Main::groupByAge);
        menu.put("Добавить", Main::addAbon);
        menu.put("Изменить", Main::editAbon);
        menu.put("Удалить", Main::delAbon);
        menu.put("Поиск по номеру телефона", Main::findAbon);
        menu.put("Выход", Main::exit);
    }

    private static Integer inputNumber(String text, Predicate<Integer> condition) {
        if(condition == null) condition = x -> true;
        while(true) {
            try {
                var in = new Scanner(System.in);
                System.out.print(text);

                var inputText = in.nextLine().trim();
                var num = (inputText == "") ? 0 : Integer.parseInt(inputText);
                System.out.print("--------------------\n");

                if(!condition.test(num))
                    throw new Exception("Введенно неподходящее число.\n");

                return num;
            } catch (NumberFormatException ex) {}
            catch (Exception ex) { System.out.print(ex.getMessage()); }
        }
    }

    private static String inputString(String text, Predicate<String> condition) {
        if(condition == null) condition = x -> true;
        while(true) {
            try {
                var in = new Scanner(System.in);
                System.out.print(text);

                var inputText = in.nextLine();
                System.out.print("--------------------\n");

                if(!condition.test(inputText))
                    throw new Exception("Неверный формат.\n");

                return inputText;
            } catch (Exception ex) { System.out.print(ex.getMessage()); }
        }
    }

    private static void showAbons() {
        indent();
        System.out.print(phoneBook);
    }

    private static void addAbon() {
        phoneBook.addAbonent(inputAbon());
    }

    private static Abonent inputAbon() {
        var fname = inputString("Введите имя* (>2): ", text -> text.trim() != "" && text.trim().length() > 2);
        var sname = inputString("Введите фамилию: ", null);
        var phoneNumber = inputString("Введите номер телефона* (>3): ", text -> text.trim() != "" && text.trim().length() > 3);
        var country = inputString("Введите страну: ", null);
        var age = inputNumber("Введите возраст: ", num -> num >= 0);

        return new Abonent(fname, sname, phoneNumber, country, age);
    }

    private static void editAbon() {
        var fname = inputString("Введите имя* (>2): ", text -> text.trim() != "" && text.trim().length() > 2);
        var sname = inputString("Введите фамилию: ", null);

        var abon = phoneBook.findAbon(a -> a.getFname().equals(fname) && a.getSname().equals(sname));

        if(abon != null) abon.copy(inputAbon());
        else throw new IllegalArgumentException("Запись не найдена.");
    }

    private static void delAbon() {
        var fname = inputString("Введите имя* (>2): ", text -> text.trim() != "" && text.trim().length() > 2);
        var sname = inputString("Введите фамилию: ", null);

        var abon = phoneBook.findAbon(a -> a.getFname().equals(fname) && a.getSname().equals(sname));

        if(abon != null) phoneBook.delAbonent(abon);
        else throw new IllegalArgumentException("Запись не найдена.");
    }

    private static void findAbon() {
        var phoneNumber = inputString("Введите номер телефона* (>3): ", text -> text.trim() != "" && text.trim().length() > 3);
        var abon = phoneBook.findAbon(a -> a.getPhoneNumber().contains(phoneNumber));

        if(abon != null) System.out.print(abon.toString() + '\n');
        else throw new IllegalArgumentException("Запись не найдена.");
    }

    private static void groupByCountry() {
        System.out.print(phoneBook.getAbonsByGroup(Abonent::getCountry));
    }

    private static void groupByAge() {
        System.out.print(phoneBook.getAbonsByGroup(Abonent::getAge));
    }

    private static void indent() {
        System.out.print("--------------------\n");
    }

    private static void exit() {
        System.exit(0);
    }
}