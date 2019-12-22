package Shop;
import Shop.Models.*;
import javafx.util.converter.IntegerStringConverter;
import org.w3c.dom.ranges.RangeException;

import java.util.Scanner;
import java.util.function.Predicate;

public class Main {
    static final private String[] menu = {"Корзина", "Магазин", "Выход"};
    static final private Cart cart = new Cart();
    static final private Shop shop = new Shop();

    public static void main(String[] args) {
        initProducts();

        while (true) {
            try {
                System.out.print("--------------------\n");
                for (int i = 0; i < menu.length; i++) {
                    System.out.print(i + 1 + ". " + menu[i] + '\n');
                }

                var slct = inputNumber("Введите номер действия: ", null);

                switch (slct) {
                    case 1:
                        System.out.print(cart);

                        break;
                    case 2:
                        System.out.print(shop);
                        var prodNum = inputNumber("Введите номер продукта: ", null);
                        var prodCount = inputNumber("Введите кол-во (>0): ", num -> num > 0);
                        var prod = shop.getProductByIndex(prodNum - 1);

                        cart.addProduct(prod, prodCount);
                        break;
                    case 3:
                        System.exit(0);
                        break;
                }

            } catch (Exception ex) {}
        }
    }
    private static Integer inputNumber(String text, Predicate<Integer> condition) {
        if(condition == null) condition = x -> true;
        while(true) {
            try {
                var in = new Scanner(System.in);
                System.out.print(text);
                var num = Integer.parseInt(in.nextLine());
                System.out.print("--------------------\n");

                if(!condition.test(num))
                    throw new Exception("Введенно неподходящее число.\n");

                return num;
            } catch (NumberFormatException ex) {}
            catch (Exception ex) { System.out.print(ex.getMessage()); }
        }
    }

    private static void initProducts() {
        shop.addProduct(new Product("Картофель", 2.50));
        shop.addProduct(new Product("Морковь", 0.90));
        shop.addProduct(new Product("Фасоль", 2.20));
        shop.addProduct(new Product("Огурцы", 1.80));
        shop.addProduct(new Product("Томаты", 3.40));
        shop.addProduct(new Product("Лук", 1.10));
        shop.addProduct(new Product("Капуста", 3.20));
        shop.addProduct(new Product("Перец", 4.10));
    }
}