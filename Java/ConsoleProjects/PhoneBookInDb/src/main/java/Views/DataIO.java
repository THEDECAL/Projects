package Views;

import lombok.var;

import java.util.List;
import java.util.Scanner;
import java.util.function.Predicate;

/** Класс для ввода и вывода данных */
public class DataIO {
    static public Integer inputNumber(String text, Predicate<Integer> condition) {
        if(condition == null) condition = x -> true;
        while(true) {
            try {
                var in = new Scanner(System.in);
                System.out.print(text);

                var inputText = in.nextLine().trim();
                var num = (inputText == "") ? 0 : Integer.parseInt(inputText);
                System.out.print("\n--------------------\n");

                if(!condition.test(num))
                    throw new Exception("Введенно неподходящее число.\n");

                return num;
            } catch (NumberFormatException ex) {}
            catch (Exception ex) { System.out.print(ex.getMessage()); }
        }
    }

    static public String inputString(String text, Predicate<String> condition) {
        if(condition == null) condition = x -> true;
        while(true) {
            try {
                var in = new Scanner(System.in);
                System.out.print(text);

                var inputText = in.nextLine();
                System.out.print("\n--------------------\n");

                if(!condition.test(inputText))
                    throw new Exception("Неверный формат.\n");

                return inputText.trim();
            } catch (Exception ex) { System.out.print(ex.getMessage()); }
        }
    }

    static public void Show(Object obj) {
        System.out.print(obj.toString());
    }

    static public void Show(List<?> listObj){
        for(var item : listObj){
            System.out.print(item.toString());
            System.out.print('\n');
        }
    }

    static public void indent() {
        System.out.print("\n--------------------\n");
    }
}
