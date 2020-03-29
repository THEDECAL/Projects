package Shop.Models;
import java.util.ArrayList;

public class Shop {
    private final ArrayList<Product> products = new ArrayList();

    public void addProduct(Product product) {
        if(product != null) {
            products.add(product);
        }
        else throw new NullPointerException();
    }

    public Product getProductByIndex(Integer index) {
        return products.get(index);
    }

    @Override
    public String toString() {
        var sb = new StringBuilder();

        for (Product item: products) {
            sb.append(products.indexOf(item) + 1 + ". " + item + '\n');
        }

        return sb.toString();
    }
}
