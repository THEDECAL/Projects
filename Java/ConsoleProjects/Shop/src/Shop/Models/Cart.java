package Shop.Models;
import java.util.HashMap;
import java.util.Map;

public class Cart {
    private final HashMap<Product, Integer> products = new HashMap();

    public void addProduct(Product product, Integer count) {
        if(product != null && count > 0) {
            this.products.put(product, count);
        }
        else throw new NullPointerException();
    }

    @Override
    public String toString() {
        var sb = new StringBuilder();

        var sum = 0.0;
        for(Map.Entry<Product, Integer> item: products.entrySet()) {
            sum += item.getValue() * item.getKey().getPrice();
            sb.append(item.getKey().toString() + ' ' + item.getValue().toString() + " шт" + '\n');
        }

        sb.append("Общая стоимость: " + sum + " грн\n");

        return sb.toString();
    }
}